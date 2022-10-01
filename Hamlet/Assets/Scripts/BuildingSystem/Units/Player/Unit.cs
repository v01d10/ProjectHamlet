using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EP.H.Units
{
    [CreateAssetMenu(fileName = "New Unity", menuName = "New Unit/Basic")]
    public class BasicUnit : ScriptableObject
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

        public GameObject workerPrefab;
        public GameObject guardPrefab;
        public GameObject healerPrefab;

        public float cost;
        public float attack;
        public float health;
        public float armor;
    }   
}

