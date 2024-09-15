using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class plants : MonoBehaviour
{
    [SerializeField] private GameObject bullets;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float DetectionRange;
    [SerializeField] private bool isZombieInSight;
    [SerializeField] private bool reload;
    [SerializeField] private float reloadingTime;
    [SerializeField] private float reloadingTimes;
    [SerializeField] private int HP;
    [SerializeField] private int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DedectZombie();
        reloadingTime += Time.deltaTime;
        if (reloadingTime > reloadingTimes)
        {
            reload = false;
        }
        if (HP < 1)
        {
            Destroy(gameObject);
        }
    }



    private void DedectZombie()
    {
        // Направление луча соответствует ориентации турели
        Vector3 forward = transform.forward;

        // Проверяем наличие игрока в пределах луча
        if (Physics.Raycast(transform.position, forward, out RaycastHit hit, DetectionRange, layerMask))
        {
            // Убедимся, что у нашего  игрока установлен тег "Player"
            if (hit.collider.CompareTag("Enemy") && reload == false)
            {
                isZombieInSight = true;
                //Уменьшаем жизни игрока
                Vector3 vec = new Vector3(0,0,0 + 1);
                Instantiate(bullets, transform.position, Quaternion.identity);
                reload = true;
                reloadingTime = 0;
                return; // Также можно прервать выполнение этого метода


            }
        }

    }


    private void OnDrawGizmos()
    {
        // Визуализация области обнаружения игрока
        Gizmos.color = isZombieInSight ? Color.red : Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * DetectionRange);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HP -= damage;
        }
    }
}
