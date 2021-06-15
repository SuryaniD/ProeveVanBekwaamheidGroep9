using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DobbelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabDice;
    private GameObject dice;

    [SerializeField]
    private GameObject questPlayer;
    private Rigidbody rb;

    private bool rollBool1 = false;
    private bool rollBool2 = false;
    private bool rollingDiceBool = true;

    private int hitDmg;

    void Start()
    {
        rb = questPlayer.GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        //If get input Up spawn and start rolling dice
        if (Input.GetKeyDown(KeyCode.UpArrow) && rollBool1 == false)
        {
            rollBool1 = true;
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
            Debug.Log(hitDmg); 
            StartCoroutine(RotatingDice());
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
        if (hitDmg == 1)
        {
            dice.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
        else if(hitDmg == 2)
        {
            dice.transform.rotation = Quaternion.Euler(-90.0f, 0.0f, 0.0f);
        }
        else if (hitDmg == 3)
        {
            dice.transform.rotation = Quaternion.Euler(180.0f, 90.0f, 90.0f);
        }
        else if (hitDmg == 4)
        {
            dice.transform.rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
        }
        else if (hitDmg == 5)
        {
            dice.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        }
        else if (hitDmg == 6)
        {
            dice.transform.rotation = Quaternion.Euler(0.0f, 90.0f, 180.0f);
        }

        yield return new WaitForSeconds(2);
        Destroy(dice.gameObject);

        rollBool1 = false;
    }
}
