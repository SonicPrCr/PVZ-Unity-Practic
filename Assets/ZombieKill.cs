using UnityEngine;
using UnityEngine.UI;

public class ZombieKill : MonoBehaviour
{
    [SerializeField] private Slider HP;
    // Start is called before the first frame update
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            HP.value -= 10;
        }
    }


}
