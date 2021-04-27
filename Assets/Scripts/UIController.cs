using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public BoxCollider2D bc;
    public GameObject menu;
    public GameObject gamePlay;
    
    public Image ultyView;
    public Image[] HP_View;
    
    public GameObject player;
    public CinemachineVirtualCamera camera;

    private Vector3 startPosition;
    
    public static UIController instance;

    private void Awake()
    {
        player.SetActive(false);
        instance = this;
        
    }

    public void StartGame()
    {
        menu.SetActive(false);
        gamePlay.SetActive(true);
        player.SetActive(true);
        startPosition = player.transform.position;
        camera.Follow = FindObjectOfType<PlayerController>().transform;
    }

    public void RestartGame()
    {
        HP_View[0].gameObject.SetActive(true);
        HP_View[1].gameObject.SetActive(true);
        HP_View[2].gameObject.SetActive(true);
        player.GetComponent<PlayerController>().HP = 3;
        
        
        menu.SetActive(true);
        gamePlay.SetActive(false);
        player.SetActive(false);
        StopAllCoroutines();
        camera.Follow = null;
        player.transform.position = startPosition;
        camera.transform.position = new Vector3(-11.413f, 229.8f, -14.3395f);
    }

    public void TakeDamage(int sumHP)
    {
        if (sumHP.Equals(0))
            RestartGame();
        else
            HP_View[sumHP].gameObject.SetActive(false);
    }

    public void UseUlty()
    {
        ultyView.gameObject.SetActive(!ultyView.gameObject.activeSelf);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("End");
    }
}