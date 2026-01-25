using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public List<ParallaxBG> backgroundParallax = new List<ParallaxBG>();
    public List<Vector2> parallaxSpeedBufferList = new List<Vector2>();

    public void Restart()
    {
        FreezeBackground();
    }

    public void UnfreezeBackground()
    {
        for (int i = 0; i < backgroundParallax.Count; i++)
        {
            if (i < parallaxSpeedBufferList.Count)
            {
                backgroundParallax[i].movementSpeed = parallaxSpeedBufferList[i];
            }
        }
    }

    public void FreezeBackground()
    {
        foreach (ParallaxBG bg in backgroundParallax)
        {
            parallaxSpeedBufferList.Add(bg.movementSpeed);
            bg.movementSpeed = Vector2.zero;
        }
    }

}
