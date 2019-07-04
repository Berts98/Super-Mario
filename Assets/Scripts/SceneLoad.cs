using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoad : MonoBehaviour
{
	public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
