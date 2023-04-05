using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [SerializeField] private short hp;
    public Vector3 monsterRespawnPosition;
    public Slider HPBar;

    public short HP
    {
        get { return hp; }  
        set
        {
            hp = value;
            HPBar.value = hp;
            Debug.Log(hp);
            if (hp < 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void ResetHPBar()
    {
        //추후 리스폰 매니저 추가하여 active와 RespawnPosition으로 초기화 필요
        HPBar.maxValue = hp;
        HPBar.value = hp;
    }
   private void Start()
    {
        ResetHPBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
