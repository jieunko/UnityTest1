using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    // 플레이어 인스턴스의 관리
    // 컨트롤러 연동
    // UI기능 update

    public PlayerControl playerControl;

    void Awake()
    {
        //playerControl = FindObjectOfType<PlayerControl>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnEnable()
    {
        PlayerControl.onNotifyGotItemE += PlayerControl_onNotifyGotItemE;
    }

    public void OnDisable()
    {
        PlayerControl.onNotifyGotItemE -= PlayerControl_onNotifyGotItemE;
    }

    public void OnDestroy()
    {
        PlayerControl.onNotifyGotItemE -= PlayerControl_onNotifyGotItemE;
    }

    private void PlayerControl_onNotifyGotItemE(int itemCode)
    {
        int itemNum = itemCode;
        print("itemNum : " + itemNum.ToString() + " In GameManager");
    }





    public void GotAItem(ICommonItem commonItem)
    {
        //commonItem.GotItem();

        int itemNum = commonItem.GotItem();
        print("itemNum : " + itemNum.ToString() + " In GameManager");
    }





}
