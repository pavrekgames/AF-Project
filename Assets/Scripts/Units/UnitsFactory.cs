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

    }
}
