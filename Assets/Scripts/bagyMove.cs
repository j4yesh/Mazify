using UnityEngine;

public class bagyMove : MonoBehaviour
{
    public float moveSpeed = 0.000007f;
    Vector3 min = new Vector3(-1.2f, -0.7f, 0f);
    Vector3 max = new Vector3(1f, 0.5f, 0f);

    void Update()
    {
       
        Vector3 mousePosition = Input.mousePosition;

        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));

        Vector3 constrainedPosition = new Vector3(
            Mathf.Clamp(worldMousePosition.x, min.x, max.x),
            Mathf.Clamp(worldMousePosition.y, min.y, max.y),
            Mathf.Clamp(worldMousePosition.z, min.z, max.z)
        );

        transform.position = Vector3.MoveTowards(transform.position, constrainedPosition, moveSpeed * Time.deltaTime);
    }
}
