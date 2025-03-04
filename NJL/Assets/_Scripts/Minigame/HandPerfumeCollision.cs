using UnityEngine;

public class HandPerfumeCollision : MonoBehaviour
{
    public GameObject spinnGame;
    public GameObject Perfume1;
    public GameObject Perfume2;
    public MiniGame2Script Player;
    public int perfumeSaturation;
    public ParticleSystem perfumeSaturationParticles;
    private ParticleSystem spray1;
    private ParticleSystem spray2;
    private void OnParticleCollision(GameObject other)
    {
        perfumeSaturation = perfumeSaturation + 1;
    }
    void Update()
    {
        var pSP = perfumeSaturationParticles.emission;
        pSP.rateOverTime = perfumeSaturation;

        if (perfumeSaturation > 25)
        {
            Player.PerfumeSaturated = true;
            spinnGame.SetActive(true);

            Perfume1.transform.position = new Vector3(0.567f, -0.729f, 0.5f);
            spray1 = Perfume1.GetComponentInChildren<ParticleSystem>();
            var em1 = spray1.emission;
            em1.enabled = false;

            Perfume2.transform.position = new Vector3(1.297f, -0.729f, 0.5f);
            spray2 = Perfume2.GetComponentInChildren<ParticleSystem>();
            var em2 = spray2.emission;
            em2.enabled = false;

        }
    }
}
