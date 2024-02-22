using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Items
{
    [Serializable]
    public class BagGoldPresenter : MonoBehaviour, IItemHolder
    {
        [SerializeField] private BagGold item;

        public Item GetItem(bool disposeHolder)
        {
            if (disposeHolder)
                Destroy(gameObject);

            return item;
        }
    }
}
