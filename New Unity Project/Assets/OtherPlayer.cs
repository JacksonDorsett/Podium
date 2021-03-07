using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    class OtherPlayer : MonoBehaviour
    {
        int ID;
        public Vector3 position { get; set; }
        GameObject model;

        public OtherPlayer(int id)
        {
            ID = id;

            InitModel();
            model.transform.position = position;
        }

        private void Update()
        {
            
        }

        private void InitModel()
        {
            model = GameObject.Instantiate(GlobalControl.Instance.player);
            Destroy(model.GetComponent<MouseHandler>());
        }
    }
}
