using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCSequenceAction : SSAction, ISSActionCallback
{
    //��������
    public List<SSAction> sequence;
    //�ظ�����
    public int repeat = -1;
    //������ʼָ��
    public int start = 0;

    //��������(����ģʽ)
    public static CCSequenceAction GetSSAction(int repeat, int start, List<SSAction> sequence)
    {
        CCSequenceAction action = ScriptableObject.CreateInstance<CCSequenceAction>();
        action.repeat = repeat;
        action.start = start;
        action.sequence = sequence;
        return action;
    }

    //�������еĶ������г�ʼ��
    public override void Start()
    {
        foreach (SSAction action in sequence)
        {
            action.gameObject = this.gameObject;
            action.transform = this.transform;
            action.callback = this;
            action.Start();
        }
    }

    //���������еĶ���
    public override void Update()
    {
        if (sequence.Count == 0)
            return;
        if (start < sequence.Count)
        {
            sequence[start].Update();
        }
    }

    //�ص��������ж������ʱ����
    public void SSActionEvent(SSAction source,
        SSActionEventType events = SSActionEventType.Completed,
        int Param = 0,
        string strParam = null,
        Object objectParam = null)
    {
        source.destroy = false;
        this.start++;
        if (this.start >= sequence.Count)
        {
            this.start = 0;
            if (repeat > 0)
                repeat--;
            if (repeat == 0)
            {
                this.destroy = true;
                this.callback.SSActionEvent(this);
            }
        }
    }

   
}
