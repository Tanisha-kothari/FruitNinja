using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Input input;
    public GameObject trail;

    private bool isDragging = false;

    private void Awake()
    {
        input = new Input();
    }

    private void OnEnable()
    {
        input.Enable();

        input.Touch.TouchPress.started += OnTouchDown;
        input.Touch.TouchPress.canceled += OnTouchUp;
        input.Touch.TouchPosition.performed += OnTouchMove;
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void OnTouchDown(InputAction.CallbackContext ctx)
    {
        isDragging = true;

        // Reset trail
        TrailRenderer tr = trail.GetComponent<TrailRenderer>();
        tr.Clear();

        // Hide trail until first valid move
        trail.transform.position = new Vector3(0, 0, -100);
    }

    private void OnTouchUp(InputAction.CallbackContext ctx)
    {
        isDragging = false;
    }

    private void OnTouchMove(InputAction.CallbackContext ctx)
    {
        if (!isDragging) return;

        Vector2 fingerPos = ctx.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(fingerPos);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 point = hit.point;
            point.z = -3; // your depth plane

            trail.transform.position = point;
        }
    }
}
