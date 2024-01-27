
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void  PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
