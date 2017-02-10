using UnityEngine;

namespace Core.Objects
{
    public class PhysicalObject : UnityObject
    {
        public Rigidbody rb { get; private set; }
        public Collider  collider { get; private set; }

        public override GameObject go {
            get {
                return base.go;
            }

            set {
                base.go = value;
                rb = base.go.GetComponent<Rigidbody>();
                collider = base.go.GetComponent<Collider>();
            }
        }
    }
}