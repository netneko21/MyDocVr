namespace FictionWare
{
    using UnityEngine;

    [System.Serializable]
    public class Gravity
    {
        public bool isCentric;
        public float value;
        public Vector3 vector;

        public Gravity(float value)
        {
            this.value = value;
        }

        public Vector3 GetDirection(Vector3 position)
        {
            return isCentric ? (vector - position).normalized : vector.normalized;
        }
    }
}

