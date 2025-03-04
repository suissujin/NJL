using UnityEngine;
using UnityEngine.SceneManagement;

public class PerfumeTeleporter : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            SceneManager.LoadSceneAsync(3);
        }
    }
}
