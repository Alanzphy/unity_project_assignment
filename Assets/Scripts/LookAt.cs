using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;
    public float speed = 1.0f;


    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(target);

        Vector3 direction = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);

    }
}
