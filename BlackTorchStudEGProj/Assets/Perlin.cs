using UnityEngine;
using System.Collections;

public class Perlin  {

    long seed;

    public Perlin(long seed)
    {
        this.seed = seed;
    }

    private int random(int x, int range)
    {
        return (int)((x+seed)^5)%range;
    }

    public int GetNoise(int x, int range)
    {
        int chunkSize = 16;
        int chunkIndex = x / chunkSize;

        float noise = 0;

        range /= 2;

        while (chunkSize > 0)
        {
            float distFromIndex = (x % chunkSize) / (chunkSize * 1.0f);

            float lRandom = random(chunkIndex, range);
            float rRandom = random(chunkIndex + 1, range);
            noise += (1 - distFromIndex) * lRandom + distFromIndex * rRandom;

            chunkSize /= 2;
            range /= 2;

            range = Mathf.Max(1, range);
        }
        return (int)Mathf.Round(noise);
    }
}
