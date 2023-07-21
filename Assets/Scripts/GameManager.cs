using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenu; // Referencia al menú de pausa en el Inspector

    private void Start()
    {
        LockCursor();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PauseGame()
    {
        isPaused = true;
        UnlockCursor();
        Time.timeScale = 0f; // Pausar el tiempo en el juego
        pauseMenu.SetActive(true); // Activar el menú de pausa
    }

    public void ResumeGame()
    {
        isPaused = false;
        LockCursor();
        Time.timeScale = 1f; // Resumir el tiempo en el juego
        pauseMenu.SetActive(false); // Desactivar el menú de pausa
    }
}
