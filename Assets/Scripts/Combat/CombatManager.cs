using AFSInterview.Units;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace AFSInterview.Combat
{
    public class CombatManager : MonoBehaviour
    {
        [Header("Armies")]
        [SerializeField] private UnitsFactory unitsFactory;
        [SerializeField] private List<Unit> army_1 = new List<Unit>();
        [SerializeField] private List<Unit> army_2 = new List<Unit>();

        [Header("Armies Turns")]
        [SerializeField] private bool isArmy1_Start = false;
        [SerializeField] private int armyNumberTurn = 0;

        [Header("UI")]
        [SerializeField] private TextMeshProUGUI combatTurnText;

        private void Initialize()
        {
            unitsFactory = FindFirstObjectByType<UnitsFactory>();
            combatTurnText = GameObject.Find("CombatTurnText").GetComponent<TextMeshProUGUI>();

            Unit.OnUnitDead += SetArmy1_State;
            Unit.OnUnitDead += SetArmy2_State;
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
            StartCombat();
        }

        private void SetArmy1_State(Unit unit)
        {
            if (army_1.Contains(unit)){
                army_1.Remove(unit);
            }
        }

        private void SetArmy2_State(Unit unit)
        {
            if (army_2.Contains(unit))
            {
                army_2.Remove(unit);
            }
        }

        private void StartCombat()
        {
            isArmy1_Start = CheckArmy1_Start();

            if(isArmy1_Start)
            {
                armyNumberTurn = 1;
                StartCoroutine(ArmyTurn(army_1, army_2));
                combatTurnText.text = "Current Turn: Left Army";
            }
            else
            {
                armyNumberTurn = 2;
                StartCoroutine(ArmyTurn(army_2, army_1));
                combatTurnText.text = "Current Turn: Right Army";
            }

        }

        private void CheckResults()
        {
            if(army_1.Count > 0 && army_2.Count > 0)
            {
                NextRound();
            }
            else
            {
                combatTurnText.text = "End Combat";
            }
        }

        private void NextRound()
        {
            if (armyNumberTurn == 1)
            {
                armyNumberTurn = 2;
                StartCoroutine(ArmyTurn(army_2, army_1));
                combatTurnText.text = "Current Turn: Right Army";
            }
            else if(armyNumberTurn == 2)
            {
                armyNumberTurn = 1;
                StartCoroutine(ArmyTurn(army_1, army_2));
                combatTurnText.text = "Current Turn: Left Army";
            }
        }

        private IEnumerator ArmyTurn(List<Unit> army, List<Unit> armyOpponent)
        {
            foreach (Unit unit in army)
            {
                int AttackCount = unit.AttackInterwval;

                for(int i = 0; i < AttackCount; i++)
                {
                    if(armyOpponent.Count > 0)
                    {
                        unit.Attack(SelectRandomUnitOpponent(armyOpponent));
                        yield return new WaitForSeconds(1);
                    }
                    else
                    {
                        break;
                    }
                    
                } 
            }

            CheckResults();

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
