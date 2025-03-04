using Employee;
using UnityEditor;
using UnityEngine;

public class EmployeeBehaviour : NPCBehaviour
{
    public float idleTimer = 5;
    public float speed = 5;
    public float talkingDistance = 5;
    public GameObject head;

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
        var newLookAngle = transform.localRotation;
        head.transform.LookAt(player.camera.transform);
        if (head.transform.localEulerAngles.y is > 90 and < 180)
            newLookAngle = Quaternion.Euler(0, head.transform.eulerAngles.y - 90, 0);

        if (head.transform.localEulerAngles.y is < 270 and > 180)
            newLookAngle = Quaternion.Euler(0, head.transform.eulerAngles.y + 90, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, newLookAngle, Time.deltaTime * 5);
    }
}