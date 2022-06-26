using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private Canvas gunReticleCanvas;

    private void Start()
    {
        gameOverCanvas.gameObject.SetActive(false);
    }

    public void HandleDeath()
    {
        gameOverCanvas.gameObject.SetActive(true);
        gunReticleCanvas.gameObject.SetActive(false);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
