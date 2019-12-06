using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransition : MonoBehaviour
{

    Animator m_Animator;

    List<Collider> colliders = new List<Collider>();

    public bool NextStage;

    private void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(NextStage)
            {
                Debug.Log("Next stage");
                m_Animator.SetTrigger("Stage transition");
            }
            else
            {
                m_Animator.SetTrigger("End");
            }          
        }
    }

}
