using UnityEngine;

public class animationtest : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("isJumping");
        }
        /*if(Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool(name, false);
        }*/
    }
}
