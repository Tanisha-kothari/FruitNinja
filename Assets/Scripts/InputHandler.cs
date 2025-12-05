using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Input input;
    float depth = 10f;
    public GameObject trail;

    private void Awake()
    {
        input = new Input();
    }
    private void OnEnable()
    {
        input.Enable();

        input.Touch.TouchPress.performed += OnTouchPress;
        input.Touch.TouchPosition.performed += TouchPosition;
    }

    private void OnDisable()
    {
        input.Disable();
    }

    public void TouchPosition(InputAction.CallbackContext context)
    {
        Vector2 fingerPos = context.ReadValue<Vector2>();

        Ray ray = Camera.main.ScreenPointToRay(fingerPos);

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 point = hit.point;
            point.z = -3;

            trail.transform.position = point;
        }

    }

    public void OnTouchPress(InputAction.CallbackContext context)
    {

    }

}
