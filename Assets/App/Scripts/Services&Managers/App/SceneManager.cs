using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using SM = UnityEngine.SceneManagement;
using System.Linq;

namespace CHANGE_THE_NAME
{
    [Serializable]
    public class SceneManager
    {
        [SerializeField] List<Scenes> scenes;

        public delegate void SceneChange(Scenes newScene, Scenes oldScene);
        public event SceneChange OnSceneChanged;

        public Scenes scene = Scenes.PreScene;
        public Scenes CurrentScene
        {
            get
            {
                return scene;
            }
        }

        public void LoadScene(Scenes s)
        {
            var old = scene;
            scene = s;
            SM.SceneManager.LoadScene(s.ToString());

            if (OnSceneChanged != null)
                OnSceneChanged.Invoke(s, old);
        }
        public void LoadScene(int i)
        {
            i = Mathf.Clamp(i, 0, Enum.GetValues(typeof(Scenes)).Length - 1);
        }
    }
}