using UnityEngine;
using System.Collections;

public class NoDelete : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
