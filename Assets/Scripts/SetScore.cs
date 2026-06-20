using TMPro;
using UnityEngine;

public class SetScore : MonoBehaviour
{
    public TMP_Text text;
    void Start()
    {
        text.text = $"Score: {PlayerPrefs.GetInt("score")}";
    }
}
