using Core.Objects;
using UnityEngine;

namespace Game.Objects.Bullets
{
    public class Bullet : PhysicalObject
    {
        public float lifeTime { get; private set; }

        public void Reset() {
            lifeTime = 0.0f;
        }

        public void Update() {
            lifeTime += Time.deltaTime;
        }
    }
}