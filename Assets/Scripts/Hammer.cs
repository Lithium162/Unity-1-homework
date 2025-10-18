using UnityEngine;
using UnityEngine.UI;
public class Hammer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Sprite hammerUp;
    public Sprite hammerDown;
    public Image hammerImage;
    public AudioSource SoundPlay;
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SoundPlay.Play();
            hammerImage.sprite = hammerDown;

        }
        if (Input.GetMouseButtonUp(0))
        {
            hammerImage.sprite = hammerUp;
        }
        hammerImage.transform.position = Input.mousePosition;
    }
}