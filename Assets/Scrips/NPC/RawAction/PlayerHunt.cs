using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EOffmeshLinkStatus
{
    NotStarted,
    InProgress
}

public class PlayerHunt : MonoBehaviour
{
    private NavMeshAgent agent;
    public float range = 5;
    public bool shouldMove = false;
    private bool DestinationSet = false;
    private bool DestinationReached =  false;
    public bool AtDestination => DestinationReached;
    EOffmeshLinkStatus OffMeshLinkStatus = EOffmeshLinkStatus.NotStarted;
    public Transform ObjectToRotate;
    private Vector3 prevPosition;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        prevPosition = agent.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && !agent.isOnOffMeshLink && DestinationSet && (agent.remainingDistance <= agent.stoppingDistance))
        {
            DestinationSet = false;
            DestinationReached = true;
        }
                // are we on an offmesh link?
        if (agent.isOnOffMeshLink)
        {
            // have we started moving along the link
            if (OffMeshLinkStatus == EOffmeshLinkStatus.NotStarted)
                StartCoroutine(FollowOffmeshLink());

        }
    }

    public bool IsMoving(){
        if (agent.transform.position != prevPosition)
        {
            prevPosition = agent.transform.position;
            Debug.Log(true);
            return true;
        }
        prevPosition = agent.transform.position;
        Debug.Log(false);
        return false;
    }

        IEnumerator FollowOffmeshLink()
    {
        // start the offmesh link - disable NavMesh agent control
        OffMeshLinkStatus = EOffmeshLinkStatus.InProgress;
        agent.updatePosition = false;
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        // move along the path
        Vector3 newPosition = transform.position;
        while (!Mathf.Approximately(Vector3.Distance(newPosition, agent.currentOffMeshLinkData.endPos), 0f))
        {
            newPosition = Vector3.MoveTowards(transform.position, agent.currentOffMeshLinkData.endPos, agent.speed * Time.deltaTime);
            transform.position = newPosition;

            yield return new WaitForEndOfFrame();
        }

        // flag the link as completed
        OffMeshLinkStatus = EOffmeshLinkStatus.NotStarted;
        agent.CompleteOffMeshLink();

        // return control the agent
        agent.updatePosition = true;
        agent.updateRotation = true;
        agent.updateUpAxis = true;    
    }

    public Vector3 PickLocationInRange(float range){
        Vector3 searchLocation = transform.position;//object centre
        Vector3 randomPoint = searchLocation + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) 
        { 
            return hit.position;
        }
        return transform.position;

    }

    protected virtual void CancelCurrentCommand()
    {
        // clear the current path
        agent.ResetPath();

        DestinationSet = false;
        DestinationReached = false;
        OffMeshLinkStatus = EOffmeshLinkStatus.NotStarted;
    }

    public virtual void MoveTo(Vector3 destination)
    {
        CancelCurrentCommand();

        SetDestination(destination);
    }

    public virtual void SetDestination(Vector3 destination)
    {
        // find nearest spot on navmesh and move there
        NavMeshHit hit;
        agent.SetDestination(agent.transform.position);
        if (NavMesh.SamplePosition(destination, out hit, range, NavMesh.AllAreas)){
            agent.SetDestination(hit.position);
            DestinationSet = true;
            DestinationReached = false;
        }
    }

    public void circleRotate(Vector3 rotationPoint, float rotationSpeed){
        // Check if agent has reached its destination
        if (agent.remainingDistance <= agent.stoppingDistance){
            // Calculate direction to rotation point
            Vector3 direction = rotationPoint - transform.position;

            float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

            // Rotate object towards rotation point
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, angle, 0f), rotationSpeed * Time.deltaTime);
        }
    }


}
