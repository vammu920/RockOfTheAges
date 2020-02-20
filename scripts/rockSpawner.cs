using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockSpawner : MonoBehaviour
{
    Timer timer;
    float StartTime = 0;

    [SerializeField]
    GameObject RockWhite;
    [SerializeField]
    GameObject RockYellow;
    [SerializeField]
    GameObject RockGreen;
    int rockCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 1;
        timer.Run();
        StartTime = Time.time;

    }
    void spawnRock()
    {

        Vector2 location = new Vector2(0, 0);
        Vector2 worldLocation = Camera.main.ScreenToWorldPoint(location);


        Vector2 centerPoint = new Vector2(0, 0);
        int RandomSprite = Random.Range(0, 3);
        if (RandomSprite == 0)
        {
            Instantiate<GameObject>(RockWhite, centerPoint, Quaternion.identity);
        }
        else if (RandomSprite == 1)
        {
            Instantiate<GameObject>(RockYellow, centerPoint, Quaternion.identity);
        }
        else
        {
            Instantiate<GameObject>(RockGreen, centerPoint, Quaternion.identity);
        }


        //print(RandomSprite);
    }
    // Update is called once per frame
    void Update()
    {

        if (timer.Finished)
        {
            
            GameObject[] taggedRocks = GameObject.FindGameObjectsWithTag("whiteRockTag");
            GameObject[] taggedRocks1 = GameObject.FindGameObjectsWithTag("greenRockTag");
            GameObject[] taggedRocks2 = GameObject.FindGameObjectsWithTag("yellowRockTag");
            rockCount = taggedRocks2.Length + taggedRocks1.Length + taggedRocks.Length;
            if (rockCount < 3)
            {
                spawnRock();
            }
            float endTime = Time.time - StartTime;
            //print(endTime);
            StartTime = Time.time;
            timer.Run();
        }
        
    }
     void OnCollisionEnter2D(Collision2D col)
    {   
        GameObject[] taggedRocks = GameObject.FindGameObjectsWithTag("whiteRockTag");
        GameObject[] taggedRocks1 = GameObject.FindGameObjectsWithTag("greenRockTag");
        GameObject[] taggedRocks2 = GameObject.FindGameObjectsWithTag("yellowRockTag");
       if(col.gameObject.tag == "whiteRockTag"){
           if(taggedRocks[0] ==null)
           GameObject.Destroy(taggedRocks[1]);
           GameObject.Destroy(taggedRocks[0]);
       }
        if(col.gameObject.tag == "greenRockTag"){
           GameObject.Destroy(taggedRocks1[0]);
       }
       if(col.gameObject.tag == "yellowRockTag"){
          GameObject.Destroy(taggedRocks2[0]);
       }
    }
}
