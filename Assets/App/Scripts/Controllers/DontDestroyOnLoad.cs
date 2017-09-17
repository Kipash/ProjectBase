using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    [SerializeField] bool disable;
	
	void Awake ()
    {
        if (!disable)
            DontDestroyOnLoad(gameObject);
	}
}
