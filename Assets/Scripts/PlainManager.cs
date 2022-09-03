using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlainManager : MonoBehaviour
{
    public float metallicCycleTime = 10f;
    public float iceCycleTime = 30f;
    public float echoCycleTime = 60f;
    public float pointCacheWeightCycleTime = 45f;
    public float pointCacheValueRange = 0.75f;
    public float pointCacheValueOffset = 0.5f;

    private float metalLerp;
    private float iceLerp;
    private float echoLerp;
    private float pointCacheWeightLerp;

    private void Update()
    {
        metalLerp = Mathf.PingPong(Time.time * 2 / metallicCycleTime, UndulatingPlainConstants.metalLerpValueRange) + UndulatingPlainConstants.metalLerpValueOffset;

        iceLerp = Mathf.PingPong(Time.time * 2 / iceCycleTime, UndulatingPlainConstants.iceLerpValueRange) + UndulatingPlainConstants.iceLerpValueOffset;

        echoLerp = Mathf.PingPong(Time.time * 2 / echoCycleTime, UndulatingPlainConstants.echoLerpValueRange) + UndulatingPlainConstants.echoLerpValueOffset;

        pointCacheWeightLerp = Mathf.PingPong(Time.time * 2 / pointCacheWeightCycleTime, pointCacheValueRange) + pointCacheValueOffset;
    }

    public float GetMetalLerp()
    {
        return metalLerp;
    }

    public float GetIceLerp()
    {
        return iceLerp;
    }

    public float GetEchoLerp()
    {
        return echoLerp;
    }

    public float GetPointCacheWeightLerp()
    {
        return pointCacheWeightLerp;
    }
}
