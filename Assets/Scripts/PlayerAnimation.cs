using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //Pode guardar o valor do parâmetro de animação numa variável
    //private int IsMoving = Animator.StringToHash("isMoving");

    //Variável com string do parâmetro de animação
    private string isMovingParam = "isMoving";
    
    //Variável com o ID do parâmetro de animação
    private int moveSpeedParam = Animator.StringToHash("moveSpeed");
    
    //Variável que vai armazenar o Componente Animator;
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

    public int GetMoveSpeedAnimParam()
    {
        return moveSpeedParam;
    }

    public void SetMoveSpeedAnimParam(float moveSpeed)
    {
        animator.SetFloat(moveSpeedParam, moveSpeed);
    }
}
