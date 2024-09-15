using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchColor : MonoBehaviour
{
    public Renderer Rend;
    public Color color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            color = new Color(Random.value, Random.value, Random.value);
            if (color == Rend.material.color)
            {
                color = new Color(Random.value, Random.value, Random.value);
            }
            Rend.material.color = color;
        }
    }
}
