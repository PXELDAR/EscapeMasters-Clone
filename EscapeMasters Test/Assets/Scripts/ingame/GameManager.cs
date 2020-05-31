using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] _Levels;
    private GameObject[] _Panels;
    private GameObject[] _Player;
    private int _CurrentLevel;
    public static int charsize;
    void Start()
    {
        _Panels = GameObject.FindGameObjectsWithTag("Panels");
        _Panels[0].SetActive(false);
        _Levels[_CurrentLevel].SetActive(true);
    }
    void Update()
    {
        _Player = GameObject.FindGameObjectsWithTag("Player");
        if (charsize >= _Player.Length)
        {
            _Panels[0].SetActive(true);
            charsize = 0;
        }
    }
    public void NextLevel(string index)
    {
        if (index == "Next")
        {
            _Panels[0].SetActive(false);
            _CurrentLevel++;
            _Levels[_CurrentLevel - 1].SetActive(false);
            _Levels[_CurrentLevel].SetActive(true);
        }
    }
}
