using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public enum EnemyStates
    {
        Idle, Patrol, Follow, Lunge, Dodge
    }

    private bool dodgeFlag;
    private bool playerInSight;

    public EnemyStates currentState;
    private NavMeshAgent agent;
    private Rigidbody bulletDetect;
    private SphereCollider col;
    public Transform Target;
    public GameObject player;
    public Collider bulletCheck;
    

    public Transform[] waypoints;
    private int waypointIndex = 0;

    private float nextActionTime = 0.0f;
    public float fireRate = 1.0f;
    public float idlePauseRate = 0f;

    public float followDistance = 10.0f;
    public float TargetTooFarDistance = 20.0f;
    public float LungeDistance = 5.0f;
    public float fieldOfViewAngle = 110f;
  //  public Vector3 personalLastSighting;

  //  private LastPlayerSighting lastPlayerSighting;
  //  private Vector3 previousSighting;

    public float WalkingSpeed = 10.0f;
    public float LungeSpeed = 30.0f;
    public float dodgeSpeed = 6.0f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        bulletDetect = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();

        SetPatrolState();
    }

    private void FixedUpdate()
    {
        if (dodgeFlag)  //if (dodgeFlag == True)
        {
            dodgeFlag = false;

            Vector3 dir = Random.value > 0.5f ? -transform.right : transform.right;

            bulletDetect.AddForce(dir * dodgeSpeed, ForceMode.Impulse);

            SetFollowState();
        }

    }


    private void Update()
    {
        switch (currentState)
        {
            case EnemyStates.Idle:
                IdleUpdate();
                break;
            case EnemyStates.Patrol:
                PatrolUpdate();
                break;
            case EnemyStates.Follow:
                FollowUpdate();
                break;
            case EnemyStates.Lunge:
                LungeUpdate();
                break;
            case EnemyStates.Dodge:
                
                break;
            default:
                break;
        }
    }

    private void IdleUpdate()
    {
        if (Time.time >= nextActionTime)
        {
            SetPatrolState();
        }
        CheckFollowDistance();
    }

    private void PatrolUpdate()
    {

        if (Vector3.Distance(transform.position, waypoints[waypointIndex % waypoints.Length].position) <= 1f)
        {
            waypointIndex++;
            agent.destination = transform.position;
            SetIdleState();
            nextActionTime = Time.time + idlePauseRate;
        }

        CheckFollowDistance();
    }

    private void FollowUpdate()
    {
        agent.speed = WalkingSpeed;
        agent.destination = Target.position;
        //CheckLungeDistance();
        CheckStopFollowDistance();


        if (Vector3.Distance(transform.position, Target.position) > TargetTooFarDistance)
        {
            currentState = EnemyStates.Idle;
        }
    }

    private void LungeUpdate()
    {
       if (Time.time >= nextActionTime)
        {
            agent.speed = LungeSpeed;
            CheckFollowDistance();
        }
    }



    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Bullet"))
    //     {
    //        SetDodgeState();
    //     }

    //}

    void CheckFollowDistance()
    {
        if (Vector3.Distance(transform.position, Target.position) < followDistance && Vector3.Distance(transform.position, Target.position) > LungeDistance)

        {
            playerInSight = false;
            Vector3 direction = Target.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            if (angle < fieldOfViewAngle * 0.5f)
            {
                //print("Target Seen");
               // SetFollowState();
                RaycastHit hit;
                Debug.DrawRay(transform.position, direction, Color.green, 1.0f);
                if (Physics.Raycast(transform.position, direction.normalized, out hit, followDistance))
                {
                 
                    if (hit.collider.gameObject == player)
                    {
                        playerInSight = true;
                        SetFollowState();
                    }




                }
            }
           
            
        }
    }

    void CheckStopFollowDistance()
    {
        if (Vector3.Distance(transform.position, Target.position) > TargetTooFarDistance)
        {
            SetIdleState();
        }
    }

    //void CheckLungeDistance()
    //{
    //    if (Vector3.Distance(transform.position, Target.position) < LungeDistance)
    //    {
    //        SetLungeState();
    //    }
    //}

    void SetIdleState()
    {
        currentState = EnemyStates.Idle;
    }

    void SetPatrolState()
    {
        agent.speed = WalkingSpeed;
        currentState = EnemyStates.Patrol;
        agent.destination = waypoints[waypointIndex % waypoints.Length].position;
    }

    void SetFollowState()
    {
        currentState = EnemyStates.Follow;
    }

    void SetLungeState()
    {
        currentState = EnemyStates.Lunge;
    }

    public void SetDodgeState()
    {
        currentState = EnemyStates.Dodge;
        dodgeFlag = true;
    }
}

