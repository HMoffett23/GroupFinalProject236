using UnityEngine;

public class TrapPlacer : MonoBehaviour
{
    public GameObject SpikesPrefab;

    public void Placer()
    {
        for (int i = 1; i <= GameParameters.NumberOfSpikes; i++)
        {
            PlacerRandomPosition();
        }
    }
    
    public void PlacerRandomPosition()
    {
        Instantiate(SpikesPrefab, SpawnTools.RandomTopOfScreenLocationWorldSpace(), Quaternion.identity);
    }
}
