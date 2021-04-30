using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOnMethods : MonoBehaviour
{
    //When you get some kind of Keycode...

    //Change color of Go=======>Keycode.Z

    //Change size of Go========>Keycode.Q,E

    //Rotate Go================>Keycode.WASD

    public GameObject targetGo;

    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private GameObject Go;


    [SerializeField]
    private Material[] materials;

    private int count = 0;
    private string rotateKeycode;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //print(Input.mousePosition);
        //Physics.Raycast()
        List<GameObject> listHits = new List<GameObject>();
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            print($"{hit.collider.tag}");
            if (Input.GetMouseButtonDown(0) && !listHits.Contains(hit.transform.gameObject))
            {
                hit.collider.GetComponent<MeshRenderer>().material.color = Color.yellow;
                listHits.Add(hit.transform.gameObject);

            }

            if (listHits.Count > 0)
            {
                foreach (var go in listHits)
                {
                    go.transform.position = mainCamera.ScreenToWorldPoint(Input.mousePosition) - new Vector3(0, mainCamera.transform.position.y, 0);

                }
            }
        }

        //Change color of Go=======>Keycode.Z
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Go.GetComponent<MeshRenderer>().material = materials[count];
            count++;
            if (count > 6)
            {
                count = 0;
            }
        }
        //Change size of Go========>Keycode.Q,E
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Go.transform.localScale == Vector3.one * 20)
            {
                return;
            }
            Go.transform.localScale += Vector3.one;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Go.transform.localScale == Vector3.one)
            {
                return;
            }
            Go.transform.localScale -= Vector3.one;
        }


        //Rotate Go================>Keycode.WASD
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    Go.transform.Rotate(Vector3.up, 30);
        //}

        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    Go.transform.Rotate(Vector3.up, -30);
        //}

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    Go.transform.Rotate(Vector3.forward, 30);
        //}

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    Go.transform.Rotate(Vector3.forward, -30);
        //}

        if (Input.anyKey)
        {
            rotateKeycode = Input.inputString.ToLower();

            print(rotateKeycode);

            switch (rotateKeycode)
            {
                case "w":
                    print("WWWWWWWWWW");
                    Go.transform.Rotate(Vector3.up, 30);
                    break;
                case "s":
                    print("SSSSSSSSSS");
                    Go.transform.Rotate(Vector3.up, -30);
                    break;
                case "a":
                    print("AAAAAAAAAA");
                    Go.transform.Rotate(Vector3.forward, 30);
                    break;
                case "d":
                    print("WWWWWWWWWW");
                    Go.transform.Rotate(Vector3.forward, -30);
                    break;
                default:
                    break;
            }
        }

        //switch (rotateKeycode)
        //{
        //    case KeyCode.W:
        //        print("WWWWWWWWWW");
        //        Go.transform.Rotate(Vector3.up, 30);
        //        break;
        //    case KeyCode.S:
        //        print("SSSSSSSSSS");
        //        Go.transform.Rotate(Vector3.up, -30);
        //        break;
        //    case KeyCode.A:
        //        print("AAAAAAAAAA");
        //        Go.transform.Rotate(Vector3.forward, 30);
        //        break;
        //    case KeyCode.D:
        //        print("WWWWWWWWWW");
        //        Go.transform.Rotate(Vector3.forward, -30);
        //        break;
        //    default:
        //        break;
        //}


    }
}