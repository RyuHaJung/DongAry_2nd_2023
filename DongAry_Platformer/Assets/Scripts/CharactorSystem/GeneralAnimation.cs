using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterStates
{
    Idle, Run, Attack, Jump, Die
}
public class GeneralAnimation : StatSystem
{
    protected CharacterStates nowState;
    protected virtual void StateUpdate(CharacterStates newState)  //상태값을 String값으로 변환하여 코루틴을 실행하게 해준다(코루틴 함수와 상태값의 이름이 같음)
    {
        StopCoroutine(nowState.ToString());
        nowState = newState;
        Debug.Log(nowState);
        StartCoroutine(nowState.ToString());
    }
    IEnumerator Idle()
    {
        while(true)
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
}
