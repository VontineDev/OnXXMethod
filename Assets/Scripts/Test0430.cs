using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Test0430 : MonoBehaviour
{
    public GameObject cubeGo;
    public GameObject sphereGo;

    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Text textPrefab;
    public List<Text> listTexts;

    [SerializeField]
    private GameObject nonamePrefab;
    private GameObject noname;
    [SerializeField]
    private InputField nameOfNoname;

    public UnityEvent<string> unityEvent;
    //public enum eColor { yellow , green, red, black }
    // Start is called before the first frame update
    void Start()
    {
        //make instance of listTexts
        listTexts = new List<Text>();

        //큐브 비활성
        cubeGo.SetActive(false);

        ////Find all gameobject
        //var arrGo = FindObjectsOfType<GameObject>();

        ////eColor count = 0;
        //foreach (var Go in arrGo)
        //{
        //    print($"Name : {Go.name}");

        //    Go.AddComponent<Rigidbody>();
        //    Go.GetComponent<MeshRenderer>().material.color = Color.black;
        //    // Go.GetComponent<Rigidbody>().;
        //}


        //when inputfield nameOfNoname changes
        nameOfNoname.onValueChanged.AddListener((name) =>
        {
            print("OVC");

            noname.name = name;
        });

    }



    //void ChangeNameOfNoname()
    //{
    //    noname.name = nameOfNoname.text;
    //}
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    if (cubeGo.activeInHierarchy)
        //    {
        //        cubeGo.SetActive(false);
        //    }
        //    else
        //    {
        //        cubeGo.SetActive(true);
        //    }

        //    // or OtherWay

        //    // cubeGo.SetActive(!cubeGo.activeSelf);

        //}

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    sphereGo.SetActive(true);

        //    return;
        //}
        //sphereGo.SetActive(false);


        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    MakeText();
        //}

        if (Input.GetKeyDown(KeyCode.M))
        {
            noname = Instantiate(nonamePrefab);
        }
    }
    void MakeText()
    {
        var text = Instantiate<Text>(textPrefab);
        text.transform.SetParent(canvas.transform);

        int h = Random.Range(80, 1840);     //80,1840
        int v = Random.Range(15, 1065);     //15,1065

        text.transform.position = new Vector3(h, v, 0);

        int textNum = Random.Range(0, 46); // Random 0~45

        text.text = textNum.ToString();

        listTexts.Add(text);
    }

}
