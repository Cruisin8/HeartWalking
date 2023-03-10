using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
	public PhoneController phoneController;

    // Start is called before the first frame update
    void Start()
    {
		//初始化手机
		phoneController.InitPhone();

	}

    // Update is called once per frame
    void Update()
    {
		// 打开/隐藏 手机
		if (Input.GetKeyDown(KeyCode.Q)) {
			phoneController.ShowPhonePanel();
		}
		
	}
}
