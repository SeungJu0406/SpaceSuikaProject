using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    public static BallPool Instance;

    [Header("balls")]
    [SerializeField] GameObject first;
    [SerializeField] GameObject second;
    [SerializeField] GameObject third;
    [SerializeField] GameObject fourth;
    [SerializeField] GameObject fifth;
    [SerializeField] GameObject sixth;
    [SerializeField] GameObject seventh;
    [SerializeField] GameObject eighth;
    [SerializeField] GameObject ninth;
    [SerializeField] GameObject tenth;
    [SerializeField] Queue<GameObject> firstPool;
    [SerializeField] Queue<GameObject> secondPool;
    [SerializeField] Queue<GameObject> thirdPool;
    [SerializeField] Queue<GameObject> fourthPool;
    [SerializeField] Queue<GameObject> fifthPool;
    [SerializeField] Queue<GameObject> sixthPool;
    [SerializeField] Queue<GameObject> seventhPool;
    [SerializeField] Queue<GameObject> eighthPool;
    [SerializeField] Queue<GameObject> ninthPool;
    [SerializeField] Queue<GameObject> tenthPool;

    [SerializeField] int size;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        firstPool = new Queue<GameObject>(size);
        secondPool = new Queue<GameObject>(size);
        thirdPool = new Queue<GameObject>(size);
        fourthPool = new Queue<GameObject>(size);
        fifthPool = new Queue<GameObject>(size);
        sixthPool = new Queue<GameObject>(size);
        seventhPool = new Queue<GameObject>(size);
        eighthPool = new Queue<GameObject>(size);
        ninthPool = new Queue<GameObject>(size);
        tenthPool = new Queue<GameObject>(size);
    }

    public GameObject GetPool(BallType ballType, Vector2 pos, Quaternion rot)
    {
        switch (ballType)
        {
            case BallType.First:
                if (firstPool.Count > 0)
                {
                    GameObject instance = firstPool.Dequeue();
                    SetInstance(instance, pos, rot);
                    return instance;
                }
                else
                {
                    GameObject instance = Instantiate(first.gameObject, pos, rot);
                    return instance;
                }
            case BallType.Second:
                if (secondPool.Count > 0)
                {
                    GameObject instance = secondPool.Dequeue();
                    SetInstance(instance, pos, rot);
                    return instance;
                }
                else
                {
                    GameObject instance = Instantiate(second.gameObject, pos, rot);
                    return instance;
                }
            case BallType.Third: // �ٲܰ�
                if (thirdPool.Count > 0) // �ٲܰ�
                {
                    GameObject instance = thirdPool.Dequeue();// �ٲܰ�
                    SetInstance(instance, pos, rot);
                    return instance;
                }
                else
                {
                    GameObject instance = Instantiate(third.gameObject, pos, rot);// �ٲܰ�
                    return instance;
                }
            case BallType.Fourth: // �ٲܰ�
                if (fourthPool.Count > 0) // �ٲܰ�
                {
                    GameObject instance = fourthPool.Dequeue();// �ٲܰ�
                    SetInstance(instance, pos, rot);
                    return instance;
                }
                else
                {
                    GameObject instance = Instantiate(fourth.gameObject, pos, rot);// �ٲܰ�
                    return instance;
                }
            case BallType.Fifth: // �ٲܰ�
                if (fifthPool.Count > 0) // �ٲܰ�
                {
                    GameObject instance = fifthPool.Dequeue();// �ٲܰ�
                    SetInstance(instance, pos, rot);
                    return instance;
                }
                else
                {
                    GameObject instance = Instantiate(fifth.gameObject, pos, rot);// �ٲܰ�
                    return instance;
                }
            case BallType.Sixth: // �ٲܰ�
                if (sixthPool.Count > 0) // �ٲܰ�
                {
                    GameObject instance = sixthPool.Dequeue();// �ٲܰ�
                    SetInstance(instance, pos, rot);
                    return instance;
                }
                else
                {
                    GameObject instance = Instantiate(sixth.gameObject, pos, rot);// �ٲܰ�
                    return instance;
                }
            case BallType.Seventh: // �ٲܰ�
                if (seventhPool.Count > 0) // �ٲܰ�
                {
                    GameObject instance = seventhPool.Dequeue();// �ٲܰ�
                    SetInstance(instance, pos, rot);
                    return instance;
                }
                else
                {
                    GameObject instance = Instantiate(seventh.gameObject, pos, rot);// �ٲܰ�
                    return instance;
                }
            case BallType.Eighth: // �ٲܰ�
                if (eighthPool.Count > 0) // �ٲܰ�
                {
                    GameObject instance = eighthPool.Dequeue();// �ٲܰ�
                    SetInstance(instance, pos, rot);
                    return instance;
                }
                else
                {
                    GameObject instance = Instantiate(eighth.gameObject, pos, rot);// �ٲܰ�
                    return instance;
                }
            case BallType.Ninth: // �ٲܰ�
                if (ninthPool.Count > 0) // �ٲܰ�
                {
                    GameObject instance = ninthPool.Dequeue();// �ٲܰ�
                    SetInstance(instance, pos, rot);
                    return instance;
                }
                else
                {
                    GameObject instance = Instantiate(ninth.gameObject, pos, rot);// �ٲܰ�
                    return instance;
                }
            case BallType.Tenth: // �ٲܰ�
                if (tenthPool.Count > 0) // �ٲܰ�
                {
                    GameObject instance = tenthPool.Dequeue();// �ٲܰ�
                    SetInstance(instance, pos, rot);
                    return instance;
                }
                else
                {
                    GameObject instance = Instantiate(tenth.gameObject, pos, rot);// �ٲܰ�
                    return instance;
                }
            default:
                return null;
        }
    }

    public void ReturnPool(GameObject instance, BallType ballType)
    {
        instance.transform.parent = transform;
        instance.gameObject.SetActive(false);
        switch (ballType)
        {
            case BallType.First:
                firstPool.Enqueue(instance);
                break;
            case BallType.Second:
                secondPool.Enqueue(instance);
                break;
            case BallType.Third:
                thirdPool.Enqueue(instance);
                break;
            case BallType.Fourth:
                fourthPool.Enqueue(instance);
                break;
            case BallType.Fifth:
                fifthPool.Enqueue(instance);
                break;
            case BallType.Sixth: // �ٲܰ�
                sixthPool.Enqueue(instance); // �ٲܰ�
                break;
            case BallType.Seventh: // �ٲܰ�
                seventhPool.Enqueue(instance); // �ٲܰ�
                break;
            case BallType.Eighth: // �ٲܰ�
                eighthPool.Enqueue(instance); // �ٲܰ�
                break;
            case BallType.Ninth: // �ٲܰ�
                ninthPool.Enqueue(instance); // �ٲܰ�
                break;
            case BallType.Tenth:
                tenthPool.Enqueue(instance);
                break;
        }       
    }
    void SetInstance(GameObject instance, Vector2 pos, Quaternion rot)
    {
        instance.transform.position = pos;
        instance.transform.rotation = rot;
        instance.transform.parent = null;
        instance.gameObject.SetActive(true);
    }
}
