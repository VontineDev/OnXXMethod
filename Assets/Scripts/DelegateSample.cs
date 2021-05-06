using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventArgs : EventArgs
{
    public PlayerInfo playerInfo;
}


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

    //이벤트핸들러인경우

    public event EventHandler SaveEvent;
    public event EventHandler LoadEvent;

    public event EventHandler SavePlayerEvent;
    public event EventHandler LoadPlayerEvent;

    #endregion

    #region Methods
    public void SavePlayerEventOperation(PlayerEventArgs playerEventArgs)
    {
        SavePlayerEvent?.Invoke(this, playerEventArgs);
    }
    public void LoadPlayerEventOperation(PlayerEventArgs playerEventArgs)
    {
        LoadPlayerEvent?.Invoke(this, playerEventArgs);
    }
    public void SaveOperation()
    {
        SaveOperate?.Invoke();

        //조건식 ? 트루일경우: 폴스일경우; 삼항연산자
    }
    public void LoadOperation()
    {
        LoadOperate?.Invoke();
    }

    public void SaveEventOperation()
    {
        SaveEvent?.Invoke(this, EventArgs.Empty);  //매개변수가 아직은 없다
    }
    public void LoadEventOperation()
    {
        LoadEvent?.Invoke(this, EventArgs.Empty);  //매개변수가 아직은 없다
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
