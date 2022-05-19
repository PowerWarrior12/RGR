using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public Rigidbody rigidbody_;
    public float speed = 1;
    public float rotationSpeed = 1;
    public Text text;
    [SerializeField, Range(0.01f, 10f)]
    float velocityStop = 0.5f;
    [SerializeField]
    private GameObject bulletExample;
    float maxVelocity = 0f;
    [SerializeField]
    Transform bulletPosition;
    bool isStart = false;
    // Start is called before the first frame update
    void Start()
    {
        maxVelocity = 1f * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isStart)
        {
            Move();
            Rotation();
            Shoot();
        }
    }

    private void Move() 
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            Vector3 force = transform.forward * speed * Mathf.Sign(Input.GetAxis("Vertical"));
            rigidbody_.AddForce(force, ForceMode.Force);
        }
        else 
        {
            rigidbody_.velocity = Vector3.Lerp(rigidbody_.velocity, Vector3.zero, velocityStop);
        }
        rigidbody_.velocity = Vector3.ClampMagnitude(rigidbody_.velocity, maxVelocity);
    }

    private void Rotation()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(new Vector3(0, rotationSpeed * Input.GetAxis("Horizontal"), 0));
        }
    }

    private void Shoot() 
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(bulletExample, bulletPosition.position, transform.rotation);
        }
    }

    public void StartGame()
    {
        isStart = true;
    }
}
