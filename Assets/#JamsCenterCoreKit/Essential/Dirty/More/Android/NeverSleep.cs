using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeverSleep : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
	
}
