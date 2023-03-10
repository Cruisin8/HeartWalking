using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PhoneController : MonoBehaviour
{
	public Button[] appsButtons;    // apps按钮

	public GameObject phonePanel;   // 手机整体UI界面
	public GameObject mainPanel;    // 手机主界面
	public GameObject[] appPanels;  // 手机app页面

	private bool isShowingPhonePanel = false;
	private bool isShowingMainPanel = true;

	public NewsController newsController;

	public enum AppType
	{
		NewsApp,
		WeChatApp,
		ConfigApp
	}

	private Vector2 phonePanelOriginalPosition;	// 手机页面显示位置

	// 初始化手机页面
	public void InitPhone()
	{
		mainPanel.SetActive(true);
		foreach (var appPanel in appPanels) {
			appPanel.SetActive(false);
		}
		phonePanel.SetActive(false);

		// 设置每个app按钮的点击事件
		for (int i = 0; i < appsButtons.Length; i++) {
			int index = i; // 避免闭包问题
			appsButtons[i].onClick.AddListener(() => OnAppsButtonClicked(index));
		}

		// 初始化新闻app
		newsController.InitNewsApp();

		// 记录手机页面位置
		phonePanelOriginalPosition = phonePanel.transform.position;
	}

	// 显示/隐藏 手机页面
	public void ShowPhonePanel()
	{
		if (isShowingPhonePanel) {
			// 隐藏手机页面
			isShowingPhonePanel = false;
			// 手机消失时的动画效果
			phonePanel.transform.DOMove(new Vector2(phonePanelOriginalPosition.x, -1000f), 0.5f).SetEase(Ease.InQuint).OnComplete(() => { 
				HideAllPanels();
				phonePanel.SetActive(false);
			});
		}
		else {
			// 显示手机页面
			ShowMainPanel();
			phonePanel.SetActive(true);
			isShowingPhonePanel = true;
			// 手机显示时的动画效果
			phonePanel.transform.position = new Vector2(phonePanelOriginalPosition.x, -1000f);
			phonePanel.transform.DOMove(phonePanelOriginalPosition, 0.5f).SetEase(Ease.OutQuint);
		}
	}

	// 显示主页面
	private void ShowMainPanel()
	{
		mainPanel.SetActive(true);
		foreach (var appPanel in appPanels) {
			appPanel.SetActive(false);
		}
		isShowingMainPanel = true;
	}

	// 隐藏所有手机页面
	private void HideAllPanels()
	{
		mainPanel.SetActive(false);
		foreach (var appPanel in appPanels) {
			appPanel.SetActive(false);
		}
		isShowingMainPanel = false;
	}

	// 显示对应的app页面
	private void OnAppsButtonClicked(int index)
	{
		HideAllPanels();
		appPanels[index].SetActive(true);
		isShowingMainPanel = false;
		InitApps(index);
	}

	// 调用对应app的初始化方法
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
