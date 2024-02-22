using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    private WaitForSeconds wait = new WaitForSeconds(6f);

    public GameState GameState;

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.Show("IntroPopup");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaitForPlayVideo());
    }

    private IEnumerator WaitForPlayVideo()
    {
        yield return wait;

        UIManager.Instance.Hide("IntroPopup");
    }

    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.SpawnHeroes:
                UnitManager.Instance.SpawnHeroes();
                break;
            case GameState.SpawnEnemies:
                UnitManager.Instance.SpawnEnemies();
                break;
            case GameState.HeroesTurn:
                break;
            case GameState.EnemiesTurn:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }

}

public enum GameState
{
    GenerateGrid = 0,
    SpawnHeroes = 1,
    SpawnEnemies = 2,
    HeroesTurn = 3,
    EnemiesTurn = 4
}