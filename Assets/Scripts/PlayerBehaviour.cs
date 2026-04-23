using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    
    private InputManager inputManager;

    private Rigidbody rigidbody;

    private void Awake()
    {
        inputManager = new InputManager();
        rigidbody = GetComponent<Rigidbody>();
        inputManager.OnAttackPressed += HandleAttackBehaviour;
    }


    private void FixedUpdate()
    {
        float moveX = inputManager.GetInputDirection().x * moveSpeed * Time.deltaTime;
        float moveZ = inputManager.GetInputDirection().y * moveSpeed * Time.deltaTime;
        rigidbody.linearVelocity = new Vector3(moveX, rigidbody.linearVelocity.y, moveZ);
    }
    
    #region Referência de implementação - Não será utilizado no projeto
    private void HandleAttackBehaviour()
    {
        print("Handling ATTACK with strength ");
    }
#endregion

}
