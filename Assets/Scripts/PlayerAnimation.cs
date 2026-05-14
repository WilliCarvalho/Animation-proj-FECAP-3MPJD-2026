using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //Pode guardar o valor do parâmetro de animação numa variável
    //private int IsMoving = Animator.StringToHash("isMoving");

    private string isMovingParam = "isMoving";
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    public void SetIsMoving(bool isMoving)
    {
        animator.SetBool(isMovingParam, isMoving);
    }

    public void AttackTrigger()
    {
        animator.SetTrigger("Attack");
    }
}
