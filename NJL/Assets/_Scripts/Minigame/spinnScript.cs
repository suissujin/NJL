using UnityEngine;

public class spinnScript : MonoBehaviour
{

    private void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 direction = (mousePosWorld - transform.position);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }
}
