using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsController : MonoBehaviour
{
	public GameObject[] newsImages; // ����ͼƬ
	public Button[] newsButtons;    // ���Ű�ť
	// �������⣺������Ҫ��������

	public void InitNewsApp()
	{
		// ������������ͼƬ
		foreach (GameObject newsImage in newsImages) {
			newsImage.SetActive(false);
		}

		// ����ÿ�����Ű�ť�ĵ���¼�
		for (int i = 0; i < newsButtons.Length; i++) {
			int index = i; // ����հ�����
			newsButtons[i].onClick.AddListener(() => OnNewsButtonClicked(index));
		}
	}

	private void OnNewsButtonClicked(int index)
	{
		// ������������ͼƬ
		foreach (GameObject newsImage in newsImages) {
			newsImage.SetActive(false);
		}

		// ��ʾ��Ӧ������ͼƬ
		newsImages[index].SetActive(true);
	}
	
}
