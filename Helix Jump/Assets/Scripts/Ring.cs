using UnityEngine;

public class Ring : MonoBehaviour
{
    public Transform ball;
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= ball.transform.position.y +5f)
        {
            Destroy(gameObject);
            gm.IncreaseGameScore(100);
        }

    }
}