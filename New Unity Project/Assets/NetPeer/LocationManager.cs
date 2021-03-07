using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using NetPeer;
namespace Assets
{
    class LocationManager : MonoBehaviour
    {
        private static LocationManager mInstance = null;
        private int currentUserID;
        Dictionary<int, PlayerLocation> locationDictionary;
        private LocationManager() {
            mInstance = this;
            this.locationDictionary = new Dictionary<int, PlayerLocation>();
            currentUserID = 1;
        }

        public LocationManager Instance
        {
            get
            {
                if (mInstance == null) mInstance = new LocationManager();
                return mInstance;
            }
        }

        public PlayerLocation AddPlayer(Vector3 position, Orientation orientation)
        {
            PlayerLocation loc = new PlayerLocation(GetNextUserID(), position, orientation);
            this.locationDictionary.Add(loc.ID, loc);
            return loc;
        }

        public bool RemovePlayer(int id)
        {
            if (!locationDictionary.ContainsKey(id)) return false;

            locationDictionary.Remove(id);
            return true;
        }

        /// <summary>
        /// gets the next available UserId and iterates the stored current user id by 1.
        /// </summary>
        /// <returns>returns the next available userID</returns>
        private int GetNextUserID()
        {
            return currentUserID++;
        }
    }
}
