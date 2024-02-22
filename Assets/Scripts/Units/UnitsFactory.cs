using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Units
{
    public class UnitsFactory : MonoBehaviour
    {
        [SerializeField] private GameObject[] units;

        [Header("Army Left Side")]
        [SerializeField] private Transform armyLeftSpawnParent;
        [SerializeField] private BoxCollider armyLeftSpawnArea;

        [Header("Army Right Size")]
        [SerializeField] private Transform armyRightSpawnParent;
        [SerializeField] private BoxCollider armyRightSpawnArea;

        #region Consts

        private const int LONG_SWORD_KNIGHT = 0;
        private const int ARCHER = 1;
        private const int DRUID = 2;
        private const int CATAPULT = 3;
        private const int RAM = 4;

        #endregion

        private void SpawnUnit(int unitIndex, Transform parent, BoxCollider spawnArea)
        {
            var spawnAreaBounds = spawnArea.bounds;
            var position = new Vector3(
                Random.Range(spawnAreaBounds.min.x, spawnAreaBounds.max.x),
                0f,
                Random.Range(spawnAreaBounds.min.z, spawnAreaBounds.max.z)
            );

            Instantiate(units[unitIndex], position, Quaternion.identity, parent);
        }

        public void CreateArmy_1()
        {
            SpawnUnit(LONG_SWORD_KNIGHT, armyLeftSpawnParent, armyLeftSpawnArea);
            SpawnUnit(LONG_SWORD_KNIGHT, armyLeftSpawnParent, armyLeftSpawnArea);
            SpawnUnit(DRUID, armyLeftSpawnParent, armyLeftSpawnArea);
            SpawnUnit(RAM, armyLeftSpawnParent, armyLeftSpawnArea);
        }

        public void CreateArmy_2()
        {
            SpawnUnit(ARCHER, armyRightSpawnParent, armyRightSpawnArea);
            SpawnUnit(ARCHER, armyRightSpawnParent, armyRightSpawnArea);
            SpawnUnit(ARCHER, armyRightSpawnParent, armyRightSpawnArea);
            SpawnUnit(CATAPULT, armyRightSpawnParent, armyRightSpawnArea);
            SpawnUnit(RAM, armyRightSpawnParent, armyRightSpawnArea);
        }


    }
}
