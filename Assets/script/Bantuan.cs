using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bantuan : MonoBehaviour
{
   public GameObject panelBantuan;

   public void BantuanControl()
   {
	   	if (Time.timeScale == 1)
	   	{
	   		panelBantuan.SetActive (true);
	   		Time.timeScale = 0;
	   	}else{
	   		Time.timeScale = 1;
	   		panelBantuan.SetActive (false);
	   	}
   }}
