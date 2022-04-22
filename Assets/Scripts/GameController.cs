using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private string nextLevelName;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private EnemyMovement enemy;
    [SerializeField] private GameObject exitPrefab;
    private void Update()
    {
        CheckPlayerPosWithinExit();
        CheckPlayerPosWithinEnemy();
    }

    private void CheckPlayerPosWithinExit()
    {
        if (Vector3.Distance(player.transform.position, exitPrefab.transform.position) <= 0.1)
        {
            ChangeToNextLevel();
        }
    }

    private void CheckPlayerPosWithinEnemy()
    {
        if (Vector3.Distance(player.transform.position, enemy.transform.position) <= 0.1)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        MovementController movement = GetComponent<MovementController>();
        movement.enabled = false;
        StartCoroutine(GameOverCour());
    }

    private void ChangeToNextLevel() 
    {
        SceneManager.LoadScene(nextLevelName);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    private IEnumerator GameOverCour()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }






}
