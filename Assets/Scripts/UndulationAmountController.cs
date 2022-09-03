using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndulationAmountController : MonoBehaviour
{
    public MegaPointCache pointCache;
    private PlainManager plainManager;

    // Start is called before the first frame update
    void Start()
    {
        plainManager = GameObject.Find("PlainManager").GetComponent<PlainManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float pointCacheWeightLerp = plainManager.GetPointCacheWeightLerp();
        pointCache.weight = pointCacheWeightLerp;
    }
}
