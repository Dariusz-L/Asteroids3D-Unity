using Core.Objects;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class UiText : UnityObject
    {
        public Text text { get; private set; }

        public override GameObject go {
            get {
                return base.go;
            }

            set {
                base.go = value;
                text = base.go.GetComponent<Text>();
            }
        }
    }
}
