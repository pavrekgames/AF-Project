using AFSInterview.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Combat
{
    public class CombatManager : MonoBehaviour
    {
        [SerializeField] private UnitsFactory unitsFactory;


        private void Initialize()
        {
            unitsFactory = FindFirstObjectByType<UnitsFactory>();
        }

        private void Start()
        {
            Initialize();
            CreateArmies();
        }

        private void CreateArmies()
        {
            Debug.Log("CreateArmies");
            unitsFactory.CreateArmy_1();
            unitsFactory.CreateArmy_2();
        }

    }
}
