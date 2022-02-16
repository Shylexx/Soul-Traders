using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoulTraders.Core;

namespace SoulTraders.Controller
{
    public class CameraController : MonoBehaviour
    {

        public Camera mainCam;

        public STControl model = STEvents.GetModel<STControl>();

        void Awake()
        {
            mainCam = GetComponent<Camera>();
        }

        void Update()
        {
            transform.position = new Vector3(model.playerController.transform.position.x, model.playerController.transform.position.y, -10);
        }
    }
}