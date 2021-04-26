using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image ultyView;
    public Image[] HP_View;
    
    
    public static UIController instance;

    private void Awake()
    {
        instance = this;
    }

    public void TakeDamage(int sumHP)
    {
        if (sumHP.Equals(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        HP_View[sumHP].gameObject.SetActive(false);
    }

    public void UseUlty()
    {
        ultyView.gameObject.SetActive(!ultyView.gameObject.activeSelf);
    }

}