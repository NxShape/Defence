using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Buildings;
using UnityEngine.UI;

public class MenuUI : WindowsSingleton<MenuUI>
{
	/// <summary>
	/// Заголовок здания
	/// </summary>
	public Text TitleText;
	
	/// <summary>
	/// Открыть окно
	/// </summary>
	/// <param name="building">Building.</param>
	public void Open(BuildingBase building)
	{
		TitleText.text = building.Title;

		Open();
	}

	/// <summary>
	/// Закрыть окно
	/// </summary>
	public void Close()
	{
		Hide();
	}
}
