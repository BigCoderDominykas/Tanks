using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Health player1;
    public Health player2;

    void Update()
    {
        if(player1.hp == 0 ||player2.hp == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
