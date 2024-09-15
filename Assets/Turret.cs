using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField, Range(1f, 90f)] private float Amplitude; // Амплитуда синусоиды
    [SerializeField] private float Frequency; // Частота синусоиды
    [SerializeField] private float DetectionRange; // Дальность обнаружения игрока
    [SerializeField] private LayerMask PlayerLayer; // Слой игрока

    [SerializeField] private bool isPlayerInSight; // Состояние, указывающее на наличие игрока в пределах луча
    [SerializeField] private Transform playerTransform; // Трансформ игрока
    [SerializeField] private Quaternion InitialRotation; // Изначальный поворот


    private void Start()
    {
        InitialRotation = transform.localRotation;
    }
    private void Update()
    {
        DetectPlayer();

        if (isPlayerInSight)
        {
            RotateTowardsPlayer();
        }
        else
        {
            HandleMovement();
        }
    }

    private void HandleMovement()
    {
        // Рассчитываем вращение по синусоиде
        float yRotation = Mathf.Sin(Time.time * Frequency) * Amplitude;
        Quaternion newRotation = Quaternion.Euler(0, yRotation, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, InitialRotation * newRotation, Time.deltaTime * Frequency);
    }

    private void DetectPlayer()
    {
        // Направление луча соответствует ориентации турели
        Vector3 forward = transform.forward;

        // Проверяем наличие игрока в пределах луча
        if (Physics.Raycast(transform.position, forward, out RaycastHit hit, DetectionRange, PlayerLayer))
        {
            // Убедимся, что у нашего  игрока установлен тег "Player"
            if (hit.collider.CompareTag("Player"))
            {
                isPlayerInSight = true;
                //Уменьшаем жизни игрока
                hit.collider.GetComponent<CharacterMovementController>().HP.value -= 10 * Time.deltaTime;
                return; // Также можно прервать выполнение этого метода

                
            }
        }

        // Если мы не обнаружили игрока, сбрасываем флаг
        isPlayerInSight = false;
    }

    private void RotateTowardsPlayer()
    {
        // Берем направление к игроку от текущей турели
        Vector3 directionToPlayer = playerTransform.position - transform.position;
        directionToPlayer.y = 0; // Не меняем высоту
        
        // Создаем новую ротацию к игроку
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        
        // Применяем ротацию плавно
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * Frequency);
    }

    private void OnDrawGizmos()
    {
        // Визуализация области обнаружения игрока
        Gizmos.color = isPlayerInSight ? Color.red : Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * DetectionRange);
    }
}
