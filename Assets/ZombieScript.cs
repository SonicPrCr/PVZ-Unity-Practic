using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private float duration;
    [SerializeField] private float elapsedTime;
    [SerializeField] private AnimationCurve animeCurve;
    [SerializeField] private float progress;
    [SerializeField] private float currentValue;
    [SerializeField] private int HP;
    [SerializeField] private int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            progress = elapsedTime / duration;
            currentValue = animeCurve.Evaluate(progress);
            float newZ = transform.position.z + currentValue * distance;
            transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
        }
        else
        {
           elapsedTime = 0;
        }
        if (HP < 1)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            HP -= damage;
        }
    }
}


