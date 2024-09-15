using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class bullet : MonoBehaviour
{
    [SerializeField] private GameObject plants;
    [SerializeField] private Vector3 posing;
    [SerializeField] private Vector3 posi;
    [SerializeField] private int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        pos.z -= speed * Time.deltaTime;
        transform.position = pos;
        posi = transform.position;
    }
}
