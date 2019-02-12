using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public Texture2D map;
    public ColorToPrefab[] colorMappings;

	void Start () {

        GenerateMap();
	}

    void GenerateMap()
    {
        for (int i = 0; i < map.width; i++)
        {
            for (int j = 0; j < map.height; j++)
            {
                GenerateTile(i, j);
            }
        }
    }
	
    void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a <= 0)
        {
            return; //if transparent
        }
            //Debug.Log(pixelColor);
        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            //Debug.Log("PixelColor" + pixelColor);
            //Debug.Log("colorMapping.color" + colorMapping.color);
            if (colorMapping.color.Equals(pixelColor))
            {
                Vector2 position = new Vector2(x, y);
                Instantiate(colorMapping.prefab, position, colorMapping.prefab.transform.rotation, transform);
            }

        }
    }
}
