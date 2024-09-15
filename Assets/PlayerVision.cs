using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerVision : MonoBehaviour
{
    [SerializeField] private Transform PlayerPos;
    [SerializeField, Range(0f,10f)] private float Distance;
    [SerializeField] private LayerMask TurretsLayer,BarrierLayer;
    [SerializeField] private Transform ClosetsBarrier;
    [SerializeField] private bool IsHidding;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (IsHidding)
            {
                UnHidding();
            }
            else
            {
                CheckForBarriesAndHide();
            }
        }
    }

    void CheckForBarriesAndHide()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position,Distance,BarrierLayer);
        if (hitColliders.Length > 0)
        {
            ClosetsBarrier = null;
            float closesDistance = Mathf.Infinity;
            foreach (Collider hitCollider in hitColliders)
            {
                float distance = Vector3.Distance(transform.position, hitCollider.transform.position);
                if (distance < closesDistance)
                {
                    closesDistance = distance;
                    ClosetsBarrier = hitCollider.transform;
                }
            }

            if (ClosetsBarrier != null)
            {
                Vector3 directionToBarrier = ClosetsBarrier.position - transform.position;
                float leftDistance = Vector3.Distance(ClosetsBarrier.position + ClosetsBarrier.right * (ClosetsBarrier.localScale.x / 2), transform.position);
                float rightDistance = Vector3.Distance(ClosetsBarrier.position - ClosetsBarrier.right * (ClosetsBarrier.localScale.x / 2), transform.position);
                if (leftDistance < rightDistance)
                {
                    transform.position = ClosetsBarrier.position + ClosetsBarrier.right * (ClosetsBarrier.localScale.x / 2 + transform.localScale.x / 2);
                }
                else
                {
                    transform.position = ClosetsBarrier.position - ClosetsBarrier.right * (ClosetsBarrier.localScale.x / 2 + transform.localScale.x / 2);
                }
            }
        }
    }
    void UnHidding()
    {

    }
}
