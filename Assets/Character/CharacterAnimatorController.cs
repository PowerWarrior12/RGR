using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorController : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    bool isStay = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0 && isStay)
        {
            anim.SetBool("Walk", isStay);
            isStay = false;
        }
        if (Input.GetAxis("Vertical") == 0 && !isStay)
        {
            isStay = true;
            anim.SetBool("Walk", !isStay);
        }
    }
}
