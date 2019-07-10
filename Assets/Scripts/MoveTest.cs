using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour {

    public List<Vector3> target = new List<Vector3>();
    public float Speed;
    private int targetIndex;
    float targetValueX;
	// Use this for initialization
	void Start () {
        targetIndex = 0;
	}

    private void Update()
    {
        if(target[targetIndex].x > transform.position.x)
        {
            targetValueX = Speed; 
        }
        else if(target[targetIndex].x < transform.position.x)
        {
            targetValueX = -Speed;
        }
        else
        {
            targetValueX = 0;
        }
        Move(new Vector3(targetValueX * Time.deltaTime, 0));
        if(transform.position == new Vector3(target[targetIndex].x, transform.position.y, transform.position.z))
        {
            targetIndex++;
            if(targetIndex >= target.Count)
            {
                targetIndex = 0;
            }
        }
    }

    private void Move(Vector3 _currentTarget)
    {
        transform.Translate(_currentTarget);
        //Vector3.MoveTowards(transform.position, new Vector3(_currentTarget.x, transform.position.y, transform.position.z), Speed * Time.deltaTime);
    }
}
