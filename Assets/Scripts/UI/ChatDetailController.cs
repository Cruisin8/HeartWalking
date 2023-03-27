using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
	Ԥ����ʽ��

	======================================================== 
	|	��___________										|
	|	��____________________								|
	|							_____________________��		|
	|	��________											|
	|	��_____________										|
	|														|
	|														|
	|														|
	|														|
	|														|
	|	 _______________________________________			|
	|	|____________�հװ�ťinputButton________|  ����		|
	|	 _______________________________________			|
	|	|________________�ش�ť1______________|			|
	|	 _______________________________________			|
	|	|________________�ش�ť2______________|			|
	|	 _______________________________________			|
	|	|________________�ش�ť3______________|			|
	|														|
	=========================================================

*/

public class ChatDetailController : MonoBehaviour
{
	public GameObject npcChatPrefab;        // npc��������
	public GameObject playerChatPrefab;     // �����������
	public Transform dialogueContainer;     // ����ҳ������
	public RectTransform rootTrans;         //�����ı����õĲ�
	public ScrollRect scrollTectObject;     //������
	public GameObject inputButtonPrefeb;    // ��һظ���Ϣ�İ�ťԤ����

	public ChatController chatController;   // �����б�ҳ�������

	//  ��ĳ��NPC����ҳ��
	public void OpenChat()
	{
		// ��ʼ������ҳ��
		ResetChat();
		gameObject.SetActive(true);
		chatController.npcButtonContainer.gameObject.SetActive(false);
		
		// ���ɻظ���ť
		GameObject inputButton = Instantiate(inputButtonPrefeb);
		// ����ť����ΪChatDetailPanel���Ӷ���
		inputButton.transform.SetParent(this.transform); 
		inputButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 50f);
		inputButton.GetComponentInChildren<Text>().text = "......";
		inputButton.GetComponent<Button>().onClick.AddListener(() => OnInputButtonClicked());

		// ��ȡ�͵�ǰNPC����ʷ�����¼
		LoadChatRecord();

	}

	// ��������ҳ��
	private void ResetChat()
	{
		// ��նԻ��б�
		foreach (Transform child in dialogueContainer) {
			Destroy(child.gameObject);
		}

	}

	// ������ʷ�����¼
	private void LoadChatRecord()
	{
		int recordNums = 3; // �����¼��3��
		float prefabHeight = npcChatPrefab.GetComponent<RectTransform>().rect.height;
		float chatPanelHeight = dialogueContainer.GetComponent<RectTransform>().rect.height;
		float startY = -prefabHeight / 2f; // ��ʼλ��Ϊ��һ����Ϣ�����ĵ㣬��Ҫ����ƫ�ư��Ԥ����߶�

		for (int i = 0; i < recordNums; i++) {
			GameObject dialogueObj = Instantiate(npcChatPrefab, dialogueContainer);
			dialogueObj.GetComponentInChildren<Text>().text = "��" + i + "���Ի�";// ��������
			
			

			// ����Ի���Ӧ�ó��ֵ�λ��
			float currentY = startY - i * prefabHeight;
			dialogueObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, currentY);

		}

		//���¼��������ߴ磬��������Ļ���������촦
		LayoutRebuilder.ForceRebuildLayoutImmediate(rootTrans);
		scrollTectObject.verticalNormalizedPosition = 0;

		// �ж�����Ƿ���Ի���Ϣ

	}

	// ��ҷ�����Ϣ�İ�ť�¼�
	public void OnInputButtonClicked()
	{
		// ���ݿ�ѡ��Ļظ�����n����ť

		// ������ҵ���İ�ť����������ظ�

	}

}