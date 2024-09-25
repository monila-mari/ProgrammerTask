using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagAnimationTrigger : MonoBehaviour
{
    public Animator flagAnimator; 
    public string animationTriggerName = "FlagTrigger"; // ��� �������� � Animator, ������� ��������� �������� �������� �����

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            flagAnimator.SetTrigger(animationTriggerName);
        }
    }
}
