//Dexter Krijgsman
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    private int lastWaypointIndex;
    private int targetWaypointIndex = 0;
    private float minDistance = 0.1f;

    [SerializeField]
    private float movementSpeed = 3.0f;
    [SerializeField]
    private float rotationSpeed = 3.5f;

    //score
    public GameObject scriptManagerEnemies;
    public int addDead;
    public Score score;
    //Audio
    AudioSource audioData;


    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        lastWaypointIndex = waypoints.Count - 1;
        targetWaypoint = waypoints[targetWaypointIndex];

        addDead = scriptManagerEnemies.GetComponent<Score>().enemyDead;
    }

    // Update is called once per frame
    void Update()
    {
        float movementStep = movementSpeed * Time.deltaTime;
        float rotationStep = rotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = targetWaypoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);

        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        CheckDistanceToWaypoint(distance);

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);
    }

    void CheckDistanceToWaypoint(float currentDistance)
    {
        if (currentDistance <= minDistance)
        {
            targetWaypointIndex++;
            UpdateTargetWaypoint();
        }
    }

    void UpdateTargetWaypoint()
    {
        //This if statement checks if the AI has reached the end of the waypoints and then set's the next waypoint to the first "index[0]"
        if (targetWaypointIndex > lastWaypointIndex)
        {
            targetWaypointIndex = 0;
        }

        targetWaypoint = waypoints[targetWaypointIndex];
    }
    /*
       private void OnCollisionEnter(Collision collision)
       {
           if(collision.gameObject.tag == "Container" || collision.gameObject.tag == "Unchild")
           {

               addDead++;
               Destroy(this.gameObject);
           }
       }
       */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Container" || collision.gameObject.tag == "Unchild")
        {
            audioData.Play(0);
            transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().enabled = false;
            transform.GetComponent<CapsuleCollider>().enabled = false;
            score.enemyDead++;
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
