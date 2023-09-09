using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Grid : MonoBehaviour
{
    public GameObject prefab;
    public GameObject rubyPrefab;
    public GameObject stonePrefab;
    public GameObject copperPrefab;
    public GameObject hardStonePrefab;
    public int gridX = -3;
    public int gridY = -5;
    public float spacing = 2f;
    int blocksToSkip = 0;
    void Start()
    {


        for (int y = 0; y > gridY; y--)
        {

            for (int x = 0; x < gridX; x++)
            {
                if(blocksToSkip > 0 && Random.Range(0, 100) <= 89)
                {
                    blocksToSkip--;
                    continue;
                }
                GameObject currObj;

                if(Random.Range(1, 10000) <= 5)
                {
                    blocksToSkip = Random.Range(90, 180);
                }
                // Ruby
                if (GenerateBlock(x, y, rubyPrefab, -60, 5, 1000))
                {
                    continue;
                }
                
                //Copper
                if(GenerateBlock(x, y, copperPrefab, -20, -50, 1, 100))
                {
                    continue;
                }
                // Terra
                if(y > -20)
                {
                    currObj = Instantiate(prefab, Vector2.zero, Quaternion.identity, transform);
                    currObj.transform.localPosition = new Vector3(x, y, 0) * spacing;
                    continue;
                }

                //Transiçao de terra
                if(y <= -20 && y > -28 )
                {
                    if (Random.Range(0, 100) <= 75)
                    {
                        currObj = Instantiate(prefab, Vector2.zero, Quaternion.identity, transform);
                        currObj.transform.localPosition = new Vector3(x, y, 0) * spacing;
                        continue;
                    }
                }
                //Pedra
                if(GenerateBlock(x,y, stonePrefab,-19, -120,100, 100))
                {

                    continue;
                }

                currObj = Instantiate(hardStonePrefab, Vector2.zero, Quaternion.identity, transform);
                currObj.transform.localPosition = new Vector3(x, y, 0) * spacing;
            }
        }
    }

    bool GenerateBlock(int x, int y, GameObject prefab, int yUnder, int probability, int randomRange)
    {
        GameObject currObj;
        if (Random.Range(0, randomRange) <= probability   && y < yUnder)
        {
            currObj = Instantiate(prefab, Vector2.zero, Quaternion.identity, transform);
            currObj.transform.localPosition = new Vector3(x, y, 0) * spacing;
            return true;
        }
        return false;
    }

    bool GenerateBlock(int x, int y, GameObject prefab, int yUnder, int yUpper, int probability, int randomRange)
    {
        GameObject currObj;
        if (Random.Range(0, randomRange) <= probability && y < yUnder && y > yUpper)
        {
            currObj = Instantiate(prefab, Vector2.zero, Quaternion.identity, transform);
            currObj.transform.localPosition = new Vector3(x, y, 0) * spacing;
            return true;
        }
        return false;
    }

    
}
