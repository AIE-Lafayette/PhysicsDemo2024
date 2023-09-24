using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryCalculatorBehaviour : MonoBehaviour
{
    private BirdForceBehaviour _birdForce;
    private Vector3 _endPosition;
    [SerializeField]
    private LineRenderer _lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _birdForce = GetComponent<BirdForceBehaviour>();
        _lineRenderer.SetPosition(0, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (_birdForce.ForceAdded)
            return;

        Vector3 direction = (_birdForce.MouseWorldPosition - transform.position);
        Vector3 initialVelocity = direction * _birdForce.ForceMagnitude;

        Vector3 diplacement = new Vector2(Mathf.Pow(-initialVelocity.x, 2), Mathf.Pow(-initialVelocity.y, 2)) / 2 * 9.81f;

        _endPosition = transform.position + diplacement;
        _endPosition.y = 0;

        _lineRenderer.SetPosition(1, _birdForce.MouseWorldPosition);
        _lineRenderer.SetPosition(2, _endPosition);
    }
}
