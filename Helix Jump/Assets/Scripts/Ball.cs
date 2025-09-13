using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;
    public GameObject SplashPrefab;
    private GameManager gm;
    public float rotateSpeed;

    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

//Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
       
        string materialName = collision.gameObject.GetComponent<MeshRenderer>().material.name;
        
        Debug.Log(materialName);

        if(materialName == "Ice-Cream-Cone (Instance)")
        {
            gm.NextLevel();

        }
        else if(materialName == "stripes3 (Instance)")
        {
            gm.RestartGame();

        }
        else
        {
            rb.velocity = new Vector3(0, jumpForce, 0);


            Quaternion randomRotation = Quaternion.Euler(-90, Random.Range(-180f, 180f), Random.Range(-180f, 180f));

            GameObject splash = Instantiate(SplashPrefab, transform.position - new Vector3(0f, .2f, 0f), randomRotation);

            splash.transform.SetParent(collision.gameObject.transform);

        }
    }

}

