using Migraciones.General;
using UnityEngine;

public class GeneralAnimator : MonoBehaviour
{
    [SerializeField] private Animator[] targets;
    [SerializeField] private string boolName = "default";
    [SerializeField, Range(.5f, 2f)] private float cdTime = 0.5f;

    private bool canAnimate = true;
    private Timer timer;

    void Start()
    {
        timer = new Timer(cdTime);

        timer.onTargetReached += () =>
        {
            canAnimate = true;
        };
    }

    void Update()
    {
        timer.Tick(Time.deltaTime);

        if (!canAnimate) return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetStateTo(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetStateTo(false);
        }
    }

    public void Restart()
    {
        timer = new Timer(cdTime);
        canAnimate = true;
        timer.Restart();
    }

    public void SetStateTo(bool state)
    {
        foreach (var target in targets)
        {
            target.SetBool(boolName, state);
        }

        canAnimate = false;
        timer.Restart();
        timer.Resume();
    }
}