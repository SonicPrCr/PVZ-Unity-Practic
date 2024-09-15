using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovementController : MonoBehaviour
{
    // Переменные для настройки скорости движения и поворота
    [SerializeField] private float MoveSpeed; // Обычная скорость ходьбы
    [SerializeField] private float TurnSpeed; // Скорость вращения объекта
    [SerializeField] private float RunSpeed; // Скорость бега
    float tempSpeed; // Поле нужно, чтобы хранить изначальную скорость после бега
    public Slider HP; // Полоска здоровья
    [SerializeField] private Slider Stamina; // Полоска стамины
    [SerializeField] private bool CanSprint; // Состояние игрока показывающие может ли бегать игрок
    

    // Компоненты, необходимые для управления движением
    [SerializeField] private Rigidbody characterRigidbody;

    void Start()
    {
	
    }

    void Update()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        // Получаем направление движения по оси Z (вперед/назад)
        float moveDirection = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveDirection * MoveSpeed * Time.deltaTime;

        // Перемещаем персонажа
        characterRigidbody.MovePosition(characterRigidbody.position + movement);

        if (Input.GetKeyDown(KeyCode.LeftShift) && CanSprint == true)
        {
            tempSpeed = MoveSpeed;
            MoveSpeed = RunSpeed;

        }

        if (Input.GetKey(KeyCode.LeftShift) && CanSprint == true)
	    {
            Stamina.value -= 10 * Time.deltaTime;
	    
	    }
	    else if (Input.GetKeyUp(KeyCode.LeftShift) || CanSprint == false)
	    {
	        MoveSpeed = tempSpeed;
	    }

        if(Stamina.value == 0)
        {
            CanSprint = false;
        }

        else if (Stamina.value > 10)
        {
            CanSprint = true;
        }

        if (moveDirection == 0)
        {
            Stamina.value += 1 * Time.deltaTime;
        }
	
    }
    

    private void Turn()
    {
        // Получаем направление поворота по оси Y (влево/вправо)
        float turnDirection = Input.GetAxis("Horizontal");
        float turn = turnDirection * TurnSpeed * Time.deltaTime;

        // Поворачиваем персонажа вокруг оси Y
        Vector3 rotation = new Vector3(0, turn, 0);
        Quaternion deltaRotation = Quaternion.Euler(rotation);
        characterRigidbody.MoveRotation(characterRigidbody.rotation * deltaRotation);
    }
}
