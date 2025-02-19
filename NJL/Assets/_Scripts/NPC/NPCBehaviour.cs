using System;
using System.Collections;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    public StateMachine stateMachine;
    public PlayerController player;
    public IEnumerator cooldown;
    public bool CRisRunning;


    protected virtual void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        cooldown = Cooldown(0, () => { });
    }

    protected virtual void Update()
    {
        stateMachine.Update();
    }

    protected virtual void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }

    public void CooldownTimer(float time, Action callback)
    {
        StartCoroutine(Cooldown(time, callback));
    }
    protected IEnumerator Cooldown(float time, Action callback)
    {
        CRisRunning = true;
        yield return new WaitForSeconds(time);
        CRisRunning = false;
        callback();
    }
}
