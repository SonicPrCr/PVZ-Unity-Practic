using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] int Health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int formalDamage)
    {
        Health -= formalDamage;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
