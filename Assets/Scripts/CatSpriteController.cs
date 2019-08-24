using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpriteController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("a_pressed", true);
            Debug.Log("A pressed");
        }

        else if(Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("s_pressed", true);
            Debug.Log("S pressed");
        }

        else if(Input.GetKeyDown(KeyCode.K))
        {
            animator.SetBool("k_pressed", true);
            Debug.Log("K pressed");
        }

        else if(Input.GetKeyDown(KeyCode.L))
        {
            animator.SetBool("l_pressed", true);
            Debug.Log("L pressed");
        }

        else
        {
            animator.SetBool("a_pressed", false);
            animator.SetBool("s_pressed", false);
            animator.SetBool("k_pressed", false);
            animator.SetBool("l_pressed", false);
            animator.SetBool("idle", true);
        }
    }
}
