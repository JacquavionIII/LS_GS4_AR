using UnityEngine;

public class Box2 : ARInteractableObject
{
    private Animator animator;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
    }

    protected override void SetState(State state)
    {
        base.SetState(state);
        switch (state)
        {
            case State.Idle:
            animator.SetTrigger("Idle");
            break;
            case State.Active:
            animator.SetTrigger("StartInteraction");
            break;
        }
    }
}
