using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DobbelManager : MonoBehaviour
{
    public Score score;
    public DiceFight diceFight;

    public GameObject[] enemyPirate;

    [SerializeField]
    private GameObject prefabDice;
    private GameObject dice;

    
    public GameObject questPlayer;
    private Rigidbody rb;

    private bool rollBool1 = false;
    private bool rollBool2 = false;
    private bool rollingDiceBool = true;

    private bool enemyIsPlaying = false;
    private bool antiRepeatEP = false;

    public int timesRolled;

    public int hitDmg;
    public int enemyHitDmg;

    private int newEnemysDeadScore = 0;
    private int oldEnemysDeadScore = 0;
    private int throwScore = 0;

    private int whichPirate = 0;

    private int newSQPirateKills;
    private int oldSQPirateKills;

    void Start()
    {
        
        rb = questPlayer.GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        //NEDS is always the same as enemyDead score from Score script
        //checks if newscore changed in value then gives throwScore +1 for how manny times u can use the dice
        //(U can use the dice as many times as u splett a pirate)
        newEnemysDeadScore = score.enemyDead;
        newSQPirateKills = diceFight.piratesDestroyed;

        if (oldEnemysDeadScore != newEnemysDeadScore)
        {
            throwScore++;
            oldEnemysDeadScore = newEnemysDeadScore;
        }

        if (oldSQPirateKills != newSQPirateKills)
        {
            whichPirate++;
            oldSQPirateKills = newSQPirateKills;
        }

        //If get input Up spawn and start rolling dice
        if (Input.GetKeyDown(KeyCode.UpArrow) && rollBool1 == false && throwScore >= 1 && enemyIsPlaying == false)
        {
            rollBool1 = true;
            throwScore--;
            Instantiate(prefabDice, new Vector3(questPlayer.transform.position.x, questPlayer.transform.position.y + 4,questPlayer.transform.position.z), Quaternion.identity);
            rollingDiceBool = true;
            dice = GameObject.FindGameObjectWithTag("DobbelSteen");
            StartCoroutine(RollingDice());
            StartCoroutine(RrollBool2SetTrue());
        }

        //If get input Up again Jump and get number on dice
        if (Input.GetKeyDown(KeyCode.UpArrow) && rollBool2 == true)
        {
            rollBool2 = false;
            rollingDiceBool = false;
            rb.AddForce(Vector3.up * 500);
            hitDmg = Random.Range(1,7);
            StartCoroutine(RotatingDice());
        }

        if (enemyIsPlaying == true && antiRepeatEP == false)
        {
            antiRepeatEP = true;
            StartCoroutine(LetEnemyPlay());
        }

    }

    //Moet paar seconden wachten omdat hij anders meteen de 2e input meeneemt
    //(kan ook niet in rolling dice omdat hij anders de hele tijd aan word gezet per refresh)
    IEnumerator RrollBool2SetTrue()
    {
        yield return new WaitForSeconds(0.2f);
        rollBool2 = true;
    }

    IEnumerator RollingDice()
    {
        //Het zijn allemaal if statements zodat het tussen door kan stoppen(als de player input 2 doet)
        //1
        if (rollingDiceBool == true)
        {
            dice.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            yield return new WaitForSeconds(0.2f);
        }
        //2
        if (rollingDiceBool == true)
        {
            dice.transform.rotation = Quaternion.Euler(-90.0f, 0.0f, 0.0f);
            yield return new WaitForSeconds(0.2f);
        }
        //3
        if (rollingDiceBool == true)
        {
            dice.transform.rotation = Quaternion.Euler(180.0f, 90.0f, 90.0f);
            yield return new WaitForSeconds(0.2f);
        }
        //4
        if (rollingDiceBool == true)
        {
            dice.transform.rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
            yield return new WaitForSeconds(0.2f);
        }
        //5
        if (rollingDiceBool == true)
        {
            dice.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
            yield return new WaitForSeconds(0.2f);
        }
        //6
        if (rollingDiceBool == true)
        {
            dice.transform.rotation = Quaternion.Euler(0.0f, 90.0f, 180.0f);
            yield return new WaitForSeconds(0.2f);
        }
        
        if (rollingDiceBool == true)
        {
            StartCoroutine(RollingDice());
        }
    }

    //Laat zien wat je gerolt hebt, delete de dice en herstart het script.
    IEnumerator RotatingDice()
    {
        yield return new WaitForSeconds(0.1f);
        if (hitDmg == 1 || enemyHitDmg == 1)
        {
            dice.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
        else if(hitDmg == 2 || enemyHitDmg == 2)
        {
            dice.transform.rotation = Quaternion.Euler(-90.0f, 0.0f, 0.0f);
        }
        else if (hitDmg == 3 || enemyHitDmg == 3)
        {
            dice.transform.rotation = Quaternion.Euler(180.0f, 90.0f, 90.0f);
        }
        else if (hitDmg == 4 || enemyHitDmg == 4)
        {
            dice.transform.rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
        }
        else if (hitDmg == 5 || enemyHitDmg == 5)
        {
            dice.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        }
        else if (hitDmg == 6 || enemyHitDmg == 6)
        {
            dice.transform.rotation = Quaternion.Euler(0.0f, 90.0f, 180.0f);
        }

        if (enemyIsPlaying == false)
        {
            enemyIsPlaying = true;
            yield return new WaitForSeconds(2);
            Destroy(dice.gameObject);
            timesRolled++;
            rollBool1 = false;
        }
    }


    IEnumerator LetEnemyPlay()
    {
        yield return new WaitForSeconds(5);
        Instantiate(prefabDice, new Vector3(enemyPirate[whichPirate].transform.position.x, enemyPirate[whichPirate].transform.position.y + 4, enemyPirate[whichPirate].transform.position.z), Quaternion.identity);
        dice = GameObject.FindGameObjectWithTag("DobbelSteen");

        yield return new WaitForSeconds(0.5f);

        dice.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        yield return new WaitForSeconds(0.2f);
  
        dice.transform.rotation = Quaternion.Euler(-90.0f, 0.0f, 0.0f);
        yield return new WaitForSeconds(0.2f);

        dice.transform.rotation = Quaternion.Euler(180.0f, 90.0f, 90.0f);
        yield return new WaitForSeconds(0.2f);
     
        dice.transform.rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
        yield return new WaitForSeconds(0.2f);
      
        dice.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        yield return new WaitForSeconds(0.2f);
        
       
        dice.transform.rotation = Quaternion.Euler(0.0f, 90.0f, 180.0f);
        yield return new WaitForSeconds(0.2f);

        enemyHitDmg = Random.Range(1, 7);
        enemyPirate[whichPirate].GetComponent<Rigidbody>().AddForce(Vector3.up * 500); ;
        StartCoroutine(RotatingDice());
        yield return new WaitForSeconds(2);
        Destroy(dice.gameObject);
        antiRepeatEP = false;
        enemyIsPlaying = false;
    }
}
