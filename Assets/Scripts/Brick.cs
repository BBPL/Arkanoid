using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public int maxHits;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;

    // Use this for initialization
    void Start () {
        isBreakable = (this.tag == "Breakable");

        if (isBreakable)
        {
            breakableCount++;
            print(breakableCount);
        }

        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (isBreakable)
        {
            timesHit++;
            maxHits = hitSprites.Length + 1;

            if (timesHit >= maxHits)
            {
                breakableCount--;
                print(breakableCount);
                levelManager.BrickDestroyed();
                Destroy(gameObject);
            }
            else
            {
                LoadSprites();
            }
        }
        
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        

    }
        
}
