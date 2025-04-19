using UnityEngine;
using UnityEngine.SceneManagement;

public class Points_Flags : MonoBehaviour
{
    
    private int Points = 0;
    private int MaxPoints = 0;

    void Start()
    {
        Points = 0;
        MaxPoints = GameObject.FindGameObjectsWithTag("Slot").Length;
        Debug.Log(MaxPoints);
    }

    public void AddPoint()
    {
        Points++;
        Debug.Log(Points);  
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
            SceneManager.LoadScene("Completado");
        }

    }

}
