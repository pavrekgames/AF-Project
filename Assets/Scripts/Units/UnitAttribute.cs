using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Units
{
    [CreateAssetMenu(fileName = "Attribute", menuName = "Unit Attribute")]
    public class UnitAttribute : ScriptableObject
    {

        public enum UnitAttributes
        {
            Light,
            Armored,
            Mechanical
        }

        public UnitAttributes unitAttributes;

    }
}
