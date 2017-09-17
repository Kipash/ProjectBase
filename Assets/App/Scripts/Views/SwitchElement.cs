using UnityEngine;
using System.Collections;

namespace CHANGE_THE_NAME
{
    public class SwitchElement : MonoBehaviour
    {
        public SwitchManager Manager;
        public void Active()
        {
            Manager.Interact(this);
        }
    }
}