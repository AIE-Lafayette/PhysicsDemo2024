using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _minDeathSpeed;
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.attachedRigidbody?.velocity.magnitude > _minDeathSpeed || _rigidBody.velocity.magnitude > _minDeathSpeed)
            Destroy(gameObject);
    }
}
