using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Gas;
    public GameObject Stopper;
    public GameObject Money;
    public GameObject[] Drops;

    // Start is called before the first frame update
    void Start()
    {
        int value = Random.Range(1, 4);
        foreach (GameObject Con in Drops)
        {
            if (value == 1)
            {
                Instantiate(Gas, Con.transform.position, Quaternion.Euler(0, 0, 0));
                value = Random.Range(2, 4);
                continue;
            }
            if (value == 2)
            {
                Instantiate(Stopper, Con.transform.position, Quaternion.Euler(0, 0, 0));
                value = Random.Range(1, 3);
                if (value == 1)
                    value = 1;
                if (value == 2)
                    value = 3;
                continue;
            }
            if (value == 3)
            { 
                Instantiate(Money, Con.transform.position, Quaternion.Euler(0, 0, 0));
                value = Random.Range(1, 3);
                continue;
            }

        }
    }
}

