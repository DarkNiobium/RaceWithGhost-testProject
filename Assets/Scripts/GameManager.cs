using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaceManager : MonoBehaviour
{
    public GhostRecorder recorder;
    public GhostPlayer ghostPlayer;

    private GhostData savedData;
    private bool firstRace = true;

    [SerializeField] Transform startPoint;
    [SerializeField] Transform endTrigger;
    [SerializeField] Text currentLap;

    [SerializeField] GameObject winnerMenu;
    [SerializeField] GameObject startMenu;
    void Start()
    {
        firstRace = true;
        recorder.StartRecording();
        recorder.gameObject.transform.position = startPoint.position;
    }

    void Update()
    {
        // Кнопка для завершения круга2(Enter)
        if (Input.GetKeyDown(KeyCode.Return))
        {
            endLap();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Перезагрузит текущую сцену(ползено,не зависит от индекса сцены или её названия)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void endLap()
    {
        if (firstRace)
        {
            recorder.StopRecording();
            savedData = recorder.GetData();
            firstRace = false;
            ghostPlayer.Play(savedData);

            currentLap.text = "1/2";
            recorder.gameObject.transform.position = startPoint.position;
        }
        else
        {
            currentLap.text = "2/2";

            Debug.Log("Гонка завершена");
            winnerMenu.SetActive(true);
        }
    }
    //Надеюсь мой код понятен и без коментариев
}
