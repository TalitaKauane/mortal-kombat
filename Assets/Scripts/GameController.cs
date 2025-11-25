using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    private int p1y, p1x, p2y, p2x;
    private GameObject[,] gridChars;
    private Image[,] gridButtons;

    [SerializeField] private int colums, rows;
    [SerializeField] private GameObject[] listChars;
    [SerializeField] private Image[] listButtons;
    [SerializeField] private Sprite p1Selected, p2Selected, empty;
        
    public sealed class Singleton
    {
        private static Singleton instance = null;

        private Singleton(){ }

        public static Singleton Instance
        {
            get{
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    } 

    void Start()
    {
        p1y = 0;
        p1x = 0;
        p2y = 0;
        p2x = 0;

        gridChars = new GameObject[colums, rows];
        gridButtons = new Image[colums, rows];

        int k = 0;
        for (int y = 0; y < colums; y++){
            for (int x = 0; x < rows; x++) {
                gridChars[y, x] = listChars[k];
                gridButtons [y, x] = listButtons[k];
                k++;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
