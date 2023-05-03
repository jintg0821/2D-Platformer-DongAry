using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterStates
{
    Idle,Run,Attack,Jump,Die
}

public class GeneralAnimation : StatSystem
{
    protected CharacterStates nowState;

    protected virtual void StateUpdate(CharacterStates newState) 
    {
        StopCoroutine(nowState.ToString());
        nowState = newState;
        Debug.Log(nowState);    //상태 표시
        StartCoroutine(nowState.ToString());
    }

    IEnumerator Idle()
    {
        while (true)
        {
            yield return null;
        }
    }
    IEnumerator Run()
    {
        while (true)
        {
            yield return null;
        }
    }
    IEnumerator Attack()
    {
        while (true)
        {
            yield return null;
        }
    }
    IEnumerator Jump()
    {
        while (true)
        {
            yield return null;
        }
    }
    IEnumerator Die()
    {
        while (true)
        {
            yield return null;
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
}
