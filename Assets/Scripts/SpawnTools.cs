using UnityEngine;

public static class SpawnTools
{
    public static Vector3 RandomLocationScreenSpace()
    {
        float randomX = Random.Range(0, Screen.width);
        float randomY = Random.Range(0, Screen.height);

        return new Vector3(randomX, randomY, 10);
    }

    public static Vector3 RandomLocationWorldSpace()
    {
        Vector3 randomScreenLocation = RandomLocationScreenSpace();
        return Camera.main.ScreenToWorldPoint(randomScreenLocation);
    }

    public static Vector3 RandomTopOfScreenLocationScreenSpace()
    {
        float randomX = Random.Range(0, Screen.width);
        return new Vector3(randomX, Screen.height, 10);
    }

    public static Vector3 RandomTopOfScreenLocationWorldSpace()
    {
        Vector3 randomTopOfScreenLocation = RandomTopOfScreenLocationScreenSpace();
        return Camera.main.ScreenToWorldPoint(randomTopOfScreenLocation);
    }
    
    public static Vector3 CenterOfScreenLocationScreenSpace()
    {
        float middleX = Screen.width * 0.5f;
        float middleY = Screen.height * 0.7f;
        return new Vector3(middleX, middleY, 10);
    }
    
    public static Vector3 CenterOfScreenLocationWorldSpace()
    {
        Vector3 centerOfScreenLocationScreenSpace = CenterOfScreenLocationScreenSpace();
        return Camera.main.ScreenToWorldPoint(centerOfScreenLocationScreenSpace);
    }
}