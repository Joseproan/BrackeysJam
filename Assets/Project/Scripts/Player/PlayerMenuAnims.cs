using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuAnims : MonoBehaviour
{
    [SerializeField] private string[] animsNames;
    [SerializeField] private float animCooldownMin;
    [SerializeField] private float animCooldownMax;
    private float timer;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            string randomAnim = animsNames[Random.Range(0, animsNames.Length)];
            animator.SetTrigger(randomAnim);
            timer = Random.Range(animCooldownMin, animCooldownMax);
        }else timer -= Time.deltaTime;
    }
}
