using System;
using UnityEngine;

namespace Core.Scripts.Collisions
{
    public class OnTriggerExitScript : MonoBehaviour
    {
        public Action<Collider> method;

        void OnTriggerExit(Collider other) {
            if (method != null) {
                method(other);
            }
        }
    }
}