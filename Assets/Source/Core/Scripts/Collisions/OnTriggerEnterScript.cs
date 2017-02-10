using System;
using UnityEngine;

namespace Core.Scripts.Collisions
{
    public class OnTriggerEnterScript : MonoBehaviour
    {
        public Action<Collider> method;

        void OnTriggerEnter(Collider other) {
            if (method != null) {
                method(other);
            }
        }
    }
}
