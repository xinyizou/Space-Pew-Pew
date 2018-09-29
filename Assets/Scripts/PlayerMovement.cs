using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    float spriteLifeTime = 0;
    SpriteRenderer spriteRenderer;
    public Sprite idleSprite;
    public Sprite piercingSprite;
    public Sprite spreadSprite;
    public Sprite rocketSprite;
    public GameObject piercingShot;
    public GameObject spreadShot;
    public GameObject rocketShot;
	
	void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

    void FirePiercingshot()
    {
        Instantiate(piercingShot, transform.position + new Vector3(0, 0.75f, 0), Quaternion.identity);
    }

    void FireSpreadShot()
    {
        Instantiate(spreadShot, transform.position + new Vector3(0, 0.75f, 0), Quaternion.identity);
    }

    void FireRocketShot()
    {
        Instantiate(rocketShot, transform.position + new Vector3(0, 0.75f, 0), Quaternion.identity);
    }
    
    void UpdateSprite()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            spriteRenderer.sprite = piercingSprite;
            spriteLifeTime = 0.15f;
            FirePiercingshot();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            spriteRenderer.sprite = spreadSprite;
            spriteLifeTime = 0.15f;
            FireSpreadShot();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            spriteRenderer.sprite = rocketSprite;
            spriteLifeTime = 0.15f;
            FireRocketShot();
        }
 
        spriteLifeTime -= Time.deltaTime;
        if(spriteLifeTime <= 0)
        {
            spriteRenderer.sprite = idleSprite;
        }
    }
	
	void Update(){
        UpdateSprite();
        float step = speed * Time.deltaTime;
        Vector3 newPos = transform.position;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPos += Vector3.left * step;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
        {
            newPos += Vector3.right * step;
        }
        newPos.x = Mathf.Clamp(newPos.x, -7.5f,7.5f);
        transform.position = newPos;
	}
}
