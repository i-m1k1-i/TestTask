using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "new InputReader", menuName = "ScriptableObjects/InputReader")]
public class InputReader : ScriptableObject, GameInput.IPlayerActions
{
    private GameInput input;

    public float MoveInput => input.Player.Move.ReadValue<float>();

    private void OnEnable()
    {
        input ??= new GameInput();
        input.Player.SetCallbacks(this);
        input.Player.Enable();
    }

    private void OnDisable()
    {
        input.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        return;
    }
}
