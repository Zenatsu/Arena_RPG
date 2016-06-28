using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    //this class handles scene changing

    public void EnterShop()
    {
        SceneManager.LoadScene("ShopScene");
    }
    public void ExitShop()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void EnterTavern()
    {
        SceneManager.LoadScene("TavernScene");
    }
    public void ExitTavern()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void EnterArena()
    {
        SceneManager.LoadScene("ArenaScene");
    }
    
    public void ExitArena()
    {
        SceneManager.LoadScene("MainScene");
    }

}
