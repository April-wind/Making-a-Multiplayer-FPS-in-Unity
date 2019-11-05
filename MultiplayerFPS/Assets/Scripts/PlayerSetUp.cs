using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetUp : NetworkBehaviour
{	
	[SerializeField]
	private Behaviour[] componentsToDisable;

	private Camera sceneCamera;
	private void Start()
	{
		//如果不是当前窗口玩家
		if (!isLocalPlayer)
		{
			for (int i = 0; i < componentsToDisable.Length; i++)
			{
				componentsToDisable[i].enabled = false;
			}
		}
		else
		{
			sceneCamera = Camera.main;

			//说明场景中不止一个camera 因为玩家自带一个
			if (sceneCamera != null)
			{
				sceneCamera.gameObject.SetActive(false);
			}
		}
	}

	private void OnDisable()
	{
		if (sceneCamera != null)
		{
			sceneCamera.gameObject.SetActive(true);
		}
	}
}
