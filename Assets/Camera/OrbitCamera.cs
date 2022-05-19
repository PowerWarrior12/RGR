using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class OrbitCamera : MonoBehaviour
{
    [SerializeField]
    Transform focus = default;
    [SerializeField, Range(1f, 20f)]
    float distance = 5f;
    [SerializeField, Min(0f)]
    float focusRadius = 1f;
    [SerializeField, Range(0f, 1f)]
    float focusCentering = 0.5f;
    Vector3 focusPoint;
    [SerializeField]
    float speeds = 0;
    private float eulerX = 0, eulerY = 0;
    [SerializeField, Range(0, 100f)]
    private float viewingAngle = 3f;
    bool isStart = false;

    void Awake()
    {
        focusPoint = focus.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            float X = Input.GetAxis("Mouse X") * speeds * Time.deltaTime;
            float Y = -Input.GetAxis("Mouse Y") * speeds * Time.deltaTime;
            eulerX = Mathf.Clamp((transform.rotation.eulerAngles.x + Y) % 360, 0, 70);
            eulerY = (transform.rotation.eulerAngles.y + X) % 360;
            transform.rotation = Quaternion.Euler(eulerX, eulerY, 0);
        }
    }

    private void LateUpdate()
    {
        if (isStart) 
        {
            UpdateFocusPoint();
            Vector3 lookDirection = transform.forward;
            Vector3 lookPosition = focusPoint - lookDirection * distance;
            RaycastHit hit;
            Debug.DrawRay(focusPoint, -lookDirection * distance, Color.green);
            Debug.DrawRay(focusPoint + focus.forward * viewingAngle, -lookDirection * distance, Color.green);
            Debug.DrawRay(focusPoint - focus.forward * viewingAngle, -lookDirection * distance, Color.green);
            if (Physics.Raycast(
                focusPoint - focus.forward, -lookDirection, out _, distance
            ) && Physics.Raycast(
                focusPoint + focus.forward, -lookDirection, out _, distance
            ) && Physics.Raycast(
                focusPoint, -lookDirection, out hit, distance)
            )
            {
                if (hit.collider.gameObject.GetComponent<CameraWall>())
                    lookPosition = focusPoint - lookDirection * hit.distance;
            }
            transform.localPosition = lookPosition;
        }
    }


    void UpdateFocusPoint()
    {
        Vector3 targetPoint = focus.position;
        if (focusRadius > 0f)
        {
            float distance = Vector3.Distance(targetPoint, focusPoint);
            float t = 1f;
            if (distance > 0.01f && focusCentering > 0f)
            {
                t = Mathf.Pow(1f - focusCentering, Time.deltaTime);
            }
            if (distance > focusRadius)
            {
                t = Mathf.Min(t, focusRadius / distance);
            }
            focusPoint = Vector3.Lerp(targetPoint, focusPoint, t);
        }
        else
        {
            focusPoint = targetPoint;
        }
    }
    public void StartGame()
    {
        isStart = true;
    }
}
