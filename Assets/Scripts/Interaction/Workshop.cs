using UnityEngine;

public class Workshop : MonoBehaviour
{
    [SerializeField]
    private WorkshopType type;
    [SerializeField]
    private Transform workPos;
    public float remainingActions;
    public float workSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Work(GameObject worker)
    {
        worker.transform.position = workPos.position;
        switch (type)
        {

            case WorkshopType.TownHall:

                break;

            case WorkshopType.Forge:

                break;

            case WorkshopType.Shaft:

                break;

            case WorkshopType.Stockpile:

                break;

            case WorkshopType.Farm:

                break;

            case WorkshopType.Woodplace:

                break;

        }
    }

    public enum WorkshopType
    {
        TownHall,
        Forge,
        Shaft,
        Woodplace,
        Stockpile,
        Farm,

    }
}
