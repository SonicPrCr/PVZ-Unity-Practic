using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        switch (RotationMethod)
        {
            case RotationMethods.TransformRotate:
                {
                    TransformRotation();
                    break;
                }

            case RotationMethods.EulerAngles:
                {
                    EulerRotate();
                    break;
                }

            case RotationMethods.Quaternion:
                {
                    QuaternionRotation();
                    break;
                }
        }

    }

    public enum RotationMethods
    {
        TransformRotate,
        EulerAngles,
        Quaternion
    }

    public RotationMethods RotationMethod = RotationMethods.TransformRotate;
    public Vector3 rotationAxis = Vector3.up;
    public float rotationSpeed;


    public void TransformRotation()
    {
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }

    public void EulerRotate()
    {
        Vector3 euler = transform.eulerAngles;
        euler += rotationAxis * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = euler;
    }

    public void QuaternionRotation()
    {
        Quaternion rotation = Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, rotationAxis);
        transform.rotation = rotation * transform.rotation;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position,transform.position + transform.position + transform.rotation * rotationAxis.normalized);

        if (Application.isPlaying)
        {
            Vector3 futerPosition;
            switch (RotationMethod)
            {
                case RotationMethods.TransformRotate:
                    {
                        futerPosition = transform.position + transform.up * 2f;
                        Gizmos.color += Color.green;
                        Gizmos.DrawSphere(futerPosition, 0.1f);
                        break;
                    }

                case RotationMethods.EulerAngles:
                    {
                        futerPosition = transform.position + transform.up * 2f;
                        Gizmos.color += Color.blue;
                        Gizmos.DrawSphere(futerPosition, 0.1f);
                        break;
                    }
                case RotationMethods.Quaternion:
                    {
                        futerPosition = transform.position + transform.up * 2f;
                        Gizmos.color += Color.magenta;
                        Gizmos.DrawSphere(futerPosition, 0.1f);
                        break;
                    }
            }
        }

    }

}
