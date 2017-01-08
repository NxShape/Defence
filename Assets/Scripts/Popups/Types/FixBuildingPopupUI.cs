using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixBuildingPopupUI : MonoBehaviour, IPopup
{
	/// <summary>
	/// Заголовок
	/// </summary>
	public Text TitleText;

	/// <summary>
	/// Сообщение
	/// </summary>
	public Text MessageText;

	/// <summary>
	/// Данные о здании
	/// </summary>
	public BuildingBase Data;

	/// <summary>
	/// Родитель для создания
	/// </summary>
	public Transform SlotParent;

	/// <summary>
	/// Префаб
	/// </summary>
	public GameObject SlotPrefab;

	/// <summary>
	/// Созданные слоты
	/// </summary>
	public List<GameObject> CreatedSlots;
	
	/// <summary>
	/// Открыть попап с данными
	/// </summary>
	/// <param name="data">Data.</param>
	public void Open(Hashtable data)
	{
		TitleText.text = data["title"].ToString();
		MessageText.text = data["message"].ToString();

		Data = (BuildingBase)data["building"];

		UpdatePopup();
	}

	void UpdatePopup()
	{
		for(int i = 0; i < CreatedSlots.Count; i++)
			Destroy(CreatedSlots[i]);
		CreatedSlots = new List<GameObject>();

		if(Data.HasRuinedStates())
		{
			for(int i = 0; i < Data.RuinedStates.Count; i++)
			{
				if(Data.RuinedStates[i].Type == EBuildingState.ROOT || Data.RuinedStates[i].Type == EBuildingState.NONE) 
					continue;
				
				if(!Data.RuinedStates[i].Root.activeSelf) 
					continue;

				GameObject obj = Instantiate(SlotPrefab, SlotParent);
				obj.SetActive(true);

				DataSlot slot = obj.GetComponent<DataSlot>();
				slot.TitleText.text = Data.RuinedStates[i].Description;
				slot.Number = i;
				slot.SelectAction = delegate
					{
						Data.RuinedStates[slot.Number].Root.SetActive(false);

						UpdatePopup();

						Close();
					};

				CreatedSlots.Add(obj);
			}
		}
		else
		{
			GameObject obj = Instantiate(SlotPrefab, SlotParent);
			obj.SetActive(true);

			DataSlot slot = obj.GetComponent<DataSlot>();
			slot.TitleText.text = "Восстановить здание";
			slot.SelectAction = delegate
				{
					Data.IsNormalState = true;
					Data.Start();

					Close();
				};

			CreatedSlots.Add(obj);
		}

		gameObject.SetActive(true);
	}

	/// <summary>
	/// Закрыть
	/// </summary>
	public void Close()
	{
		Destroy(gameObject);

		PopupManager.Instance.Remove(this);
	}
}
