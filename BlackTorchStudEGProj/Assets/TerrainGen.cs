using UnityEngine;
using System.Collections;

public class TerrainGen : MonoBehaviour {

    public GameObject[,] terrainArray;
    GameObject currentBlock;

    public GameObject dirt;
    public GameObject rock;
    public GameObject grass;
    public GameObject mineral;

    int minX = -16;
    int maxX = 16;
    int minY = -16;
    int maxY = 16;

    Perlin perlinNoise;

	// Use this for initialization
	void Start ()
    {
        perlinNoise = new Perlin(Random.Range(1000000, 100000000));
        GridGen();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    private void GridGen()
    {
        float width = dirt.transform.localScale.x;
        float height = dirt.transform.localScale.y;

        for (int x = minX; x < maxX; x++)
        {
            int colHeight = 2 + perlinNoise.GetNoise(x - minX, maxY - minY - 2);
            for (int y = minY; y < minY + colHeight; y++)
            {
                GameObject block = dirt;
                if ((y == minY + colHeight - 1))
                {
                    block = grass;
                }
                if (y == minY + colHeight)
                {
                    block = rock;
                }
                
                Instantiate(block, new Vector2(x /** width*/, y /** height*/), Quaternion.identity);

            }
        }
    }
}
