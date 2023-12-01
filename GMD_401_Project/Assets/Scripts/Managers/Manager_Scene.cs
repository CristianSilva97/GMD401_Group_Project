using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Manager_Scene : MonoBehaviour
{
     public Animator transitions;
     public float transitionTime = 1f;

   public static Manager_Scene Instance; 

   private void Awake()
   {
    Instance = this;
   }
   public enum Scene 
   {
        StartingScene,
        TestScene
   }
   public void LoadScene(Scene scene)
   {
        SceneManager.LoadScene(scene.ToString());
   }
   public void LoadNextScene()
   {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
   }
   public void LoadMainMenu()
   {
        SceneManager.LoadScene(Scene.StartingScene.ToString());
   }

   IEnumerator LoadLevel (int levelIndex)
   {
     yield return new WaitForSeconds(transitionTime);
     SceneManager.LoadScene(levelIndex);
   }
}
