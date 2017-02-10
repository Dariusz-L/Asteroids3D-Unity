using Core.Controllers;
using Core.Scripts;
using UnityEngine;

namespace Core.Utils
{
    public class GetUtil
    {
        public static T GetObjectController<T>()  where T : GameController {
            UnityScene scene = GameObject.FindObjectOfType<UnityScene>();
            T objectController = scene.gameController as T;
            return objectController;
        }
    }
}
