using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SphereSpawn : MonoBehaviour
{
    Vector3 _position;
    [SerializeField] Camera _mainCamera;
    [SerializeField] Transform _spawnPoint;
    [SerializeField] FoodPool _foodPrefabs;
    [SerializeField][Min(0)] float _bounds;
    [SerializeField][Range(0, 90)] float _angleToThrow;
    [SerializeField][Min(0)] float _maxForce;
    [SerializeField][Min(0)] float _forceIncrement = 0.1f;
    [SerializeField] [Range(0, 90)] float _rotateAngle;
    [SerializeField] [Range(0, 30)] float _handRotate;
    [SerializeField] [Range(0, 0.1f)] float handMovementForce;
    float _force = 0;
    bool _isPressed = false;
    ObjectPool _pool;

    Vector2 _relativePos;
    public ObjectInfo ball;

    private void Awake()
    {
        _pool = gameObject.GetComponent<ObjectPool>();
        _foodPrefabs = gameObject.GetComponent<FoodPool>();
        _position = transform.position;
        _pool.CreateObjectPool(_foodPrefabs.foodElements, transform, _spawnPoint.position);
        ball = _pool.PeekRandom();
        ball.obj.SetActive(true);
        ball.transform.position = _spawnPoint.position;
        ball.transform.rotation = _spawnPoint.rotation;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 boundPos = new Vector3(0, transform.position.y, transform.position.z);
        Vector3 boundLength = new Vector3(0, 0, transform.position.z);
        Vector3 forward = new Vector3(0, 0, 20);
        Vector3 left = new Vector3(-_bounds, 0, 0);
        Vector3 right = new Vector3(_bounds, 0, 0);
        Vector3 throwVector = Quaternion.Euler(-_angleToThrow,0, 0) * Vector3.forward;
        var angle = Quaternion.Euler(0, _rotateAngle, 0);
        var n_angle = Quaternion.Euler(0, -_rotateAngle, 0);
        Gizmos.DrawLine(boundPos + left, boundLength + left);
        Gizmos.DrawLine(boundPos + left, n_angle * (boundPos + left + forward));
        Gizmos.DrawLine(boundPos + right, boundLength + right);
        Gizmos.DrawLine(boundPos + right, angle * (boundPos + right + forward));

        Gizmos.color = Color.green;
        Gizmos.DrawLine(boundPos, boundPos + throwVector);
    }

    private void DegreaseBalls()
    {
        GameManager.self.CurrentBalls -= 1;
        if (GameManager.self.CurrentBalls == 0)
        {
            ball.SetActive(false);
        }
    }

    void Update()
    {
        if (GameManager.self.CurrentBalls > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isPressed = true;
                GameManager.self.aud.Windup();
            }
            if (_isPressed && _force < _maxForce)
            {
                Vector2 mousePos = Input.mousePosition;
                _relativePos = new Vector2((mousePos.x / Screen.width) - .5f, (mousePos.y / Screen.height) - .5f) * 2;
                float _boundsValue = _bounds * _relativePos.x;
                _spawnPoint.position = new Vector3(_position.x + _boundsValue, _spawnPoint.position.y, _position.z - _force * handMovementForce);
                _spawnPoint.rotation = Quaternion.Euler(0, _handRotate * _relativePos.x, 0);
                _force += (_forceIncrement * Time.deltaTime);
                ball.transform.position = _spawnPoint.position;
                ball.transform.rotation = _spawnPoint.rotation;
            }
            if ((_isPressed && Input.GetMouseButtonUp(0)) || _force >= _maxForce)
            {
                GameManager.self.aud.Release();


                ball.SetActive(true);
                _spawnPoint.position = new Vector3(_spawnPoint.position.x, _spawnPoint.position.y, _position.z);
                ball.transform.position = _spawnPoint.position;
                ball.transform.rotation = _spawnPoint.rotation;
                ball.body.velocity = Vector3.zero;
                Vector3 forceVector = Quaternion.Euler(-_angleToThrow, _relativePos.x * _rotateAngle, 0) * Vector3.forward * _force;
                ball.body.AddForce(forceVector, ForceMode.VelocityChange);
                _force = 0;
                _isPressed = false;
                if (ball.timer != null)
                {
                    StopCoroutine(ball.timer);
                }
                ball.timer = StartCoroutine(ball.HideToTime(3));

                ball = _pool.PeekRandom();
                ball.SetActive(false);
                ball.obj.SetActive(true);
                ball.transform.position = _spawnPoint.position;
                ball.transform.rotation = _spawnPoint.rotation;
                if (ball.timer != null)
                {
                    StopCoroutine(ball.timer);
                }
                DegreaseBalls();
            }
        }
    }
}
