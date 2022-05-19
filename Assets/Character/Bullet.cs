using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    float speed = 100f;
    [SerializeField]
    private GameObject explosionExaple;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject.Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * 100f, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<DestroyObject>()) 
        {
            Instantiate(explosionExaple, transform.position, Quaternion.identity);
            GameObject.Destroy(gameObject);
        }
    }
}
