using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : WindowsSingleton<PopupManager>
{
	/// <summary>
	/// Открытые попаппы
	/// </summary>
	public List<IPopup> OpenedPopup;
	
	/// <summary>
	/// Попап сообщения
	/// </summary>
	public GameObject MessagePopup;

	/// <summary>
	/// Попап для починки здания
	/// </summary>
	public GameObject FixBuildingPopup;

	void Start()
	{
		OpenedPopup = new List<IPopup>();
	}

	/// <summary>
	/// Открыть попап сообщения
	/// </summary>
	public void OpenMessagePopup(string title, string message)
	{
		IPopup popup = Instantiate(MessagePopup, Root.transform).GetComponent<IPopup>();
	
		if (popup == null)
			return;

		popup.Open(new Hashtable
			{
				{ "title", title },
				{ "message", message }
			});

		OpenedPopup.Add(popup);
	}

	/// <summary>
	/// Открыть попап для починки здания
	/// </summary>
	public void OpenFixBuildingPopup(BuildingBase building)
	{
		IPopup popup = Instantiate(FixBuildingPopup, Root.transform).GetComponent<IPopup>();

		if (popup == null)
			return;

		popup.Open(new Hashtable
			{
				{ "title", "Здание" },
				{ "message", "Здание требует ремонта" },
				{ "building", building }
			});

		OpenedPopup.Add(popup);
	}

	/// <summary>
	/// Удалить попап
	/// </summary>
	/// <param name="popup">Popup.</param>
	public void Remove(IPopup popup)
	{
		OpenedPopup.Remove(popup);
	}
}
