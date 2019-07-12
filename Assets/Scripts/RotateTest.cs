using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateTest : MonoBehaviour
{
    public GameObject Platform;
    public int RotValue;

	// Use this for initialization
	void Start ()
    {
        Rotation();
	}
	

    public void Rotation()
    {
        Platform.transform.DORotate(new Vector3 (0,0,RotValue), 7f, RotateMode.FastBeyond360).OnComplete(Rotation);
    }
}
