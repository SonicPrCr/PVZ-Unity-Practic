using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour

    


{
    [SerializeField]
    [Range(1f, 10f)]
    private int Speed;
    [SerializeField]
    [Range(1f, 10f)]
    private int JumpForce;
    public float DirectionX, DirectionZ;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMove();
    }

    private void CharacterMove()
    {
        DirectionX = Input.GetAxis("Horizontal");
        DirectionZ = Input.GetAxis("Vertical");
        Vector3 movment = new Vector3(DirectionX,0, DirectionZ);
        Vector3 NewPosition = rb.position + movment * Speed * Time.deltaTime;
        rb.position = NewPosition;

    }
}
