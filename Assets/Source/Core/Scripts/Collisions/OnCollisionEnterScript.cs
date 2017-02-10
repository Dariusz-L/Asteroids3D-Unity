using System;
using UnityEngine;

namespace Core.Scripts.Collisions
{
    public class OnCollisionEnterScript : MonoBehaviour
    {
        public Action<Collision> method;

        void OnCollisionEnter(Collision other) {
            if (method != null) {
                method(other);
            }
        }
    }
}