using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Random : MonoBehaviour
{
    public Text Texts;
    int randomNum;

    public void PickRandomNumber()
    {
        randomNum = UnityEngine.Random.Range(1,7);
        Texts.GetComponent<Text>().text = randomNum.ToString();
    }
}