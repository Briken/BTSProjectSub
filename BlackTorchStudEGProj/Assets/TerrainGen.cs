using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class TerrainGen : MonoBehaviour
{

    public int[,] terrainArray;

    Texture2D image;

    public InputField width;
    public InputField height;

    int minX = 0;
    int maxX = 192;
    int minY = 0;
    int maxY = 108;

    Color brown = new Color(0.533333f, 0.419608f, 0.184314f);


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GridGen()
    {
        image = new Texture2D(maxX, maxY);

        for (int x = 0; x < image.width; x++)
        {
            for (int y = 0; y < image.height; y++)
            {
                image.SetPixel(x, y, Color.blue);
            }

        }

        float colHeight = maxY / 2;

        for (int x = minX; x < maxX; x++)
        {

            colHeight += (Perlin.Noise(Random.Range(-0.5f, 0.5f)));
            for (int y = minY; y < minY + colHeight; y++)
            {
                if (((y <= minY + colHeight - 1) && y > ((colHeight / 4) * 3)))
                {
                    image.SetPixel(x, y, Color.green);
                }

                if (y < ((colHeight / 4) * 3) && y > (minY + colHeight - 1) / 2)
                {
                    image.SetPixel(x, y, brown);
                }



                if (y > minY && y < (minY + colHeight - 1) / 2)
                {
                    image.SetPixel(x, y, Color.grey);
                    if (x % 12 == 0 && y > minY + (maxY / 12))
                    {
                        int yes = (int)Random.Range(0, 100);
                        if (yes > 50)
                        {
                            image.SetPixel(x, y, Color.magenta);
                        }
                    }
                }

            }
        }
        byte[] nibble = image.EncodeToPNG();
        Object.Destroy(image);

        File.WriteAllBytes(Application.dataPath + "SAVEDIMAGE.png", nibble);
    }

    public void SetWidth()
    {
        maxX = int.Parse(width.text);
        Debug.Log(maxX.ToString());
    }

    public void SetHeight()
    {
        maxY = int.Parse(height.text);
        Debug.Log(maxY.ToString());
    }

}
