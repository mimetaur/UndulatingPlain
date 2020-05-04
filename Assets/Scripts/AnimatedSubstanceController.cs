using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Substance.Game;

public class AnimatedSubstanceController : MonoBehaviour
{
    // adapted from the example Substance Unity API script found here:
    // https://docs.substance3d.com/integrations/c-example-script-170459665.html

    public PlainManager plainManager;
    public Substance.Game.SubstanceGraph plainSubstance;

    // Start is called before the first frame update
    void Start()
    {
        UpdateSubstance();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSubstance();
    }

    public void UpdateSubstance()
    {
        string metallicName = UndulatingPlainConstants.metallicSubstancePropertyName;
        plainSubstance.SetInputFloat(metallicName, plainManager.GetMetalLerp());

        string iceName = UndulatingPlainConstants.iceSubstancePropertyName;
        plainSubstance.SetInputFloat(iceName, plainManager.GetIceLerp());

        // queue for render
        plainSubstance.QueueForRender();
        //render all substances async
        Substance.Game.Substance.RenderSubstancesAsync();
    }
}
