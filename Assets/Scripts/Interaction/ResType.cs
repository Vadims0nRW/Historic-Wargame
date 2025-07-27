using UnityEngine;

namespace Resource_System
{
    public class ResType : MonoBehaviour
    {

        public enum ResourceType
        {
            Wood = 1,
            Stone = 2,
            Iron = 3,
        }
        public ResourceType Rtype;
        public int ResId;
        public int amount;
        void Start()
        {
            ResId = (int)Rtype;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}