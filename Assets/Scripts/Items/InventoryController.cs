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

        public delegate void MoneyDelegate(int money);
        public static event MoneyDelegate OnSoldItemsUpToValue;
        public static event MoneyDelegate OnCollectedMoney;

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
            OnSoldItemsUpToValue?.Invoke(money);
        }

        private void RemoveItemsUpToValue(List<Item> items, List<Item> itemsToRemove)
        {
            foreach (var item in itemsToRemove)
            {
                items.Remove(item);
            }
        }

        public void UseAllItems()
        {
            foreach(var item in items)
            {
                item.Use();
            }
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void AddMoney(int money)
        {
            this.money += money;

            OnCollectedMoney?.Invoke(this.money);
        }
    }
}