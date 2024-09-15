using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bomb : MonoBehaviour
{
    [SerializeField] float ExplosionRadius;
    [SerializeField] float ExplosionDelay;
    [SerializeField] int ExplosionDamage;
    [SerializeField] LayerMask DamagebleLayer;
    [SerializeField] AnimationCurve BounceCurve;
    [SerializeField] bool HasExploded;
    [SerializeField] Vector3 InitialPosition;
    [SerializeField] Vector3 TargetPoisition;
    [SerializeField] float ThrowStartTime;
    [SerializeField] float ThrowDuration;
    [SerializeField] float TimeToEnd;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Explosion), ExplosionDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (!HasExploded)
        {
            AnimateThrow();
        }
    }

    void AnimateThrow()
    {
        float TimeElapsed = (Time.time - ThrowStartTime) / ThrowDuration;
        float HeightMultiplier = BounceCurve.Evaluate(TimeElapsed);
        Vector3 CurrentPosition = Vector3.Lerp(InitialPosition, TargetPoisition, TimeElapsed);
        CurrentPosition.y += HeightMultiplier + ThrowDuration;
        transform.position = CurrentPosition;
        if(TimeElapsed >= TimeToEnd)
        {
            HasExploded = true;
        }
    }

    void Explosion()
    {
        Collider[] coliders = Physics.OverlapSphere(transform.position, ExplosionRadius, DamagebleLayer);
        foreach (Collider colider in coliders)
        {
            if (colider != null)
            {
                colider.GetComponent<ExplosionDamage>().TakeDamage(ExplosionDamage);
            }
        }
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }
}
