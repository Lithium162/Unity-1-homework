using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created 
    public GameObject Saki;
    public static int score = 0;
    public Text ScoreText;
    public float lifeTime = 1.5f;
    void Start()
    {
        ScoreText = GameObject.Find("scoreText").GetComponent<Text>();
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        score++;
        ScoreText.text = "分数: " + score.ToString();
        Instantiate(Saki, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
        Debug.Log("SakiHit");
    }
}
