using UnityEngine;
using UnityEngine.UIElements;

public class Minigame_I : MonoBehaviour
{


    private void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePos);
        transform.LookAt(mousePosWorld,Vector3.up);
    }

}
