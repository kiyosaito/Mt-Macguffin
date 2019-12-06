using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingBlock : MonoBehaviour
{

    Animator m_Animator;

    List<Collider> colliders = new List<Collider>();


    private void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            m_Animator.SetTrigger("Fall");
                 
        }
    }

}
