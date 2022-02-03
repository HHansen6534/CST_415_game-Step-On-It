using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public GameObject UI;
    public GameObject UI2;
    public Text Money;
    public Text GasLeft;
    public GameObject[] Copss;
    public float Gas = 100;
    public float GasFill = 10;

    private int money = 0;


    private void Update()
    {
        GasLeft.text = Mathf.RoundToInt(Gas).ToString();
        if (Gas <= 0)
        {
            gameObject.GetComponent<VehicleControl>().enabled = false;
        } else
        {
            Gas -= 1 * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Hospital")
        {
            UI.SetActive(true);
            Time.timeScale = 0;
        }
        if (col.gameObject.tag == "Cops")
        {
            UI2.SetActive(true);
            Time.timeScale = 0;
            
        }
        if (col.gameObject.tag == "Gas")
        {
            Gas += GasFill;
            Destroy(col.gameObject);
            
        }
        if (col.gameObject.tag == "Money")
        {
            money = money + 100;
            Money.text = "Money: $" + money;
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "Stopper")
        {
            Destroy(col.gameObject);
            foreach (GameObject cop in Copss)
            {
                cop.GetComponent<NavMeshAgent>().enabled = false;
            }
            StartCoroutine(waiter());
            
            

        }
    }
    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(5);
        foreach (GameObject cop in Copss)
        {
            cop.GetComponent<NavMeshAgent>().enabled = enabled;
        }
        Debug.Log("Restarting");
    }
}
