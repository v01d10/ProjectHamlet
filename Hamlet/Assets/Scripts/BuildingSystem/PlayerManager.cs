using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using EP.H.InputManager;

namespace EP.H.Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager instance;

        void Start()
        {
            instance = this;
        }

        void Update()
        {
            InputHandler.instance.HandleUnitMovement();
        }
    }
}

