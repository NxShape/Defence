using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Buildings
{
	public class TownHallBuilding : BuildingBase, IPointerClickHandler
	{
		/// <summary>
		/// Текущее выбранное здание
		/// </summary>
		static public BuildingBase SelectedBuilding;

		public void OnPointerClick(PointerEventData eventData)
		{
			SelectedBuilding = this;

			MenuUI.Instance.Open(this);
		}
	}
}