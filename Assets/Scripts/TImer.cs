using System.Threading;
using UnityEngine;
using UnityEngine.UI;
public class TImer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float time = 25.0f;

    public Text timeText;
    private bool canCount = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeText.text = "时间: " + time.ToString("F1");
        Debug.Log(time);
    }

    public void StartCount(bool Count){
        this.canCount = Count;
        if(!canCount){
            time = 0;
            timeText.text = "游戏结束";
        }
    }
}
