using System;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EmployeeBehaviour : NPCBehaviour
{
    public float idleTimer = 5;
    public float speed = 5;
    protected override void Start()
    {
        base.Start();

        stateMachine = new();
        stateMachine.AddState(new Employee.IdleState(this, stateMachine));
        stateMachine.AddState(new Employee.PatrolState(this, stateMachine));
        stateMachine.AddState(new Employee.SwarmState(this, stateMachine));
        stateMachine.SetState<Employee.IdleState>();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public void LookAtPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }

    void OnawGizmos()
    {
        Handles.Label(transform.position + Vector3.up * 3, "Current State: " + stateMachine.currentState.GetType().Name);
    }

}
