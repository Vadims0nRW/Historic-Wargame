using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Build_System
{
    public class Building : MonoBehaviour
    {
        public GameObject cam;
        //  public Material GreenMat;
        // public Material RedMat;
        public bool isBuildable;
        private StarterAssetsInputs _input;
        private PlayerInput PlIn;
        //  private GameObject check;
        public int cols;
        public float rad = 10f;
        public float range;
        public Collider[] self;
        public int selfCols;
        public GameObject text;
        [Header("BoxSize")]
        [SerializeField] float boxX;
        [SerializeField] float boxY;
        [SerializeField] float boxZ;

        private float roty = 15f;


        void Start()
        {

            _input = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<StarterAssetsInputs>();
            PlIn = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerInput>();
            Debug.Log("Building Loaded");
            cam = Camera.main.gameObject;
            //    check = transform.Find("Check").gameObject;
            gameObject.GetComponent<Collider>().enabled = false;
            //    check.GetComponent<Renderer>().material.color = Color.green;
            //      check.GetComponent<Renderer>().material.color = Color.green;
            rad = 10f;
            text = FindObjectOfType<Canvas>().transform.Find("NotBuildable").gameObject;
            self = transform.GetComponentsInChildren<Collider>();
            for (int i = 0; i < self.Length; i++)
            {
                self[i].enabled = false;
            }

        }

        // Update is called once per frame
        void Update()
        {


            RaycastHit hit = new RaycastHit();
            Ray ray = new Ray();
            ray.origin = cam.transform.position;
            ray.direction = cam.transform.forward;
            Debug.DrawRay(cam.transform.position, cam.transform.forward * range, Color.green);
            Physics.Raycast(ray, out hit, 15f, LayerMask.GetMask("Ground"));
            transform.position = hit.point;

            Collider[] hits = Physics.OverlapBox(transform.position, new Vector3(boxX / 2, boxY / 2, boxZ / 2));

            cols = hits.Length - selfCols;
            if (cols == 1)
            {
                isBuildable = true;
                text.SetActive(false);
            }
            else
            {
                isBuildable = false;
                text.SetActive(true);
            }

            if (_input.turnr)
            {
                transform.Rotate(new Vector3(0, roty, 0));
                Debug.Log("Turned Right");
                _input.turnr = false;
            }

            if (_input.turnl)
            {
                transform.Rotate(new Vector3(0, -roty, 0));
                Debug.Log("Turned Left");
                _input.turnl = false;
            }

            if (_input.enter)
            {
                _input.enter = false;
                Build();
            }




            // else
            //   check.GetComponent<Renderer>().material.color = Color.red;






            if (_input.pause == true)
            {
                _input.pause = false;
                Destroy(gameObject);
            }
        }


        void Build()
        {
            if (isBuildable)
            {
                //  check.GetComponent<Renderer>().material.color = new Color(0.1f, 0.9f, 0f, 0.2f);



                //   check.GetComponent<Renderer>().material.color = new Color(0.1f, 0.9f, 0f, 0.2f);
                //     check.GetComponent<Material>().color = Color.white;
                gameObject.GetComponent<Collider>().enabled = true;
                //   check.SetActive(false);

                self = transform.GetComponentsInChildren<Collider>();
                for (int i = 0; i < self.Length; i++)
                {
                    self[i].enabled = true;
                }

                gameObject.GetComponent<Building>().enabled = false;

            }
        }

        void OnCollisionEnter(Collision coll)
        {
            //  if (!coll.gameObject.CompareTag("Ground"))
            cols++;
        }

        void OnCollisionExit(Collision coll)
        {
            //   if (!coll.gameObject.CompareTag("Ground"))
            cols--;
        }

        void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(boxX, boxY, boxZ));

        }
        void CheckCollision()
        {

        }
    }
}