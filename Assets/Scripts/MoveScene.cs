using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour {
	public static int initial_video_id;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveToMain (int video_id) {
		initial_video_id = video_id;
		SceneManager.LoadScene ("Main");
	}

	public void hoge (){
	}
}
