using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class Grid : MonoBehaviour
{
    public GameObject prefab;
    public GameObject stonePrefab;
    public GameObject hardStonePrefab;
    public GameObject magmaStonePrefab;

    public GameObject copperPrefab;
    public GameObject ironPrefab;
    public GameObject tungstenPrefab;
    public GameObject rubyPrefab;

    public int gridX = -3;
    public int gridY = -5;
    public float spacing = 2f;
    int blocksToSkip = 0;


    public int cavernScale;
    public int seed;

    public BreakableBlock[,] blocks;
    void Start()
    {
        blocks = new BreakableBlock[gridX, gridY];

        for (int y = 0; y > (-gridY); y--)
        {

            for (int x = 0; x < gridX; x++)
            {
                if (blocksToSkip > 0 && Random.Range(0, 100) <= 89)
                {
                    blocksToSkip--;
                    continue;
                }
                GameObject currObj;



                if (Random.Range(1, 10000) <= 5)
                {
                    blocksToSkip = Random.Range(90, 180);
                }


                //Iron
                if (GenerateBlock(x, y, ironPrefab, -30, -60, 1, 100))
                {
                    continue;
                }

                //Tungsten
                if (GenerateBlock(x, y, tungstenPrefab, -50, -100, 1, 100))
                {
                    continue;
                }

                //Copper
                if (GenerateBlock(x, y, copperPrefab, -20, -50, 1, 100))
                {
                    continue;
                }

                // Ruby
                if (GenerateBlock(x, y, rubyPrefab, -60, 5, 1000))
                {
                    continue;
                }


                // Terra
                if (y > -20)
                {
                    currObj = Instantiate(prefab, Vector2.zero, Quaternion.identity, transform);
                    currObj.transform.localPosition = new Vector3(x, y, 0) * spacing;
                    continue;
                }

                //Dirt transition
               
                if (GenerateBlock(x, y, prefab, -19, -28, 75, 100))
                {

                    continue;

                }

                //Stone
                if (GenerateBlock(x, y, stonePrefab, -19, -120, 100, 100))
                {

                    continue;
                }


                //Stone transition
                if (GenerateBlock(x, y, stonePrefab, -119, -128, 75, 100))
                {

                    continue;

                }

                if (GenerateBlock(x, y, hardStonePrefab, -119, -200, 100, 100))
                {
                    continue;
                }

                if (GenerateBlock(x, y, hardStonePrefab, -199, -208, 75, 100))
                { 
                    continue;
                }

                currObj = Instantiate(magmaStonePrefab, Vector2.zero, Quaternion.identity, transform);
                currObj.transform.localPosition = new Vector3(x, y, 0) * spacing;
                blocks[Mathf.Abs(x), Mathf.Abs(y)] = currObj.GetComponent<BreakableBlock>();

                CarveBlocks();
            }
        }
    }
    float[,] GenerateCaverns()
    {
        float[,] pixels = new float[gridX, gridY];
        for (int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
               pixels[x, y] = CalculatePerlinPosition(x, y);
                Debug.Log(CalculatePerlinPosition(x, y));
            }
        }

        return pixels;
        
    }


    float CalculatePerlinPosition(int x, int y)
    {

        float xCoord = ((float)x / gridX) * cavernScale + seed;
        float yCoord = ((float)y / gridY) * cavernScale + seed;

        Debug.Log(Mathf.PerlinNoise(xCoord, yCoord));
        return Mathf.PerlinNoise(xCoord, yCoord);
    }
    void CarveBlocks()
    {
        Debug.Log("AA");
        float[,] pixels = GenerateCaverns();
        for (int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                Debug.Log(pixels[x, y]);
                if (pixels[x,y] == 0)
                {
                    Destroy(blocks[x, y]);
                    Debug.Log("Destroyed");
                }
            }
        }
    }

    bool GenerateBlock(int x, int y, GameObject prefab, int yUnder, int probability, int randomRange)
    {
        GameObject currObj;
        if (Random.Range(0, randomRange) <= probability && y < yUnder)
        {
            currObj = Instantiate(prefab, Vector2.zero, Quaternion.identity, transform);
            currObj.transform.localPosition = new Vector3(x, y, 0) * spacing;
            blocks[Mathf.Abs(x), Mathf.Abs(y)] = currObj.GetComponent<BreakableBlock>();
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
            blocks[Mathf.Abs(x), Mathf.Abs(y)] = currObj.GetComponent<BreakableBlock>();
            return true;
        }
        return false;
    }


}
