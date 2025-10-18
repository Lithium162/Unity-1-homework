using UnityEngine;

public class gameControler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public class Hole
    {
        public bool isApper;
        public float holeX;
        public float holeY;
        public GameObject Saki;
    }

    public Hole[] holes;

    public GameObject holeObj;
    public GameObject SakiObj;
    public TImer timer;
    public float apperFrquency = 1.5f;
    private bool canIncrease = true;
    public float intervalPosX = 8, intervalPosY = 2;

    void Start()
    {
        InitialMap();
        SakiAppearFrquency(apperFrquency);
        //InvokeRepeating("SakiAppear", 3f, 0.5f);
        timer.StartCount(true);
    }

    private void InitialMap(){
        Vector2 originalPos = new Vector2(-9.5f, -6.5f);
        holes = new Hole[6];
        for (int i = 0; i < 2; i++){
            for (int j = 0; j < 3; j++)
            {
                holes[i * 3 + j] = new Hole();
                holes[i * 3 + j].holeX = originalPos.x + j * intervalPosX;
                holes[i * 3 + j].holeY = originalPos.y + i * intervalPosY;
                holes[i * 3 + j].isApper = false;
                Instantiate(holeObj, new Vector3(holes[i * 3 + j].holeX, holes[i * 3 + j].holeY, 0), Quaternion.identity);
            }
            originalPos.x += 4;
            holeObj.transform.localScale = new Vector3(1.02f, 0.476f, 1.36f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SakiHide();

        if(timer.time <15  && canIncrease == true){
            apperFrquency -= 0.3f;
            SakiAppearFrquency(apperFrquency);
            canIncrease = false;
        }

        if(timer.time <= 0){
            Gameover();
        }
    }

    private void Gameover()
    {
        timer.StartCount(false);
        CancelInvoke();
        Cursor.visible = true;
    }

    public float addX = 0, addY = 1.5f;
    private void SakiAppear()
    {

        int id = UnityEngine.Random.Range(0, 6);
        while (holes[id].isApper == true)
        {
            id = UnityEngine.Random.Range(0, 6);
        }
        holes[id].Saki = Instantiate(SakiObj, new Vector3(holes[id].holeX + addX, holes[id].holeY + addY, 0), Quaternion.identity);
        holes[id].isApper = true;
        Debug.Log("SakiAppear");
    }
    
    private void SakiAppearFrquency(float apperFrquency){
        CancelInvoke("SakiAppear");
        InvokeRepeating("SakiAppear", 0, apperFrquency);
        
    }
    private void SakiHide(){
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (holes[i * 3 + j].isApper == true)
                {
                    holes[i * 3 + j].isApper = false;
                }
            }
        }   
    }
}
