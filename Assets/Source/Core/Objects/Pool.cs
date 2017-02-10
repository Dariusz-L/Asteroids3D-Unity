using System.Collections.Generic;
using UnityEngine;

namespace Core.Objects
{
    public class Pool<T> where T : UnityObject, new()
    {
        public List<T> allObjects { get; private set; }

        public List<T> activeObjects { get; private set; }
        public List<T> inactiveObjects { get; private set; }

        public Pool(GameObject prefab, int size, Transform parent = null) {
            allObjects = new List<T>(size);
            activeObjects = new List<T>(size);
            inactiveObjects = new List<T>(size);

            for (int i = 0; i < size; i++) {
                GameObject go = MonoBehaviour.Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
                go.SetActive(false);

                UnityObject obj = new T();
                obj.go = go;
                allObjects.Add((T) obj);
                inactiveObjects.Add((T) obj);

                if (parent) {
                    obj.transform.SetParent(parent);
                }
            }
        }

        public T GetNext() {
            T obj = null;

            if (inactiveObjects.Count > 0) {
                obj = inactiveObjects[0];
                activeObjects.Add(obj);
                inactiveObjects.Remove(obj);
            } else { 
                obj = activeObjects[0];
            }

            obj.go.SetActive(true);

            return obj;
        }

        public void Destroy() {
            foreach (var obj in allObjects) { 
                MonoBehaviour.Destroy(obj.go);
            }

            allObjects.Clear();
            activeObjects.Clear();
            inactiveObjects.Clear();

            allObjects = null;
            activeObjects = null;
            inactiveObjects = null;
        }

        public void DisableObject(T obj) {
            obj.transform.position = Vector3.zero;
            obj.transform.rotation = Quaternion.identity;
            obj.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            obj.go.SetActive(false);

            activeObjects.Remove(obj);
            
            if (!inactiveObjects.Contains(obj)) {
                inactiveObjects.Add(obj);
            }
        }

        public void Reset() {
            foreach (var obj in activeObjects) {
                DisableObject(obj);
            }

            activeObjects.Clear();
            inactiveObjects.Clear();
             
            foreach (var obj in allObjects) {
                inactiveObjects.Add(obj);
            }
        }
    }
}