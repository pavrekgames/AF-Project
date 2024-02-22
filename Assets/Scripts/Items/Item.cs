namespace AFSInterview.Items
{
	using System;
	using UnityEngine;

	[Serializable]
	public class Item: IUsableItem
	{
		[SerializeField] protected string name;
		[SerializeField] protected int value;

		public string Name => name;
		public int Value => value;

		public Item(string name, int value)
		{
			this.name = name;
			this.value = value;
		}

		public virtual void Use()
		{
			Debug.Log("Using" + Name);
		}
	}
}