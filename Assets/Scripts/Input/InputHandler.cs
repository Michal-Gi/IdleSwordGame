using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance { get; private set; }
    public Vector3 MousePosition { get; private set; }

    private Vector3 _mouseScreenPosition;

    public Vector3 MouseScreenPosition { get => _mouseScreenPosition; }

    public bool MouseClicked { get; private set; }

    public bool Attack {  get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    public void Update()
    {
        MousePosition = Camera.main.ScreenToWorldPoint(_mouseScreenPosition);
    }

    public void LateUpdate()
    {
        MouseClicked = false;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        MouseClicked = true;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(!context.started) return;
        var rayHit = Physics2D.Raycast(_mouseScreenPosition, transform.forward, Camera.main.transform.position.z, LayerMask.GetMask("Enemy"));
        Debug.Log(!rayHit ? "poza celem" : "no kurwa w koncu");
    }
}
