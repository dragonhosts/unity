using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCActionManager : SSActionManager, ISSActionCallback
{
    //�Ƿ������˶�
    private bool isMoving = false;
    //���ƶ�������
    public CCMoveToAction moveBoatAction;
    //���ƶ�������(��Ҫ���)
    public CCSequenceAction moveRoleAction;
    //������
    public FirstController controller;

    protected new void Start()
    {
        controller = (FirstController)SSDirector.GetInstance().CurrentSceneController;
        controller.actionManager = this;
    }

    public bool IsMoving()
    {
        return isMoving;
    }

    //�ƶ���
    public void MoveBoat(GameObject boat, Vector3 target, float speed)
    {
        if (isMoving)
            return;
        isMoving = true;
        moveBoatAction = CCMoveToAction.GetSSAction(target, speed);
        this.RunAction(boat, moveBoatAction, this);
    }

    //�ƶ���
    public void MoveRole(GameObject role, Vector3 mid_destination, Vector3 destination, int speed)
    {
        if (isMoving)
            return;
        isMoving = true;
        moveRoleAction = CCSequenceAction.GetSSAction(0, 0, new List<SSAction> { CCMoveToAction.GetSSAction(mid_destination, speed), CCMoveToAction.GetSSAction(destination, speed) });
        this.RunAction(role, moveRoleAction, this);
    }

    //�ص�����
    public void SSActionEvent(SSAction source,
    SSActionEventType events = SSActionEventType.Completed,
    int intParam = 0,
    string strParam = null,
    Object objectParam = null)
    {
        isMoving = false;
    }
}
