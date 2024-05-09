using UnityEngine;

public class DataManager : MonoBehaviour
{

    public int gold;

    // 싱글톤 패턴을 사용하기 위한 인스턴스 변수
    private static DataManager instance;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static DataManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
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

        //파괴
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
        //파괴 방지
        DontDestroyOnLoad(gameObject);
    }

}
