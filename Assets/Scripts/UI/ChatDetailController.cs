using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
	预期样式：

	======================================================== 
	|	□___________										|
	|	□____________________								|
	|							_____________________□		|
	|	□________											|
	|	□_____________										|
	|														|
	|														|
	|														|
	|														|
	|														|
	|	 _______________________________________			|
	|	|____________空白按钮inputButton________|  发送		|
	|	 _______________________________________			|
	|	|________________回答按钮1______________|			|
	|	 _______________________________________			|
	|	|________________回答按钮2______________|			|
	|	 _______________________________________			|
	|	|________________回答按钮3______________|			|
	|														|
	=========================================================

*/

public class ChatDetailController : MonoBehaviour
{
	public GameObject npcChatPrefab;        // npc聊天气泡
	public GameObject playerChatPrefab;     // 玩家聊天气泡
	public Transform dialogueContainer;     // 聊天页面容器
	public RectTransform rootTrans;         //聊天文本放置的层
	public ScrollRect scrollTectObject;     //滚动条
	public GameObject inputButtonPrefeb;    // 玩家回复消息的按钮预制体

	public ChatController chatController;   // 聊天列表页面控制器

	//  打开某个NPC聊天页面
	public void OpenChat()
	{
		// 初始化聊天页面
		ResetChat();
		gameObject.SetActive(true);
		chatController.npcButtonContainer.gameObject.SetActive(false);
		
		// 生成回复按钮
		GameObject inputButton = Instantiate(inputButtonPrefeb);
		// 将按钮设置为ChatDetailPanel的子对象
		inputButton.transform.SetParent(this.transform); 
		inputButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 50f);
		inputButton.GetComponentInChildren<Text>().text = "......";
		inputButton.GetComponent<Button>().onClick.AddListener(() => OnInputButtonClicked());

		// 获取和当前NPC的历史聊天记录
		LoadChatRecord();

	}

	// 重置聊天页面
	private void ResetChat()
	{
		// 清空对话列表
		foreach (Transform child in dialogueContainer) {
			Destroy(child.gameObject);
		}

	}

	// 加载历史聊天记录
	private void LoadChatRecord()
	{
		int recordNums = 3; // 假如记录有3条
		float prefabHeight = npcChatPrefab.GetComponent<RectTransform>().rect.height;
		float chatPanelHeight = dialogueContainer.GetComponent<RectTransform>().rect.height;
		float startY = -prefabHeight / 2f; // 初始位置为第一条消息的中心点，需要往上偏移半个预制体高度

		for (int i = 0; i < recordNums; i++) {
			GameObject dialogueObj = Instantiate(npcChatPrefab, dialogueContainer);
			dialogueObj.GetComponentInChildren<Text>().text = "第" + i + "条对话";// 文字内容
			
			

			// 计算对话框应该出现的位置
			float currentY = startY - i * prefabHeight;
			dialogueObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, currentY);

		}

		//重新计算容器尺寸，并滚动屏幕到最新聊天处
		LayoutRebuilder.ForceRebuildLayoutImmediate(rootTrans);
		scrollTectObject.verticalNormalizedPosition = 0;

		// 判断玩家是否可以回消息

	}

	// 玩家发送消息的按钮事件
	public void OnInputButtonClicked()
	{
		// 根据可选择的回复生成n个按钮

		// 根据玩家点击的按钮，继续聊天回复

	}

}