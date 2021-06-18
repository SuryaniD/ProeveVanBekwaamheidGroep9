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

    private bool setAmmoSoundOff = false;

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
        //(U can use the dice as many times as u splett a pirate in normal game)
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

        //when killed last pirate gives ammo to bomb and plays reload sound
        if (newSQPirateKills == 4 && setAmmoSoundOff == false)
        {
            setAmmoSoundOff = true;
            questPlayer.transform.Find("GiveAmmoSound").gameObject.GetComponent<AudioSource>().Play();
            ammoManager.ammo = ammoManager.ammo + 5;
        }

        //If get input Up spawn and start rolling dice(coroutine)
        if (Input.GetKeyDown(KeyCode.UpArrow) && rollBool1 == false && throwScore >= 1 && enemyIsPlaying == false)
        {
            rollBool1 = true;
            throwScore--;
            Instantiate(prefabDice, new Vector3(questPlayer.transform.position.x, questPlayer.transform.position.y + 4,questPlayer.transform.position.z), Quaternion.identity);
            rollingDiceBool = true;
            dice = GameObject.FindGameObjectWithTag("DobbelSteen");
            dice.transform.Find("RollingSound").gameObject.GetComponent<AudioSource>().loop = true;
            dice.transform.Find("RollingSound").gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(RollingDice());
            StartCoroutine(RrollBool2SetTrue());
        }

        //If get input Up again Jump and get number on dice
        if (Input.GetKeyDown(KeyCode.UpArrow) && rollBool2 == true)
        {
            rollBool2 = false;
            rollingDiceBool = false;
            questPlayer.transform.Find("JumpSound").gameObject.GetComponent<AudioSource>().Play();
            rb.AddForce(Vector3.up * 500);
            hitDmg = Random.Range(1,7);
            StartCoroutine(ChosenDice());
        }

        //Lets enemy play after player played
        if (enemyIsPlaying == true && antiRepeatEP == false)
        {
            antiRepeatEP = true;
            StartCoroutine(LetEnemyPlay());
        }

    }

    //waits 0.2 seconds before jump input can be given (player)
    IEnumerator RrollBool2SetTrue()
    {
        yield return new WaitForSeconds(0.2f);
        rollBool2 = true;
    }

    IEnumerator RollingDice()
    {
        //Starts rolling the dice
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

    //Shows whats rolled, Deletes dice and lets other play.
    IEnumerator ChosenDice()
    {
        yield return new WaitForSeconds(0.4f);
        dice.transform.Find("RollingSound").gameObject.GetComponent<AudioSource>().Stop();
        if (hitDmg == 1 || enemyHitDmg == 1)
        {
            dice.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
        if(hitDmg == 2 || enemyHitDmg == 2)
        {
            dice.transform.rotation = Quaternion.Euler(-90.0f, 0.0f, 0.0f);
        }
        if (hitDmg == 3 || enemyHitDmg == 3)
        {
            dice.transform.rotation = Quaternion.Euler(180.0f, 90.0f, 90.0f);
        }
        if (hitDmg == 4 || enemyHitDmg == 4)
        {
            dice.transform.rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
        }
        if (hitDmg == 5 || enemyHitDmg == 5)
        {
            dice.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        }
        if (hitDmg == 6 || enemyHitDmg == 6)
        {
            dice.transform.rotation = Quaternion.Euler(0.0f, 90.0f, 180.0f);
        }

        dice.transform.Find("ChosenSound").gameObject.GetComponent<AudioSource>().Play();

        if (enemyIsPlaying == false)
        {
            enemyIsPlaying = true;
            yield return new WaitForSeconds(2);
            Destroy(dice.gameObject);
            timesRolled++;
            rollBool1 = false;
        }
        
    }

    //Lets enemy roll without input Goes to show roll and lets player go roll next
    IEnumerator LetEnemyPlay()
    {
        yield return new WaitForSeconds(4);
        Instantiate(prefabDice, new Vector3(enemyPirate[whichPirate].transform.position.x, enemyPirate[whichPirate].transform.position.y + 4, enemyPirate[whichPirate].transform.position.z), Quaternion.identity);
        dice = GameObject.FindGameObjectWithTag("DobbelSteen");

        yield return new WaitForSeconds(0.5f);
        dice.transform.Find("RollingSound").gameObject.GetComponent<AudioSource>().loop = true;
        dice.transform.Find("RollingSound").gameObject.GetComponent<AudioSource>().Play();

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
        StartCoroutine(ChosenDice());
        yield return new WaitForSeconds(2);
        Destroy(dice.gameObject);
        antiRepeatEP = false;
        enemyIsPlaying = false;
    }
}
