using System;
using UnityEngine;

namespace Core.Scripts.Collisions
{
    public class OnCollisionExitScript : MonoBehaviour
    {
        public Action<Collision> method;

        void OnCollisionExit(Collision other) {
            if (method != null) {
                method(other);
            }
        }
    }
}