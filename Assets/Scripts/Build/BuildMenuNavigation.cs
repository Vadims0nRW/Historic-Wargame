using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenuNavigation : MonoBehaviour
{
    [Header("Categories")]
    public GameObject Houses;
    public GameObject Res;
    public GameObject Job;
    public GameObject Others;

    [Header("Screens")]
    public GameObject HouseScr;
    public GameObject ResScr;
    public GameObject JobScr;
    public GameObject OtScr;

    public GameObject cam;
    public RaycastHit hit;
    void Start()
    {
        HouseScr.SetActive(false);
        ResScr.SetActive(false);
        JobScr.SetActive(false);
        OtScr.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
      

    }

    public void CallHouseScreen()
    {
        HouseScr.SetActive(true);
        ResScr.SetActive(false);
        JobScr.SetActive(false);
        OtScr.SetActive(false);
    }

    public void CallResScreen()
    {
        HouseScr.SetActive(false);
        ResScr.SetActive(true);
        JobScr.SetActive(false);
        OtScr.SetActive(false);
    }

    public void CallJobScreen()
    {
        HouseScr.SetActive(false);
        ResScr.SetActive(false);
        JobScr.SetActive(true);
        OtScr.SetActive(false);
    }

    public void CallOtherScreen()
    {
        HouseScr.SetActive(false);
        ResScr.SetActive(false);
        JobScr.SetActive(false);
        OtScr.SetActive(true);
    }

    public void InstantiatePrefab(GameObject buildingPrefab)
    {
        Ray ray = new Ray();
        ray.origin = cam.transform.position;
        ray.direction = cam.transform.forward;
        Debug.DrawRay(cam.transform.position, cam.transform.forward * 20f, Color.blue);
        Physics.Raycast(ray, out hit, 10f, LayerMask.GetMask("Ground"));
        GameObject buildScheme = Instantiate(buildingPrefab,hit.point, new Quaternion());
   //   buildScheme.GetComponent<Material>().color = Color.green;
        buildScheme.GetComponent<Build_System.Building>().cam = cam;
    //    buildScheme.transform.SetParent(cam.transform);
        

    }
}
