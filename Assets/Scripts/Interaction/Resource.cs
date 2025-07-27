using UnityEngine;

namespace Resource_System
{
    public class Resource : MonoBehaviour
    {
        public int max_res;
        public int current_res;
        public int current_wood;
        public int current_rock;
        public int current_iron;
        // Start is called before the first frame update
        void Start()
        {
            current_res = 0;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PickUp(GameObject user)
        {

        }
        public void Add_Resource(int id, int res)
        {
            switch (id)
            {
                case 1:
                    current_wood = current_wood + res;
                    break;
                case 2:
                    current_rock = current_rock + res;
                    break;
                case 3:
                    current_iron = current_iron + res;
                    break;
            }



        }
        public void Remove_res(int id, int res)
        {
            switch (id)
            {
                case 1:
                    current_wood = current_wood - res;
                    break;
                case 2:
                    current_rock = current_rock - res;
                    break;
                case 3:
                    current_iron = current_iron - res;
                    break;
            }
        }


    }
}