using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_ButtonMana : MonoBehaviour
{
    public void Instruction_BackButton()
    {
        SceneManager.LoadScene("Map_Menu");
    }

    public void Menu_StartButton()
    {
        SceneManager.LoadScene("Map_Game01");
    }

    public void Menu_TellStoryButton()
    {
        SceneManager.LoadScene("Map_Instruction");
    }
    public void Game01_PauseButton()
    {
        SceneManager.LoadScene("Map_Menu");
    }
    public void Game01_KillSelfButton()
    {
        Script_PlayerStats PS = GameObject.FindGameObjectWithTag("Player").GetComponent<Script_PlayerStats>();
        PS.ApplyDamage();
        if (PS.Health <= 0)
        {
            SceneManager.LoadScene("Map_End");
        }
    }
}
