using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHANGE_THE_NAME
{
    public class SceneAutoSwitch : MonoBehaviour
    {
        [SerializeField] bool disable;

        void Awake()
        {
            if (disable)
                return;

            if (FindObjectOfType<AppServices>() != null)
                Destroy(gameObject);
            else
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);

        }
    }
}