using UnityEngine;
using UnityEngine.SceneManagement;

public class Points_Flags : MonoBehaviour
{
    
    private int Points = 0;
    private int MaxPoints = 0;

    void start()
    {
        Points = 0;
        MaxPoints = GameObject.FindGameObjectsWithTag("ItemSlot").Length;
    }

    public void AddPoint()
    {
        Points++;
        if (Points == MaxPoints)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void HorsePoint()
    {
        Points++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (Points == MaxPoints)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

}
