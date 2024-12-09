using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject soundMenu; 
   

    private void Awake()
    {
        if (soundMenu != null)
        {
            soundMenu.SetActive(false); 
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            soundMenu.SetActive(true);

        }
    }

    public void OnPause()
    {
        soundMenu.SetActive(false);
    }
}
