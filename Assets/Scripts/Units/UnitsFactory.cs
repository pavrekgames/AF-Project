using AFSInterview.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Units
{
    public class UnitsFactory : MonoBehaviour
    {
        [SerializeField] private List<Unit> units = new List<Unit>();
        [SerializeField] private CombatManager combatManager;

        [Header("Army Left Side")]
        [SerializeField] private List<Unit> armyLeftUnits = new List<Unit>();
        [SerializeField] private Transform armyLeftSpawnParent;
        [SerializeField] private BoxCollider armyLeftSpawnArea;

        [Header("Army Right Size")]
        [SerializeField] private List<Unit> armyRightUnits = new List<Unit>();
        [SerializeField] private Transform armyRightSpawnParent;
        [SerializeField] private BoxCollider armyRightSpawnArea;

        #region Consts

        private const int LONG_SWORD_KNIGHT = 0;
        private const int ARCHER = 1;
        private const int DRUID = 2;
        private const int CATAPULT = 3;
        private const int RAM = 4;

        #endregion

        private void Initialize()
        {
            combatManager = FindFirstObjectByType<CombatManager>();
        }

        private void Start()
        {
            Initialize();
        }

        private void SpawnUnit(int unitIndex, Transform parent, BoxCollider spawnArea, List<Unit> army)
        {
            var spawnAreaBounds = spawnArea.bounds;
            var position = new Vector3(
                Random.Range(spawnAreaBounds.min.x, spawnAreaBounds.max.x),
                0f,
                Random.Range(spawnAreaBounds.min.z, spawnAreaBounds.max.z)
            );

            army.Add(units[unitIndex]);
            Instantiate(units[unitIndex].UnitPresenter, position, Quaternion.identity, parent);
        }

        public void CreateArmy_1()
        {
             SpawnUnit(LONG_SWORD_KNIGHT, armyLeftSpawnParent, armyLeftSpawnArea, armyLeftUnits);
             SpawnUnit(LONG_SWORD_KNIGHT, armyLeftSpawnParent, armyLeftSpawnArea, armyLeftUnits);
             SpawnUnit(DRUID, armyLeftSpawnParent, armyLeftSpawnArea, armyLeftUnits);
             SpawnUnit(RAM, armyLeftSpawnParent, armyLeftSpawnArea, armyLeftUnits);

             combatManager.SetArmy_1(armyLeftUnits); 
        }

        public void CreateArmy_2()
        {
            SpawnUnit(ARCHER, armyRightSpawnParent, armyRightSpawnArea, armyRightUnits);
            SpawnUnit(ARCHER, armyRightSpawnParent, armyRightSpawnArea, armyRightUnits);
            SpawnUnit(ARCHER, armyRightSpawnParent, armyRightSpawnArea, armyRightUnits);
            SpawnUnit(CATAPULT, armyRightSpawnParent, armyRightSpawnArea, armyRightUnits);
            SpawnUnit(RAM, armyRightSpawnParent, armyRightSpawnArea, armyRightUnits);

            combatManager.SetArmy_2(armyRightUnits);
        }


    }
}
