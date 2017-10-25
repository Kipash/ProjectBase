using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHANGE_THE_NAME
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float speed;
        void Update()
        {
            if (AppServices.Instance.AppInput.GetKey(Key.MoveLeft, KeyState.Press))
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (AppServices.Instance.AppInput.GetKey(Key.MoveRight, KeyState.Press))
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (AppServices.Instance.AppInput.GetKey(Key.MoveUp, KeyState.Press))
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            if (AppServices.Instance.AppInput.GetKey(Key.MoveDown, KeyState.Press))
            {
                transform.position += Vector3.down * speed * Time.deltaTime;

            }
        }
    }
}