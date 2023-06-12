using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class WorldMeneger : MonoBehaviour
{
    public static float Range { get; private set; } = 30;

    [SerializeField] private Transform worldPref;
    [SerializeField] private Transform worldSegment;
    [SerializeField] private Transform chest;
    [SerializeField] private Transform door;
    [SerializeField] private Transform wall;
    [SerializeField] private float range;

    private Transform world;

    private void Start()
    {
        // Assigning values from the editor to the static variable
        Range = range;
        newEvents.Sub("Start Game", GenerateTerrain);
        newEvents.Sub("Game Over", ReloadWorld);
    }

    private bool GenerateTerrain()
    {
        world = Instantiate(worldPref, Vector3.zero, Quaternion.identity);

        // Generating terrain with randomly rotated segments
        for (int i = 0; i < Range / 5; i++)
        {
            for (int j = 0; j < Range / 5; j++)
            {
                var segment = Instantiate(worldSegment, world);
                segment.position = new Vector3(i * 10 - Range + 5, 0f, j * 10 - Range + 5);
                segment.rotation = Quaternion.Euler(0f, Random.Range(0, 4) * 90, 0f);
            }
        }

        // Creating a chest at a random position
        var chestObj = Instantiate(chest, world);
        chestObj.position = new Vector3(Random.Range(-Range + 0.5f, Range - 0.5f), 0f, Random.Range(-Range + 0.5f, Range - 0.5f));

        // Creating a door at the edge of the world
        var doorObj = Instantiate(door, world);
        int random = Random.Range(1, 3);
        int random2 = Random.Range(0, 2) == 0 ? -1 : 1;

        switch (random)
        {
            case 1:
                doorObj.position = new Vector3(Random.Range(-Range + 0.5f, Range - 0.5f), 0f, random2 * (Range - 0.5f));
                break;

            case 2:
                doorObj.position = new Vector3(random2 * (Range - 0.5f), 0f, Random.Range(-Range + 0.5f, Range - 0.5f));
                break;
        }

        // Creating walls
        var wallObj = Instantiate(wall, new Vector3(0f, 0f, Range + 0.5f), Quaternion.identity);
        wallObj.localScale = new Vector3(Range * 2, 10f, 1f);
        wallObj.parent = world;

        wallObj = Instantiate(wall, new Vector3(0f, 0f, -Range - 0.5f), Quaternion.identity);
        wallObj.localScale = new Vector3(Range * 2, 10f, 1f);
        wallObj.parent = world;

        wallObj = Instantiate(wall, new Vector3(Range + 0.5f, 0f, 0f), Quaternion.identity);
        wallObj.localScale = new Vector3(1f, 10f, Range * 2);
        wallObj.parent = world;

        wallObj = Instantiate(wall, new Vector3(-Range - 0.5f, 0f, 0f), Quaternion.identity);
        wallObj.localScale = new Vector3(1f, 10f, Range * 2);
        wallObj.parent = world;

        return true;
    }

    private bool ReloadWorld()
    {
        // Removing the terrain
        if (world != null)
            Destroy(world.gameObject);

        return true;
    }
}
