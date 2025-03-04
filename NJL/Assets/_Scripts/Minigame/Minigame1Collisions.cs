using UnityEngine;

public class Minigame1Collisions : MonoBehaviour
{
    public GameObject hand;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }
    private void Update()
    {
        hand.transform.position = new Vector3(transform.position.x,transform.position.y,0);
    }
}
