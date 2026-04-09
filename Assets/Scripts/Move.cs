using UnityEngine;
using UnityEngine.InputSystem;
using InputSystem = UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float moveX = 0f;

        if (Keyboard.current.aKey.isPressed)
        {
            moveX += 1f;
        }
        
        if (Keyboard.current.dKey.isPressed)
        {
            moveX -= 1f;
        }

        // Apply movement on the X axis
        Vector3 direction = new Vector3(moveX, 0, 0);
        transform.Translate(direction * speed * Time.deltaTime);
    }
}