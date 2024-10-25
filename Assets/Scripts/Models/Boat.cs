using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat
{
    public GameObject boat;//������
    public Role[] roles;//���ϵĽ�ɫ
    public bool isRight;
    public int priestCount, devilCount;

    public Boat(Vector3 position)
    {
        boat = GameObject.Instantiate(Resources.Load("Prefabs/Boat", typeof(GameObject))) as GameObject;
        boat.name = "boat";
        boat.transform.position = position;
        boat.transform.localScale = new Vector3(2.8f, 0.4f, 2);

        roles = new Role[2];
        isRight = false;
        priestCount = devilCount = 0;

        boat.AddComponent<BoxCollider>();
        boat.AddComponent<Click>();

    }
}