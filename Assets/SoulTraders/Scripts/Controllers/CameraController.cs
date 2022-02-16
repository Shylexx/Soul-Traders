using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulTraders.Controller
{
    public class CameraController : MonoBehaviour
    {

        public Camera mainCam;

        void Awake()
        {
            mainCam = GetComponent<Camera>();
        }
    }
}