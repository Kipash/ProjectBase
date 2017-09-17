using System;
using System.Collections;
using System.Collections.Generic;
using AppBackend;
using System.Reflection;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[assembly:AssemblyVersion ("1.0.*")]
namespace CHANGE_THE_NAME
{
    public class AppServices : MonoBehaviour
    {
        static AppServices instance;
        public static AppServices Instance
        {
            get
            {
                return instance;
            }
        }

        [Header("- Data -")]
        public FileConfig fileConfig;

        [Header("- Services -")]
        public AppUIManager AppUI;
        public ConsoleInput ConsoleManger;
        public SceneManager SceneManager;
        public CVarManager cVarManager;
        public AppInput AppInput;

        [Header("- Settings -")]
        public bool DebugFeatures;

        static string version;
        public static string VersionNumber
        {
            get
            {
                if (string.IsNullOrEmpty(version))
                {
                    version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                }
                return version;
            }
        }

        void Awake()
        {
            var t = DateTime.Now;

            SetupInstance();
            InitializeBackend();
            InitializeServices();

            Debug.Console.AddStatic("v", typeof(AppServices), "OutputVersion");
            Debug.Console.AddStatic("version", typeof(AppServices), "OutputVersion");

            Debug.Console.AddStatic("quit", typeof(AppServices), "ForceQuit");
            Debug.Console.AddStatic("exit", typeof(AppServices), "ForceQuit");

            var diff = (DateTime.Now - t);
            Debug.Console.WriteLine(string.Format("All Game services loaded in {0} ms ({1} tics)", diff.TotalMilliseconds, diff.Ticks), true);
        }

        public static void OutputVersion()
        {
            Debug.Console.WriteLine(string.Format("Starting version {0}", VersionNumber));
        }

        public static void ForceQuit()
        {
            #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif

            Debug.Console.WriteLine(string.Format("Exiting version {0}", VersionNumber));

        }



        void Update()
        {
            ConsoleManger.Update();
            if(DebugFeatures)
            {
                AppUI.CurrentKeysText.text = Input.inputString;
            }
        }

        void SetupInstance()
        {
            if (instance == null)
                instance = this;
            else if (instance.gameObject != null)
            {
                Destroy(gameObject);
                throw new Exception("AppServices: multiple instances detected");
            }
            else
                instance = this;
        }

        void InitializeBackend()
        {
            DataStorage.Load(fileConfig);
        }
        void InitializeServices()
        {
            ConsoleManger.Initialize();

            AppUI.SetVersion(Application.platform + " " + VersionNumber);
            SceneManager.Initialize();
            cVarManager.Initialize();
            AppInput.Initialize();
        }
    }
}