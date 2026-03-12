using UnityEngine;
using UnityEngine.InputSystem;
using InputSystem = UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            Vector3 direction = new Vector3(0,0,1);
            transform.Translate(direction * speed * Time.deltaTime);
        }
        
    }
}