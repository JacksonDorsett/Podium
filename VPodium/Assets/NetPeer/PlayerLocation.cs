using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetPeer
{
    public class PlayerLocation : MonoBehaviour
    {
        public PlayerLocation(int id, Vector3 position, Orientation orientation)
        {
            Position = position;
            Orientation = orientation;
        }

        // Start is called before the first frame update


        public Vector3 Position { get; set; }

        public Orientation Orientation { get; set; }

        public int ID { get; private set; }

        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
