using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Action = System.Action;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    //�⺻ ��
    [SerializeField]
    private bool isMove;
    private float speed = 20f;

    //�� ��
    Rigidbody rigid;

    Action checkEvent; //����Ǵ� �̺�Ʈ
    Action eventHandler; //�̺�Ʈ �ڵ鷯
    public LayerMask normalWallLayer;

    

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!isMove)
        { 
            MovePlayer();
        } else
        {
            checkEvent?.Invoke();
        }
    }

    public void MovePlayer()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if(x == 0 && y == 0)
        {
            return;
        }

        //�̵�
        var vec = new Vector3(x, y, 0);
        rigid.AddForce(vec * Time.deltaTime * speed * 100, ForceMode.Impulse);
        eventHandler = () => CheckWall(vec);
        checkEvent += eventHandler;
        isMove = true;
    }

    public void CheckWall(Vector3 vec)
    {
        Debug.DrawRay(transform.position, vec);
        if (Physics.Raycast(transform.position, vec,0.25f,normalWallLayer))
        {
            rigid.velocity = Vector3.zero;
            isMove = false;
            checkEvent -= eventHandler;
            transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y),0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other is IItem)
        {
            other.GetComponent<IItem>().Touch();
        }
    }
}
