using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPopup
{
	/// <summary>
	/// Открыть попап с данными
	/// </summary>
	void Open(Hashtable data);

	/// <summary>
	/// Закрыть
	/// </summary>
	void Close();
}
