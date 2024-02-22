namespace AFSInterview.Items
{
    using TMPro;
    using UnityEngine;

    public class ItemsManager : MonoBehaviour
    {
        [SerializeField] private InventoryController inventoryController;
        [SerializeField] private int itemSellMaxValue;
        [SerializeField] private Transform itemSpawnParent;
        [SerializeField] private GameObject itemPrefab;
        [SerializeField] private BoxCollider itemSpawnArea;
        [SerializeField] private float itemSpawnInterval;

        [Header("Camera Ray")]
        private Camera mainCamera;
        private LayerMask layerMask;

        [Header("UI")]
        private TextMeshProUGUI moneyText;

        private void Initialize()
        {
            mainCamera = Camera.main;
            layerMask = LayerMask.GetMask("Item");
            moneyText = FindObjectOfType<TextMeshProUGUI>();

            InventoryController.OnSoldItemsUpToValue += UpdateMoneyText;
            InventoryController.OnCollectedMoney += UpdateMoneyText;
            moneyText.text = "Money: " + inventoryController.Money;
        }

        private void Start()
        {
            Initialize();

            InvokeRepeating("SpawnNewItem", 0, itemSpawnInterval);
        }

        private void Update()
        {
            TryPickUpIemInput();
            SellAllItemsUpToValueInput();
            UseItemsInput();
        }

        private void SpawnNewItem()
        {
            var spawnAreaBounds = itemSpawnArea.bounds;
            var position = new Vector3(
                Random.Range(spawnAreaBounds.min.x, spawnAreaBounds.max.x),
                0f,
                Random.Range(spawnAreaBounds.min.z, spawnAreaBounds.max.z)
            );

            Instantiate(itemPrefab, position, Quaternion.identity, itemSpawnParent);
        }

        private void TryPickUpItem()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out var hit, 100f, layerMask) || !hit.collider.TryGetComponent<IItemHolder>(out var itemHolder))
                return;

            var item = itemHolder.GetItem(true);
            inventoryController.AddItem(item);
            Debug.Log("Picked up " + item.Name + " with value of " + item.Value + " and now have " + inventoryController.ItemsCount + " items");
        }

        #region Inputs

        private void TryPickUpIemInput()
        {
            if (Input.GetMouseButtonDown(0))
                TryPickUpItem();
        }

        private void SellAllItemsUpToValueInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                inventoryController.SellAllItemsUpToValue(itemSellMaxValue);
                
            }
        }

        private void UseItemsInput()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                inventoryController.UseAllItems();
            }
        }

        #endregion

        #region UI

        private void UpdateMoneyText(int money)
        {
            moneyText.text = "Money: " + money;
        }

        #endregion
    }
}