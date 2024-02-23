using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Units
{
    public class Catapult : Unit
    {
        [SerializeField] private UnitAttribute damagleLightAttribute;
        [SerializeField] private UnitAttribute damagleMechanicAttribute;

        public override void Attack(Unit unit)
        {
            List<UnitAttribute> attributes = unit.GetAttributes();

            if (attributes.Contains(damagleLightAttribute) || attributes.Contains(damagleMechanicAttribute))
            {
                int finalDamage = attackDamage;
                finalDamage += optionalAttackDamage;
                Debug.Log(this.name + " Attacks " + unit.name + " with damage ");
                Debug.Log("Optional damage: " + optionalAttackDamage);
                unit.ReceiveDamage(finalDamage);
            }
            else
            {
                unit.ReceiveDamage(attackDamage);
            }
        }
    }
}
