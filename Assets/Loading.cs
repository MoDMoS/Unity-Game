using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Loading : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshProUGUI text;
    private float timeRemaining;
    private const float timerMax = 5f;

    // Start is called before the first frame update
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchrononsly(sceneIndex));
    }

    // Update is called once per frame
    IEnumerator LoadAsynchrononsly(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            text.text = progress * 100f + "%";

            yield return null;
        }
    }
    public void time()
    {
        slider.value = (timeRemaining / timerMax);
        if(timeRemaining >= 0)
        {
            timeRemaining += Time.deltaTime;
        }
        else if(timeRemaining >= timerMax)
        {
            timeRemaining = timerMax;
        }
    }
}
