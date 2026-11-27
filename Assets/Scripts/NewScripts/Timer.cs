using System;

namespace Migraciones.General
{
    public class Timer
    {
        public Action onTargetReached;

        private float target;
        private float count;
        private bool running;

        public Timer(float target)
        {
            this.target = target;
            count = target;
        }

        public void Tick(float deltaTime)
        {
            if (!running) return;

            count -= deltaTime;

            if (count <= 0f)
            {
                running = false;
                onTargetReached?.Invoke();
            }
        }

        public void Restart()
        {
            count = target;
        }

        public void Resume()
        {
            running = true;
        }

        public void Stop()
        {
            running = false;
        }
    }
}