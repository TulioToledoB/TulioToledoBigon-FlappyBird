using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private TextMeshProUGUI scoreText;
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public bool isGameOver;
    private int score;
    private int bestScore;
    [SerializeField] private GameObject scorePanel;
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private TextMeshProUGUI bestScoreText; 
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
       
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isGameOver)
        {
            RestartGame();
        }
    }

    public void GameOver()
    {
        scorePanel.SetActive(true);
        audioSource.PlayOneShot(gameOverSound);
        isGameOver = true;
        gameOverText.SetActive(true);
        currentScore.text= "Score: "+score.ToString();
     
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

       
        bestScoreText.text = "Best: " + bestScore.ToString();

        FindObjectOfType<SoundsBack>().StopBackgroundMusic();
    }

  private void RestartGame()
{
    
    score = 0;
    isGameOver = false;
    
 
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}

    public void IncreaseScore()
    {
        score++;
        scoreText.text =score.ToString();
    }
}
