using UnityEngine;

namespace Core.Objects
{
    public class Particles : UnityObject
    {
        public ParticleSystem system { get; private set; }

        public void Play(Vector3 pos) {
            transform.position = pos;
            system.Play();
        }

        public override GameObject go {
            get {
                return base.go;
            }

            set {
                base.go = value;
                system = base.go.GetComponent<ParticleSystem>();
            }
        }
    }
}
