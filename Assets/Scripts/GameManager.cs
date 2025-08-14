using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GhostRecorder recorder;
    public GhostPlayer ghostPlayer;
    GhostData data;

    private GhostData savedData;
    private bool firstRace = true;

    [SerializeField] Transform startPoint;
    [SerializeField] TMP_Text currentLap;

    [SerializeField] GameObject raceOver_Menu;
    void Start()
    {
        firstRace = true;
        recorder.StartRecording();
        data = recorder.GetData();
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
            TeleportToFirstPoint();

        }
        else
        {
            currentLap.text = "2/2";

            Debug.Log("Гонка завершена");
            raceOver_Menu.SetActive(true);
        }
    }
    public void TeleportToFirstPoint()
    {
        if (savedData.Positions.Count == 0)
        {
            Debug.LogWarning("Нет записанных позиций для телепорта!");
            return;
        }

        Rigidbody rb = recorder.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.position = savedData.Positions[0];
            rb.rotation = savedData.Rotations[0];
        }
        else
        {
            recorder.transform.position = savedData.Positions[0];
            recorder.transform.rotation = savedData.Rotations[0];
        }
    }

    //Надеюсь остальной мой код понятен и без коментариев
}