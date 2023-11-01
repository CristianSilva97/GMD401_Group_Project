using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code used for making a score that saves between scene changes using FloatSO's.
[CreateAssetMenu]
public class FloatSO : ScriptableObject
{
    [SerializeField]
    private float privateValue;

    public float publicValue
    {
        get { return privateValue; }
        set { privateValue = value; }
    }

}
