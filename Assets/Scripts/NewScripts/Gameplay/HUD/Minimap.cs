using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class MigrationLocation
{
    public string name;
    public Vector2 location;
}

namespace Pabio.Migraciones.Displays
{
    public class Minimap : MonoBehaviour
    {
        [Header("Player Location")]
        public RectTransform currentPos;
        private Vector2 initialPos;
        [SerializeField] private Vector2 nextPos;
        [SerializeField] private List<MigrationLocation> migrationLocations = new List<MigrationLocation>();

        [Header("Display Settings")]
        public TextMeshProUGUI zoneTxt;
        [SerializeField] private float displayFadeTime;
        [SerializeField] private float moveTime;

        [Header("References")]
        public CanvasGroup zoneCanvas;

        public void Awake()
        {
            initialPos = currentPos.anchoredPosition;
        }

        public void Restart()
        {
            currentPos.anchoredPosition = initialPos;
            zoneCanvas.alpha = 0f;
        }

        public void NextLocation(int index)
        {
            var nextLocation = migrationLocations[index];
            zoneTxt.text = nextLocation.name;
            nextPos = nextLocation.location;

            ShowNewLocation();
            MovePlayerPositionInMap();
        }

        private void ShowNewLocation()
        {
            zoneCanvas.DOFade(1, displayFadeTime).OnComplete(() => zoneCanvas.DOFade(0, displayFadeTime));
        }

        private void MovePlayerPositionInMap()
        {
            currentPos.DOAnchorPos(nextPos, moveTime);
        }
    }

}