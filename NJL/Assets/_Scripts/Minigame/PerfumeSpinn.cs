using UnityEngine;

public class PerfumeSpinn : MonoBehaviour
{
    public float speed= 1;

    // Update is called once per frame
    void Update()
    {
        speed = speed+60 * Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -speed));
        if (speed > 360)
        {
            speed = 0;

        }
    }
}
