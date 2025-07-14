using UnityEngine;

namespace Interaction
{
    public class Interactable : MonoBehaviour
    {
       
        public InteractionType type;

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
                    gameObject.GetComponent<Resource>().PickUp(user);
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
