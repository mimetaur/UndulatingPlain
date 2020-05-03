using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    private PlainManager plainManager;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        plainManager = GameObject.Find("PlainManager").GetComponent<PlainManager>();
    }

    void Update()
    {
        // ProceduralMaterial substance = rend.sharedMaterial as ProceduralMaterial;
        // if (substance)
        // {
        //     substance.SetProceduralFloat(UndulatingPlainConstants.metallicSubstancePropertyName, plainManager.GetMetalLerp());
        //     substance.SetProceduralFloat(UndulatingPlainConstants.iceSubstancePropertyName, plainManager.GetIceLerp());
        //     substance.RebuildTextures();
        // }
    }
}
