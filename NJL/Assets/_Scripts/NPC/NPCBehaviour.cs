using System;
using System.Collections;
using NUnit.Framework.Internal;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    public StateMachine stateMachine;
    public PlayerController player;

    protected virtual void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
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
        time -= Time.deltaTime;
        if (time <= 0)
        {
            callback();

        }
    }
}
