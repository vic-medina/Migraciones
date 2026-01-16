using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealt : MonoBehaviour
{
    [SerializeField] private List<GameObject> heartIcons;

    public void Restart()
    {
        UpdateUIHealt(heartIcons.Count);
    }

    public void UpdateUIHealt(int remainingHealt)
    {
        for (int i = 0; i < heartIcons.Count; i++)
        {
            if (i < remainingHealt)
            {
                heartIcons[i].SetActive(true);
                heartIcons[i].transform.DOScale(Vector3.one, 0.2f);
            }
            else
            {
                int index = i;
                heartIcons[index].transform.DOScale(Vector3.zero, 0.2f).OnComplete(() =>
                {
                    heartIcons[index].SetActive(false);
                });
            }
        }
    }
}
