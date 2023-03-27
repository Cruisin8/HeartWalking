using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatController : MonoBehaviour
{
	public ChatDetailController chatDetailController;   // �����������ҳ�������
	public GameObject chatDetailPanel;      // �������
	
	public GameObject npcButtonPrefab;      // NPCѡ�����찴ť
	public Transform npcButtonContainer;    // NPC���찴ť����

	int chatNPCNums = 6;    // ���������NPC����
	

	public void InitChatApp()
	{
		chatDetailPanel.SetActive(false);
		npcButtonContainer.gameObject.SetActive(true);

		// ����б�
		foreach (Transform child in npcButtonContainer) {
			Destroy(child.gameObject);
		}

		// ��ȡNPC��ť����, ����NPC��ť
		float buttonWidth = npcButtonPrefab.GetComponent<RectTransform>().rect.width;
		float buttonHeight = npcButtonPrefab.GetComponent<RectTransform>().rect.height;
		// ������һ����ť��λ�ã������������ƶ� 50 ����
		npcButtonContainer.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 70f);
		float yPos = 0f; // ��һ����ťӦ�÷��õĴ�ֱλ��
		for (int i = 0; i < chatNPCNums; i++) { 
			GameObject npcButton = Instantiate(npcButtonPrefab, npcButtonContainer);
			npcButton.SetActive(true); // ����ť����ΪĬ�ϼ���״̬
			// ���ð�ťλ�ã��ð�ť��������
			RectTransform rectTransform = npcButton.GetComponent<RectTransform>();
			rectTransform.anchoredPosition = new Vector2(0f, yPos);
			// ������һ����ť�Ĵ�ֱλ��
			yPos -= buttonHeight;

			// ����npc��ť���Ʋ��󶨵���¼�
			npcButton.GetComponent<Button>().onClick.AddListener(() => OnNPCButtonClicked());
			npcButton.GetComponentInChildren<Text>().text = "����";

			// ���δ����Ϣ����߼�

		}
	}

	// NPC���찴ť����¼�
	private void OnNPCButtonClicked()
	{
		chatDetailController.OpenChat();
	}

}