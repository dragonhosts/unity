using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Move : MonoBehaviour
{
    public bool isMoving = false;
    public float speed = 5;
    public Vector3 destination;
    public Vector3 mid_destination;
    // Update is called once per frame
    void Update()
    {

        if (transform.localPosition == destination)
        {
            isMoving = false;
            return;
        }
        isMoving = true;
        if (transform.localPosition.x != destination.x && transform
        .localPosition.y != destination.y)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, mid_destination, speed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination, speed * Time.deltaTime);
        }
    }
}
public class MoveCtrl
{
    GameObject moveObject;
    public bool GetIsMoving()
    {
        return (moveObject != null && moveObject.GetComponent<Move>().isMoving == true);
    }

    public void SetMove(Vector3 destination, GameObject moveObject)
    {
        Move test;
        this.moveObject = moveObject;
        if (!moveObject.TryGetComponent<Move>(out test))
        {
            moveObject.AddComponent<Move>();
        }

        this.moveObject.GetComponent<Move>().destination = destination;
        if (this.moveObject.transform.localPosition.y > destination.y)
        {
            this.moveObject.GetComponent<Move>().mid_destination = new Vector3(destination.x, this.moveObject.transform.localPosition.y, destination.z);
        }
        else
        {
            this.moveObject.GetComponent<Move>().mid_destination = new Vector3(this.moveObject.transform.localPosition.x, destination.y, destination.z);
        }
    }
}