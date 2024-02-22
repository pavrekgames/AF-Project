namespace AFSInterview.Items
{
    using System.Collections.Generic;
    using UnityEngine;

    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private List<Item> items;
        [SerializeField] private int money;

        public int Money => money;
        public int ItemsCount => items.Count;

        public void SellAllItemsUpToValue(int maxValue)
        {
            int itemsValue = 0;
            List<Item> itemsToRemove = new List<Item>();

            for (var i = 0; i < items.Count; i++)
            {
                if (itemsValue < maxValue)
                {
                    itemsValue += items[i].Value;

                    if (itemsValue <= maxValue)
                    {
                        money += items[i].Value;
                        itemsToRemove.Add(items[i]);
                        continue;
                    }
                    else
                    {
                        itemsValue -= items[i].Value;
                        continue;
                    }
                }
                else
                {
                    break;
                }
            }

            RemoveItemsUpToValue(items, itemsToRemove);
        }

        private void RemoveItemsUpToValue(List<Item> items, List<Item> itemsToRemove)
        {
            foreach (var item in itemsToRemove)
            {
                items.Remove(item);
            }
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }
    }
}