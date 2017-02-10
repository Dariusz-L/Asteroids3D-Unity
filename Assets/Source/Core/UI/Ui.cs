using Core.Objects;
using UnityEngine;

namespace Core.UI
{
    public abstract class Ui : UnityObject
    {
        public Ui() {
            go = GameObject.Find("UI");
        }

        public virtual void Update() {}
    }
}
