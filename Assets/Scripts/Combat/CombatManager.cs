using AFSInterview.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Combat
{
    public class CombatManager : MonoBehaviour
    {
        [SerializeField] private UnitsFactory unitsFactory;
        [SerializeField] private List<Unit> army_1 = new List<Unit>();
        [SerializeField] private List<Unit> army_2 = new List<Unit>();

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

        public void SetArmy_1(List<Unit> army)
        {
            army_1 = army;
        }

        public void SetArmy_2(List<Unit> army)
        {
            army_2 = army;
        }

    }
}
