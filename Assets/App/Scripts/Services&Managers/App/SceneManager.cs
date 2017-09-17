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
        public delegate void SceneChange(Scenes newScene, Scenes oldScene);
        public event SceneChange OnSceneChanged;

        public Scenes scene = Scenes.prescene;
        public Scenes CurrentScene
        {
            get
            {
                return scene;
            }
        }

        public void Initialize()
        {
            Debug.Console.Add("map" , this, "LoadSceneConsole");
            Debug.Console.Add("maps", this, "ListAllScenes");
        }

        public void LoadSceneConsole(string name)
        {
            LoadScene(name);
        }

        public void LoadScene(string name)
        {
            Scenes newScene = Scenes.none;
            Enum.TryParse(name, out newScene);

            if (newScene != Scenes.none)
            {
                var old = scene;
                
                SM.SceneManager.LoadScene(name);

                if (OnSceneChanged != null)
                    OnSceneChanged.Invoke(newScene, old);
            }
            else
            {
                Debug.Console.PrintErrorMessage("Uknown scene " + name + "!");
            }
        }

        public void LoadScene(Scenes s)
        {
            if (s != Scenes.none)
            {
                var old = scene;

                SM.SceneManager.LoadScene(s.ToString());

                if (OnSceneChanged != null)
                    OnSceneChanged.Invoke(s, old);
            }
            else
            {
                Debug.Console.PrintErrorMessage("Uknown scene " + s + "!");
            }
        }
        public void LoadScene(int i)
        {
            i = Mathf.Clamp(i, 0, Enum.GetValues(typeof(Scenes)).Length - 1);
            LoadScene((Scenes)i);
        }

        public void ListAllScenes()
        {

            int max = Enum.GetValues(typeof(Scenes)).Length;
            Debug.Console.WriteLine(" - All maps - ");
            Debug.Console.WriteLine("Name");
            Debug.Console.WriteLine(@"----------------------------------------------");
            for (int i = 1; i < max; i++)
            {
                Debug.Console.WriteLine(((Scenes)i).ToString());
            }
            Debug.Console.WriteLine(@"----------------------------------------------");
            Debug.Console.WriteLine("");
        }
    }
}