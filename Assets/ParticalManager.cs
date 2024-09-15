using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalManager : MonoBehaviour
{
    
    #region отвечает за угол
    [SerializeField] float StartAngel;
    [SerializeField] float EndAnagle;
    [SerializeField] float SpeedChangeAngle;
    [SerializeField] float CurentAngle;
    #endregion
    #region
    [SerializeField] float StartRadius;
    [SerializeField] float EndRadius;
    [SerializeField] float SpeedChangeRadius;
    [SerializeField] float CurentRadius;
    #endregion
    [SerializeField] ParticleSystem _particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ParticalSystemChange();
    }

    void ParticalSystemChange()
    {
        CurentAngle = Mathf.Lerp(StartAngel, EndAnagle, Mathf.PingPong(Time.time / SpeedChangeAngle,1f));
        CurentRadius = Mathf.Lerp(StartRadius, EndRadius, Mathf.PingPong(Time.time / SpeedChangeRadius,1f));
        var shape = _particleSystem.shape;
        shape.radius = CurentRadius;
        shape.angle = CurentAngle;
    }
}
