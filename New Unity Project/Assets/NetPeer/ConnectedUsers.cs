using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.NetPeer
{
    public class ConnectedUsers
    {
        int myID;
        private HashSet<int> registeredUsers;

        public ConnectedUsers()
        {
            registeredUsers = new HashSet<int>();
            Random rand = new Random();
            myID = rand.Next();

            registeredUsers.Add(myID);
        }

        public void Add(int id)
        {
            registeredUsers.Add(id);
        }

        
    }
}
