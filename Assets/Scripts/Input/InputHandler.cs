using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance { get; private set; }
    public Vector3 MousePosition { get; private set; }

    private Vector3 _mouseScreenPosition;

    public Vector3 MouseScreenPosition { get => _mouseScreenPosition; }

    public bool MouseClicked { get; private set; }

    public bool Attack { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        MousePosition = Camera.main.ScreenToWorldPoint(_mouseScreenPosition);
    }

    public void LateUpdate()
    {
        MouseClicked = false;
        Attack = false;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        MouseClicked = true;
        var rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (rayHit.collider == null) { return; }
        var hitObject = rayHit.collider.gameObject;
        if (hitObject.GetComponent<BaseEnemy>() != null)
        {
            var enemyToHit = hitObject.GetComponent<BaseEnemy>();
            Player.Instance.Attack(enemyToHit);
            return;
        }

        if(hitObject.GetComponent<Item>() != null)
        {
            Player.Instance.Inventory.PickItem(hitObject);
        }
    }
}
