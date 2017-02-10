using UnityEngine;

namespace Core.Objects
{
    public class UnityObject
    {
        private GameObject _go;
        public Transform transform { get; private set; }

        public virtual GameObject go {
            get {
                return _go;
            }

            set {
                _go = value;
                transform = _go.transform;
            }
        }
    }
}
