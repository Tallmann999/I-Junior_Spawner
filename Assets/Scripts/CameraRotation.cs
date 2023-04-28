using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    [SerializeField] private float _sensivity;
    [SerializeField] private float _smoothing = 10f;

    private float _mouseDirectionX;
    private float _mouseDirectionY;
    private float _offsetValue = 90f;

    private void Rotation()
    {
        _mouseDirectionY += Input.GetAxis(MouseX) * _sensivity;
        _mouseDirectionX -= Input.GetAxis(MouseY) * _sensivity;
        _mouseDirectionX = Mathf.Clamp(_mouseDirectionX, -_offsetValue, _offsetValue);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_mouseDirectionX, _mouseDirectionY, 0), Time.deltaTime * _smoothing);
    }

    private void Update()
    {
        Rotation();
    }
}
