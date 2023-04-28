using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _currentSpeed;

    private Rigidbody _rigidbody;
    private Vector3 _direction;
    private float _rotationSpeed = 5f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        RotationLookTarget();

    }
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,Vector3.zero, _currentSpeed*Time.deltaTime);
    }

    private void RotationLookTarget()
    {
        _direction = Vector3.zero - transform.position;
        Quaternion rotation = Quaternion.LookRotation(_direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
    }
}
