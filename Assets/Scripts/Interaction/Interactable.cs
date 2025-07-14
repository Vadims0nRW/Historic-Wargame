using UnityEngine;

namespace Interaction
{
    public class Interactable : MonoBehaviour
    {
       
        public InteractionType type;
       // public GameObject Resource_System;
        void Start()
        {

        }



        public void Interact(GameObject user)
        {
            switch (type)
            {
                case InteractionType.Workshop:
                    gameObject.GetComponent<Workshop>().Work(user);
                    break;

                case InteractionType.NPC:
                    gameObject.GetComponent<TalkToNPC>().Talk(user);
                    break;

                case InteractionType.Artillery:
                    gameObject.GetComponent<Artillery>().UseArtillery(user);
                    break;

                case InteractionType.Resource:
                    {
                        int Rid = gameObject.GetComponent<ResType>().ResId;
                        int Ramnt = gameObject.GetComponent<ResType>().amount;
                        user.GetComponent<Resource>().Add_Resource(Rid, Ramnt);
                    }
                    break;
            }
        }
    }

    public enum InteractionType
    {
        Workshop,
        NPC,
        Artillery,
        Resource,
        Others,
    }

}
