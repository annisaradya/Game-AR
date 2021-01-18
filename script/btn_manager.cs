using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_manager : MonoBehaviour
{
	//public AudioSource buttonSound;
    public void LoadScene(string scenename)
    {
    	//buttonSound.PlayOneShot(buttonSound.clip);
    	SceneManager.LoadScene(scenename);

    }

    public void Quit()
    {
    	Debug.Log("keluaar");
    	Application.Quit();
    }
}
