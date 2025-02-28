using Employee;
using UnityEditor;
using UnityEngine;

public class EmployeeBehaviour : NPCBehaviour
{
    public float idleTimer = 5;
    public float speed = 5;
    public float talkingDistance = 5;

    protected override void Start()
    {
        base.Start();

        stateMachine = new StateMachine();
        stateMachine.AddState(new IdleState(this, stateMachine));
        stateMachine.AddState(new PatrolState(this, stateMachine));
        stateMachine.AddState(new SwarmState(this, stateMachine));
        stateMachine.AddState(new ConsultingState(this, stateMachine));
        stateMachine.SetState<IdleState>();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    void OnDrawGizmos()
    {
        if (Application.isPlaying)
            Handles.Label(transform.position + Vector3.up * 3,
                "Current State: " + stateMachine.currentState.GetType().Name);
    }

    public void LookAtPlayer()
    {
        var direction = player.transform.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}