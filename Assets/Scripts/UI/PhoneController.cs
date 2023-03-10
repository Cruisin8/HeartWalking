using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PhoneController : MonoBehaviour
{
	public Button[] appsButtons;    // apps��ť

	public GameObject phonePanel;   // �ֻ�����UI����
	public GameObject mainPanel;    // �ֻ�������
	public GameObject[] appPanels;  // �ֻ�appҳ��

	private bool isShowingPhonePanel = false;
	private bool isShowingMainPanel = true;

	public NewsController newsController;

	public enum AppType
	{
		NewsApp,
		WeChatApp,
		ConfigApp
	}

	private Vector2 phonePanelOriginalPosition;	// �ֻ�ҳ����ʾλ��

	// ��ʼ���ֻ�ҳ��
	public void InitPhone()
	{
		mainPanel.SetActive(true);
		foreach (var appPanel in appPanels) {
			appPanel.SetActive(false);
		}
		phonePanel.SetActive(false);

		// ����ÿ��app��ť�ĵ���¼�
		for (int i = 0; i < appsButtons.Length; i++) {
			int index = i; // ����հ�����
			appsButtons[i].onClick.AddListener(() => OnAppsButtonClicked(index));
		}

		// ��ʼ������app
		newsController.InitNewsApp();

		// ��¼�ֻ�ҳ��λ��
		phonePanelOriginalPosition = phonePanel.transform.position;
	}

	// ��ʾ/���� �ֻ�ҳ��
	public void ShowPhonePanel()
	{
		if (isShowingPhonePanel) {
			// �����ֻ�ҳ��
			isShowingPhonePanel = false;
			// �ֻ���ʧʱ�Ķ���Ч��
			phonePanel.transform.DOMove(new Vector2(phonePanelOriginalPosition.x, -1000f), 0.5f).SetEase(Ease.InQuint).OnComplete(() => { 
				HideAllPanels();
				phonePanel.SetActive(false);
			});
		}
		else {
			// ��ʾ�ֻ�ҳ��
			ShowMainPanel();
			phonePanel.SetActive(true);
			isShowingPhonePanel = true;
			// �ֻ���ʾʱ�Ķ���Ч��
			phonePanel.transform.position = new Vector2(phonePanelOriginalPosition.x, -1000f);
			phonePanel.transform.DOMove(phonePanelOriginalPosition, 0.5f).SetEase(Ease.OutQuint);
		}
	}

	// ��ʾ��ҳ��
	private void ShowMainPanel()
	{
		mainPanel.SetActive(true);
		foreach (var appPanel in appPanels) {
			appPanel.SetActive(false);
		}
		isShowingMainPanel = true;
	}

	// ���������ֻ�ҳ��
	private void HideAllPanels()
	{
		mainPanel.SetActive(false);
		foreach (var appPanel in appPanels) {
			appPanel.SetActive(false);
		}
		isShowingMainPanel = false;
	}

	// ��ʾ��Ӧ��appҳ��
	private void OnAppsButtonClicked(int index)
	{
		HideAllPanels();
		appPanels[index].SetActive(true);
		isShowingMainPanel = false;
		InitApps(index);
	}

	// ���ö�Ӧapp�ĳ�ʼ������
	private void InitApps(int index)
	{
		switch (index) {
			case (int)AppType.NewsApp:
				newsController.InitNewsApp();
				break;
			case (int)AppType.WeChatApp:
				//InitForApp2();
				break;
			case (int)AppType.ConfigApp:
				//InitForApp3();
				break;
			default:
				Debug.LogError("Unknown AppType: " + index);
				break;
		}
	}

}
