using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLode : MonoBehaviour
{
    [SerializeField] string _sceneName = "";


   public void LodeScene()
    {
        SceneManager.LoadScene(_sceneName);
    }

}
