
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    
    public void CambiarScena(string EScena)
    {
        SceneManager.LoadScene("Menu");
    }
}
