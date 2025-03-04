using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGame2Script : MonoBehaviour
{
    public float SmellScore;
    public bool PerfumeSaturated = false;

    [SerializeField] private Camera mainCamera;

    [SerializeField] private GameObject Selected;

    [SerializeField] private ParticleSystem spray;

    private Vector3 origin;
    private Ray _ray;
    private RaycastHit _hit;

    void Start()
    {
        mainCamera = Camera.main;

    }

    void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePos);

       _ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (!PerfumeSaturated)
        {
            if (Physics.Raycast(_ray, out _hit, 100))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (_hit.transform.tag == "perfume")
                    {
                        Vector3 newOrigin = _hit.transform.position;
                        if (Selected != null)
                        {
                            Selected.GetComponent<CapsuleCollider>().enabled = true;
                            Selected.transform.position = origin;
                        }
                        origin = newOrigin;
                        Selected = _hit.transform.gameObject;
                        spray = Selected.GetComponentInChildren<ParticleSystem>();
                        Selected.GetComponent<CapsuleCollider>().enabled = false;
                    }
                }
            }
            if (Selected != null)
            {
                Selected.transform.position = new Vector3(mousePosWorld.x, mousePosWorld.y, mousePosWorld.z + 1);

                if (Input.GetMouseButtonDown(0) && spray != null)
                {
                    var em = spray.emission;
                    em.enabled = true;
                }
                if (Input.GetMouseButtonUp(0) && spray != null)
                {
                    var em = spray.emission;
                    em.enabled = false;
                }
            }
        }
        if (PerfumeSaturated)
        {
            if (Physics.Raycast(_ray, out _hit, 100))
            {
                if (_hit.transform.tag == "SmellScore")
                {
                    SmellScore = SmellScore + 1* Time.deltaTime;
                }
            }
        }
        if (SmellScore > 5) {
            Debug.Log("You succeeded in smelling perfume");
            SceneManager.LoadSceneAsync(1);
        }
    }
}
