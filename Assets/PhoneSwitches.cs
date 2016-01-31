using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class PhoneSwitches : MonoBehaviour
{
    GuitarSwitch[] guitarSwitches;
    public Phone phone;
    private bool[] switchesShouldBeOn;

    void Start()
    {
        guitarSwitches = GetComponentsInChildren<GuitarSwitch>();
        switchesShouldBeOn = new bool[guitarSwitches.Length];
        List<int> numRange = Enumerable.Range(0, guitarSwitches.Length).ToList();
        for (int i = 0; i < 3; i++)
        {
            int switchShouldBeOn = Random.Range(0, numRange.Count);
            switchesShouldBeOn[numRange[switchShouldBeOn]] = true;
            numRange.RemoveAt(switchShouldBeOn);
        }

        /*
        print("Switches should be on: ");
        foreach (bool shouldBe in switchesShouldBeOn)
        {
            print(shouldBe + ", ");
        }
        */
    }

    void Update()
    {
        phone.phoneRinging = true;
        for(int i = 0; i < guitarSwitches.Length; i++)
        {
            if (guitarSwitches[i].switchOn != switchesShouldBeOn[i])
            {
                phone.phoneRinging = false;
            }
        }
    }
}
