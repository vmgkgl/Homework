using UnityEngine;
using UnityEngine.UI;

public class Game2player: MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public Text scoreText;
    public Text bestScoreText;
    public Text gameOverText;
    public Button restartButton;
    public float scoreIncreaseInterval = 1f;
    public float scoreIncreaseAmount = 10f;
    public float playerSpeed = 5f;
    private float score = 0f;
    private float bestScore = 0f;
    private bool isGameStarted = false;

    private void Start()
    {
        // 최고 점수 로드
        bestScore = PlayerPrefs.GetFloat("BestScore", 0f);
        bestScoreText.text = "Best Score: " + bestScore.ToString();

        // 게임 일시 정지
        Time.timeScale = 0;

        // 시작 패널 표시
        startPanel.SetActive(true);
    }

    private void Update()
    {
        if (isGameStarted)
        {
            // 플레이어 이동
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
            transform.position += new Vector3(horizontalInput, verticalInput, 0f).normalized * playerSpeed * Time.deltaTime;
        }
    }

    private void IncreaseScore()
    {
        // 점수 증가
        score += scoreIncreaseAmount;
        scoreText.text = "Score: " + score.ToString();

        // 최고 점수 갱신
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetFloat("BestScore", bestScore);
            bestScoreText.text = "Best Score: " + bestScore.ToString();
        }
    }

    public void StartGame()
    {
        // 게임 시작
        isGameStarted = true;
        startPanel.SetActive(false);
        InvokeRepeating("IncreaseScore", scoreIncreaseInterval, scoreIncreaseInterval);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        // 게임 오버 패널 표시
        gameOverPanel.SetActive(true);
        gameOverText.text = "Game Over!\n\nYour Score: " + score.ToString();
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetFloat("BestScore", bestScore);
            bestScoreText.text = "Best Score: " + bestScore.ToString() + "\n\nNew Best Score!";
        }
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        // 게임 재시작
        score = 0f;
        scoreText.text = "Score: " + score.ToString();
        gameOverPanel.SetActive(false);
        isGameStarted = true;
        InvokeRepeating("IncreaseScore", scoreIncreaseInterval, scoreIncreaseInterval);
        Time.timeScale = 1;
    }
}
