using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsController : MonoBehaviour
{
	public GameObject[] newsImages; // 新闻图片
	public Button[] newsButtons;    // 新闻按钮
	// 遗留问题：新闻需要倒着增加

	public void InitNewsApp()
	{
		// 隐藏所有新闻图片
		foreach (GameObject newsImage in newsImages) {
			newsImage.SetActive(false);
		}

		// 设置每个新闻按钮的点击事件
		for (int i = 0; i < newsButtons.Length; i++) {
			int index = i; // 避免闭包问题
			newsButtons[i].onClick.AddListener(() => OnNewsButtonClicked(index));
		}
	}

	private void OnNewsButtonClicked(int index)
	{
		// 隐藏所有新闻图片
		foreach (GameObject newsImage in newsImages) {
			newsImage.SetActive(false);
		}

		// 显示对应的新闻图片
		newsImages[index].SetActive(true);
	}
	
}
