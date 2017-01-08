using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum EBuildingState
{
	NONE,
	ROOT,
	NEED_RESTORE
}

[System.Serializable]
public class BuildingState
{
	/// <summary>
	/// Главный обьект
	/// </summary>
	public GameObject Root;

	/// <summary>
	/// Тип состояния
	/// </summary>
	public EBuildingState Type;

	/// <summary>
	/// Описание
	/// </summary>
	public string Description;
}

public class BuildingBase : MonoBehaviour, IPointerClickHandler
{
	/// <summary>
	/// Текущее выбранное здание
	/// </summary>
	static public BuildingBase SelectedBuilding;

	/// <summary>
	/// Есть ли руководящий человек
	/// </summary>
	public bool IsHasPeople;

	/// <summary>
	/// Готово ли здание для заселения
	/// </summary>
	public bool IsNormalState;

	/// <summary>
	/// Построенные здания
	/// </summary>
	public List<BuildingState> ConstructedStates;

	/// <summary>
	/// Разрушенные части дома
	/// </summary>
	public List<BuildingState> RuinedStates;
	
	/// <summary>
	/// Заголовок
	/// </summary>
	public string Title;

	public virtual void Start()
	{
		RuinedStates[0].Root.SetActive(!IsNormalState);
		ConstructedStates[0].Root.SetActive(IsNormalState);
	}

	/// <summary>
	/// Есть ли требование для работы
	/// </summary>
	public bool HasRuinedStates()
	{
		for(int i = 0; i < RuinedStates.Count; i++)
		{
			if(RuinedStates[i].Type == EBuildingState.NONE || RuinedStates[i].Type == EBuildingState.ROOT) 
				continue;
			
			if(RuinedStates[i].Root.activeSelf)
				return true;
		}

		return false;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		SelectedBuilding = this;

		if(!IsNormalState)
			PopupManager.Instance.OpenFixBuildingPopup(SelectedBuilding);
		else if (!IsHasPeople)
			PopupManager.Instance.OpenMessagePopup("Пустое здание", "Здание не имеет руководителя");
		else
			MenuUI.Instance.Open(this);
	}
}