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
    [SerializeField] Text currentLap;

    [SerializeField] GameObject raceOver_Menu;
    void Start()
    {
        firstRace = true;
        recorder.StartRecording();
        recorder.gameObject.transform.position = startPoint.position;
    }

    void Update()
    {
        // Кнопка для завершения круга(Enter)
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
        // Простой if else т.к. кругов пока что только два,могу расширить
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
            raceOver_Menu.SetActive(true);
        }
    }
    //Надеюсь остальной мой код понятен и без коментариев
}
