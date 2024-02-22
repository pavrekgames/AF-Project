using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Units
{
    public class Catapult : Unit
    {
        [SerializeField] private UnitAttribute damagleLightAttribute;
        [SerializeField] private UnitAttribute damagleMechanicAttribute;

        public override void Attack(Unit unit, int damage)
        {
            List<UnitAttribute> attributes = unit.GetAttributes();

            if (attributes.Contains(damagleLightAttribute) || attributes.Contains(damagleMechanicAttribute))
            {
                damage += optionalAttackDamage;
                unit.ReceiveDamage(damage);
            }
        }
    }
}
