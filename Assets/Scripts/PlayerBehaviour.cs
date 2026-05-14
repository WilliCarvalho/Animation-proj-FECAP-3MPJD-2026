using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationVelocity;
    
    private InputManager inputManager;
    private PlayerAnimation playerAnim;
    private Rigidbody rigidbody;
    
    private Vector3 moveDirection;

    private void Awake()
    {
        inputManager = new InputManager();
        playerAnim = GetComponent<PlayerAnimation>();
        rigidbody = GetComponent<Rigidbody>();

        inputManager.OnPlayerAttack += HandleAttack;
    }

    private void FixedUpdate()
    {
        HandleMove();

        CheckMovingForAnimation();
    }
    
    #region Player movement according to cmera position
    private void HandleMove()
    {
        float moveX = inputManager.GetInputDirection().x * moveSpeed * Time.deltaTime;
        float moveZ = inputManager.GetInputDirection().y * moveSpeed * Time.deltaTime;
        
        moveDirection.x = moveX;
        moveDirection.z = moveZ;
        
        Vector3 cameraRelativeMovement = ConvertMoveDirectionToCameraSpace(moveDirection);

        rigidbody.linearVelocity = 
            new Vector3(cameraRelativeMovement.x, rigidbody.linearVelocity.y, cameraRelativeMovement.z);
        
        RotatePlayerAccordingToInput(cameraRelativeMovement);
    }

    private void RotatePlayerAccordingToInput(Vector3 cameraRelativeMovement)
    {
        //Pegando a posição do input (pra onde o jogador está olhando)
        Vector3 pointToLookAt;
        pointToLookAt.x = cameraRelativeMovement.x;
        pointToLookAt.y = 0;
        pointToLookAt.z = cameraRelativeMovement.z;

        //pegando minha rotação atual
        Quaternion currentRotation = transform.rotation;

        //rotacionando player
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(pointToLookAt);

            transform.rotation =
                Quaternion.Slerp(currentRotation,
                    targetRotation,
                    rotationVelocity * Time.deltaTime);
        }
    }

    private Vector3 ConvertMoveDirectionToCameraSpace(Vector3 moveDirection)
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        Vector3 cameraForwardZProduct = cameraForward * moveDirection.z;
        Vector3 cameraRightXProduct = cameraRight * moveDirection.x;

        Vector3 directionToMovePlayer =
            cameraForwardZProduct + cameraRightXProduct;

        return directionToMovePlayer;
    }
    #endregion

    private void CheckMovingForAnimation()
    {
        Vector3 linearVelocityMagnitudeXZ = new  Vector3(rigidbody.linearVelocity.x, 0, rigidbody.linearVelocity.z);
        if (linearVelocityMagnitudeXZ.magnitude != 0.0f)
        {
            playerAnim.SetIsMoving(true);
        }
        else
        {
            playerAnim.SetIsMoving(false);
        }
    }

    private void HandleAttack()
    {
        playerAnim.AttackTrigger();
    }
}
