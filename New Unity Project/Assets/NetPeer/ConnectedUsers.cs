using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.NetPeer
{
    public class ConnectedUsers : MonoBehaviour
    {

        private static ConnectedUsers _instance;

        public static ConnectedUsers Instance { get { return _instance; } }

        private Dictionary<int, OtherPlayer> registeredUsers;
        

        public ConnectedUsers()
        {
            registeredUsers = new Dictionary<int, OtherPlayer>();
            System.Random rand = new System.Random();

        }

        public void UpdatePos(int id, Vector3 postition)
        {
            /*
            if (!registeredUsers.ContainsKey(id))
            {
                registeredUsers.Add(id, new OtherPlayer(id));
            }

            registeredUsers[id].position = postition;*/
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }
    }
}
