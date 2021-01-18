using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
   float currentTime = 0f;
   float startingTime = 30f;

   public Text losetext;

   [SerializeField] Text TextTimer;

   void Start()
   {
   		currentTime = startingTime;
   		losetext.text="";
   }

   void Update()
   {
   	currentTime -=1 * Time.deltaTime;
   	TextTimer.text = currentTime.ToString("0");

   	if (currentTime <= 0)
   	{
   		currentTime = 0;
   		losetext.text="Selamat!!";
         FindObjectOfType<GameManager>().EndGame();

   	}
   }
}