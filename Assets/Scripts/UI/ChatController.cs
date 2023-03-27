using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatController : MonoBehaviour
{
	public ChatDetailController chatDetailController;   // 聊天具体内容页面控制器
	public GameObject chatDetailPanel;      // 聊天界面
	
	public GameObject npcButtonPrefab;      // NPC选择聊天按钮
	public Transform npcButtonContainer;    // NPC聊天按钮容器

	int chatNPCNums = 6;    // 可以聊天的NPC总数
	

	public void InitChatApp()
	{
		chatDetailPanel.SetActive(false);
		npcButtonContainer.gameObject.SetActive(true);

		// 清空列表
		foreach (Transform child in npcButtonContainer) {
			Destroy(child.gameObject);
		}

		// 获取NPC按钮长宽, 创建NPC按钮
		float buttonWidth = npcButtonPrefab.GetComponent<RectTransform>().rect.width;
		float buttonHeight = npcButtonPrefab.GetComponent<RectTransform>().rect.height;
		// 调整第一个按钮的位置，将容器向上移动 50 像素
		npcButtonContainer.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 70f);
		float yPos = 0f; // 下一个按钮应该放置的垂直位置
		for (int i = 0; i < chatNPCNums; i++) { 
			GameObject npcButton = Instantiate(npcButtonPrefab, npcButtonContainer);
			npcButton.SetActive(true); // 将按钮设置为默认激活状态
			// 设置按钮位置，让按钮依次排列
			RectTransform rectTransform = npcButton.GetComponent<RectTransform>();
			rectTransform.anchoredPosition = new Vector2(0f, yPos);
			// 计算下一个按钮的垂直位置
			yPos -= buttonHeight;

			// 生成npc按钮名称并绑定点击事件
			npcButton.GetComponent<Button>().onClick.AddListener(() => OnNPCButtonClicked());
			npcButton.GetComponentInChildren<Text>().text = "张三";

			// 添加未读消息红点逻辑

		}
	}

	// NPC聊天按钮点击事件
	private void OnNPCButtonClicked()
	{
		chatDetailController.OpenChat();
	}

}