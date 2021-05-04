using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateSample : MonoBehaviour
{
    #region Property

    public static DelegateSample Instance
    {
        get; set;
    }
    #endregion

    #region Event(delegate)
    public event Action SaveOperate;
    public event Action LoadOperate;

    //�̺�Ʈ�ڵ鷯�ΰ��

    public event EventHandler SaveEvent;
    public event EventHandler LoadEvent;


    #endregion

    #region Methods
    public void SaveOperation()
    {
        SaveOperate?.Invoke();

        //���ǽ� ? Ʈ���ϰ��: �����ϰ��; ���׿�����
    }
    public void LoadOperation()
    {
        LoadOperate?.Invoke();
    }

    public void SaveEventOperation()
    {
        SaveEvent?.Invoke(this, EventArgs.Empty);  //�Ű������� ������ ����
    }
    public void LoadEventOperation()
    {
        LoadEvent?.Invoke(this, EventArgs.Empty);  //�Ű������� ������ ����
    }

    #endregion

    #region Unity built in methods
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion




}
