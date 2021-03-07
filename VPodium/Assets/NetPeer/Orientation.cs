using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace NetPeer
{
    public class Orientation
    {
        public Orientation (float vertical, float horizontal)
        {
            this.Vertical = vertical;
            this.Horizontal = horizontal;
        }
        public float Vertical { get; set; }
        public float Horizontal { get; set; }

    }
}
