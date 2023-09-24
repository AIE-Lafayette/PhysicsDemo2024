using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdForceBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _forceMagnitude;
    private Camera _mainCamera;
    private Rigidbody _rigidBody;
    private Vector3 _mouseWorldPosition;
    private bool _forceAdded;

    public Rigidbody BirdRigidBody { get => _rigidBody; private set => _rigidBody = value; }
    public float ForceMagnitude { get => _forceMagnitude; private set => _forceMagnitude = value; }
    public Vector3 MouseWorldPosition { get => _mouseWorldPosition; private set => _mouseWorldPosition = value; }
    public bool ForceAdded { get => _forceAdded; private set => _forceAdded = value; }

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        BirdRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ForceAdded)
            return;

        Vector3 mouseScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _mainCamera.nearClipPlane);

        MouseWorldPosition = _mainCamera.ScreenToWorldPoint(mouseScreenPos);
        _mouseWorldPosition.z = 0;
        if (Input.GetMouseButtonDown(0))
        {
            ForceAdded = true;
            Vector3 direction = (MouseWorldPosition - transform.position);
            BirdRigidBody.AddForce(direction * ForceMagnitude, ForceMode.Impulse);
        }
    }
}
