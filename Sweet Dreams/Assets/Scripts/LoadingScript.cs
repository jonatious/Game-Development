using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour {

    void Start()
	{
		SceneManager.LoadScene("GameScene");
    }
}
