using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePopupUI : MonoBehaviour, IPopup
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
	/// Открыть попап с данными
	/// </summary>
	/// <param name="data">Data.</param>
	public void Open(Hashtable data)
	{
		TitleText.text = data["title"].ToString();
		MessageText.text = data["message"].ToString();

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
