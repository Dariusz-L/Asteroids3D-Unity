using System;
using UnityEngine;

namespace Core.Scripts.Collisions
{
    public class OnTriggerStayScript : MonoBehaviour
    {
        public Action<Collider> method;

        void OnTriggerStay(Collider other) {
            if (method != null) {
                method(other);
            }
        }
    }
}
