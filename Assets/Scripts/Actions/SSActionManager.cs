using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSActionManager : MonoBehaviour
{
    //�����������ֵ���ʽ����
    private Dictionary<int, SSAction> actions = new Dictionary<int, SSAction>();
    //�ȴ�������Ķ�������(����������ʼ)
    private List<SSAction> waitingAdd = new List<SSAction>();
    //�ȴ���ɾ���Ķ�������(���������)
    private List<int> waitingDelete = new List<int>();

    protected void Update()
    {
        //��waitingAdd�еĶ�������
        foreach (SSAction ac in waitingAdd)
            actions[ac.GetInstanceID()] = ac;
        waitingAdd.Clear();

        //���б�������¼�
        foreach (KeyValuePair<int, SSAction> kv in actions)
        {
            SSAction ac = kv.Value;
            if (ac.destroy)
            {
                waitingDelete.Add(ac.GetInstanceID());
            }
            else if (ac.enable)
            {
                ac.Update();
            }
        }

        //����waitingDelete�еĶ���
        foreach (int key in waitingDelete)
        {
            SSAction ac = actions[key];
            actions.Remove(key);
            Destroy(ac);
        }
        waitingDelete.Clear();
    }

    //׼������һ����������������ʼ���������뵽waitingAdd
    public void RunAction(GameObject gameObject, SSAction action, ISSActionCallback manager)
    {
        action.gameObject = gameObject;
        action.transform = gameObject.transform;
        action.callback = manager;
        waitingAdd.Add(action);
        action.Start();
    }

    // Start is called before the first frame update
    protected void Start()
    {

    }

}