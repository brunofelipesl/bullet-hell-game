using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private PlayerInputActions inputActions;

    public Vector2 MoveInput { get; private set; }
    public bool ShootPressed { get; private set; }

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();

        inputActions.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => MoveInput = Vector2.zero;

        inputActions.Player.Shoot.performed += ctx => ShootPressed = true;
        inputActions.Player.Shoot.canceled += ctx => ShootPressed = false;
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}
