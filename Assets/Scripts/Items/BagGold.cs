using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Items
{
    [Serializable]
    public class BagGold : Item
    {

        [SerializeField] private InventoryController inventoryController;

        public BagGold(string name, int value) : base(name, value)
        {
            this.name = name;
            this.value = value;
        } 

        public override void Use()
        {
            Debug.Log("Using" + Name);
            inventoryController.AddMoney(value);
        }

    }
}
