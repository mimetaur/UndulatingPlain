﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UndulatingAudioController : MonoBehaviour
{
    public AudioMixer mixer;
    public RangeFloat cutoffRange = new RangeFloat(500f, 1200f);
    public RangeFloat resonanceRange = new RangeFloat(1f, 2.5f);
    public RangeFloat echoRange = new RangeFloat(0.2f, 0.8f);
    public RangeFloat ampRange = new RangeFloat(0f, -10f);

    private Hv_undulatingPlain_AudioLib heavyScript;
    private PlainManager plainManager;

    void Start()
    {
        plainManager = GameObject.Find("PlainManager").GetComponent<PlainManager>();
        heavyScript = GetComponent<Hv_undulatingPlain_AudioLib>();
    }

    public void SetBurst(float newBurst)
    {
        heavyScript.SetFloatParameter(Hv_undulatingPlain_AudioLib.Parameter.Burst, newBurst);
    }

    public void SetBuild(float newBuild)
    {
        heavyScript.SetFloatParameter(Hv_undulatingPlain_AudioLib.Parameter.Build, newBuild);
    }

    private void Update()
    {
        float iceLerp = plainManager.GetIceLerp();

        float cutoffParam = GameUtils.Map(iceLerp, 0f, 1f, cutoffRange.Low(), cutoffRange.High());
        mixer.SetFloat("LowpassCutoff", cutoffParam);

        float resonanceParam = GameUtils.Map(iceLerp, 0f, 1f, resonanceRange.Low(), resonanceRange.High());
        mixer.SetFloat("LowpassResonance", resonanceParam);

        float echoLerp = plainManager.GetEchoLerp();
        float echoParam = GameUtils.Map(echoLerp, 0f, 1f, echoRange.Low(), echoRange.High());
        mixer.SetFloat("EchoDecay", echoParam);

        float metalLerp = plainManager.GetMetalLerp();
        float ampParam = GameUtils.Map(metalLerp, 0.5f, 1f, ampRange.Low(), ampRange.High());
        mixer.SetFloat("MasterVolume", ampParam);

        // float cutoffParam = GameUtils.Map(iceLerp, 0f, 1f, 500f, 1200.0f);
        // float metalParam = GameUtils.Map(metalLerp, 0.5f, 1f, 0f, 127f);
        // float cutoffParam = GameUtils.Map(metalLerp, 0.5f, 1f, 0f, 1200.0f);
    }

    public void SetMetallicValue(float newMetallicValue)
    {

    }

    public void SetIceValue(float newIceValue)
    {

    }
}