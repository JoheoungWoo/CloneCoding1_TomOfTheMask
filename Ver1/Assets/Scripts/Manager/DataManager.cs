using UnityEngine;

public class DataManager : MonoBehaviour
{

    public int gold;

    // �̱��� ������ ����ϱ� ���� �ν��Ͻ� ����
    private static DataManager instance;
    // �ν��Ͻ��� �����ϱ� ���� ������Ƽ
    public static DataManager Instance
    {
        get
        {
            // �ν��Ͻ��� ���� ��쿡 �����Ϸ� �ϸ� �ν��Ͻ��� �Ҵ����ش�.
            if (!instance)
            {
                instance = FindObjectOfType(typeof(DataManager)) as DataManager;

                if (instance == null)
                {
                    Debug.Log("no Singleton obj");
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        //�ı�
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
        //�ı� ����
        DontDestroyOnLoad(gameObject);
    }

}
