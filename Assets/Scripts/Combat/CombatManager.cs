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

        [SerializeField] private bool isArmy1_Start = false;
        [SerializeField] private int armyNumberTurn = 0;

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

        private void StartCombat()
        {
            isArmy1_Start = CheckArmy1_Start();

            if(isArmy1_Start)
            {
                armyNumberTurn = 1;
                StartCoroutine(ArmyTurn(army_1, army_2));
            }
            else
            {
                armyNumberTurn = 2;
                StartCoroutine(ArmyTurn(army_2, army_1));
            }

        }

        private IEnumerator ArmyTurn(List<Unit> army, List<Unit> armyOpponent)
        {
            foreach (Unit unit in army)
            {
                int AttackCount = unit.AttackInterwval;

                for(int i = 0; i < AttackCount; i++)
                {
                    unit.Attack(SelectRandomUnitOpponent(armyOpponent));
                    yield return new WaitForSeconds(1);
                } 
            }
        }

        private Unit SelectRandomUnitOpponent(List<Unit> army)
        {
            int index = Random.Range(0, army.Count);
            
            return army[index];
        }

        private bool CheckArmy1_Start()
        {
            int state = Random.Range(0, 2);
            
            if(state == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
