﻿using UnityEngine;
using System.Collections;
using AppBackend;

namespace CHANGE_THE_NAME
{
    public class ConsoleVariables
    {
        //public string UserName { get; set; }

        public string UserDataPath
        {
            get
            {
                return AppServices.Instance.fileConfig.UserDataPath;
            }
        }

        public string UserName
        {
            get
            {
                return DataStorage.UserData.UserName;
            }
            set
            {
                DataStorage.UserData.UserName = value;
                DataStorage.SaveUserData();
            }
        }
    }
}