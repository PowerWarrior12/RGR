using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    float rotationSpeed = 1.0f;
    private float eulerY = 0;
    [SerializeField]
    private int healf = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Bullet>()) 
        {
            healf--;
            if (healf < 0)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }
}
