using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EP.H.Player.Units
{
    [CreateAssetMenu(fileName = "New Unity", menuName = "Create New Unit")]
    public class Unit : ScriptableObject
    {
        public enum unitType
        {
            Worker,
            Guard,
            Healer
        };

        public bool isPlayerUnit;

        public unitType type;

        public string unitName;

        public GameObject unitPrefab;

        public float cost;
        public float attack;
        public float health;
        public float armor;
    }   
}

