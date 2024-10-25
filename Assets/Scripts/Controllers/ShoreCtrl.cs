using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoreCtrl
{
    Shore shoreModel;
    public void CreateShore(Vector3 position)
    {
        if (shoreModel == null)
        {
            shoreModel = new Shore(position);
        }
    }
    public Shore GetShore()
    {
        return shoreModel;
    }

    //����ɫ��ӵ����ϣ����ؽ�ɫ�ڰ��ϵ��������
    public Vector3 AddRole(Role roleModel)
    {
        roleModel.role.transform.parent = shoreModel.shore.transform;
        roleModel.inBoat = false;
        if (roleModel.isPriest) shoreModel.priestCount++;
        else shoreModel.devilCount++;
        return Position.role_shore[roleModel.id];
    }

    //����ɫ�Ӱ����Ƴ�
    public void RemoveRole(Role roleModel)
    {
        if (roleModel.isPriest) shoreModel.priestCount--;
        else shoreModel.devilCount--;
    }
}