using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    class GlobalControl : MonoBehaviour
    {
        public static GlobalControl Instance;

        void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        public Socket playerSocket;
        public bool isHost;

        public MouseHandler MouseHandler;

        public GameObject player;

    }
}
