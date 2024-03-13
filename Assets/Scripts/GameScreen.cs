using System;
using Cinemachine;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public struct GameScreen
    {
        public GameObject UI;
        public CinemachineVirtualCamera Camera;
        public int Owner;
        public ScreenTypes type;
    }
}