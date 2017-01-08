using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DataSlot : MonoBehaviour 
{
	/// <summary>
	/// Заголовок
	/// </summary>
	public Text TitleText;

	/// <summary>
	/// Число для контроля
	/// </summary>
	public int Number;

	/// <summary>
	/// Событие по выбору
	/// </summary>
	public Action SelectAction;

	/// <summary>
	/// Выбор
	/// </summary>
	public void Select()
	{
		if(SelectAction != null)
			SelectAction();
	}
}
