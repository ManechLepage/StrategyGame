using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllScenes : MonoBehaviour
{
    void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}
