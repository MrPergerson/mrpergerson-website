using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    
    private TopDownMovement move;
    private Controls controls;

    PlayerInput playerInputComponent;

    [SerializeField] bool usingGamepad = false;

    private float autoTurnTimer = .3f;
    private float timeSinceManualTurn = 0;

    private void Awake()
    {
        controls = new Controls();
        playerInputComponent = GetComponent<PlayerInput>();

        move = GetComponent<TopDownMovement>();

        playerInputComponent.onControlsChanged += UpdateCurrentDevice;
        usingGamepad = playerInputComponent.currentControlScheme.Equals("Gamepad") ? true : false;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        move.Move(controls.Player.Move.ReadValue<Vector2>());

        if (controls.Player.Look.WasPerformedThisFrame())
        {
            timeSinceManualTurn = Time.time;

            var look = controls.Player.Look.ReadValue<Vector2>();

            if (usingGamepad)
                move.RotateUsingGamepad(look);
            else
                move.RotateUsingMouse(look);
        }         
        else if (move.IsMoving && Time.time - timeSinceManualTurn > autoTurnTimer)
        {
            var move = controls.Player.Move.ReadValue<Vector2>();
            var dir = new Vector3(move.x, 0, move.y);
            this.move.RotateTowardsDirection(dir);
        }
    }

    private void UpdateCurrentDevice(PlayerInput input)
    {
        usingGamepad = input.currentControlScheme.Equals("Gamepad") ? true : false;
    }


}
