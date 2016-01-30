using UnityEngine;
using System.Collections;

public class PhoneSwitches : MonoBehaviour
{
    GuitarSwitch[] guitarSwitches;
    public Phone phone;

    void Start()
    {
        guitarSwitches = GetComponentsInChildren<GuitarSwitch>();
    }

    void Update()
    {
        phone.phoneRinging = guitarSwitches[0].switchOn && !guitarSwitches[1].switchOn && guitarSwitches[2].switchOn;
    }
}
