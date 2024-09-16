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
            case BallType.Third: // ¹Ù²Ü°÷
                if (thirdPool.Count > 0) // ¹Ù²Ü°÷
                {
                    GameObject instance = thirdPool.Dequeue();// ¹Ù²Ü°÷
                    SetInstance(instance, pos, rot);
                    return instance;
                }
                else
                {
                    GameObject instance = Instantiate(third.gameObject, pos, rot);// ¹Ù²Ü°÷
                    return instance;
                }
            case BallType.Fourth: // ¹Ù²Ü°÷
                if (fourthPool.Count > 0) // ¹Ù²Ü°÷
                {
                    GameObject instance = fourthPool.Dequeue();// ¹Ù²Ü°÷
                    SetInstance(instance, pos, rot);
                    return instance;
                }
                else
                {
                    GameObject instance = Instantiate(fourth.gameObject, pos, rot);// ¹Ù²Ü°÷
                    return instance;
                }
            case BallType.Fifth: // ¹Ù²Ü°÷
                if (fifthPool.Count > 0) // ¹Ù²Ü°÷
                {
                    GameObject instance = fifthPool.Dequeue();// ¹Ù²Ü°÷
                    SetInstance(instance, pos, rot);
                    return instance;
                }
                else
                {
                    GameObject instance = Instantiate(fifth.gameObject, pos, rot);// ¹Ù²Ü°÷
                    return instance;
                }
            case BallType.Sixth: // ¹Ù²Ü°÷
                if (sixthPool.Count > 0) // ¹Ù²Ü°÷
                {
                    GameObject instance = sixthPool.Dequeue();// ¹Ù²Ü°÷
                    SetInstance(instance, pos, rot);
                    return instance;
                }
                else
                {
                    GameObject instance = Instantiate(sixth.gameObject, pos, rot);// ¹Ù²Ü°÷
                    return instance;
                }
            case BallType.Seventh: // ¹Ù²Ü°÷
                if (seventhPool.Count > 0) // ¹Ù²Ü°÷
                {
                    GameObject instance = seventhPool.Dequeue();// ¹Ù²Ü°÷
                    SetInstance(instance, pos, rot);
                    return instance;
                }
                else
                {
                    GameObject instance = Instantiate(seventh.gameObject, pos, rot);// ¹Ù²Ü°÷
                    return instance;
                }
            case BallType.Eighth: // ¹Ù²Ü°÷
                if (eighthPool.Count > 0) // ¹Ù²Ü°÷
                {
                    GameObject instance = eighthPool.Dequeue();// ¹Ù²Ü°÷
                    SetInstance(instance, pos, rot);
                    return instance;
                }
                else
                {
                    GameObject instance = Instantiate(eighth.gameObject, pos, rot);// ¹Ù²Ü°÷
                    return instance;
                }
            case BallType.Ninth: // ¹Ù²Ü°÷
                if (ninthPool.Count > 0) // ¹Ù²Ü°÷
                {
                    GameObject instance = ninthPool.Dequeue();// ¹Ù²Ü°÷
                    SetInstance(instance, pos, rot);
                    return instance;
                }
                else
                {
                    GameObject instance = Instantiate(ninth.gameObject, pos, rot);// ¹Ù²Ü°÷
                    return instance;
                }
            case BallType.Tenth: // ¹Ù²Ü°÷
                if (tenthPool.Count > 0) // ¹Ù²Ü°÷
                {
                    GameObject instance = tenthPool.Dequeue();// ¹Ù²Ü°÷
                    SetInstance(instance, pos, rot);
                    return instance;
                }
                else
                {
                    GameObject instance = Instantiate(tenth.gameObject, pos, rot);// ¹Ù²Ü°÷
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
            case BallType.Sixth: // ¹Ù²Ü°÷
                sixthPool.Enqueue(instance); // ¹Ù²Ü°÷
                break;
            case BallType.Seventh: // ¹Ù²Ü°÷
                seventhPool.Enqueue(instance); // ¹Ù²Ü°÷
                break;
            case BallType.Eighth: // ¹Ù²Ü°÷
                eighthPool.Enqueue(instance); // ¹Ù²Ü°÷
                break;
            case BallType.Ninth: // ¹Ù²Ü°÷
                ninthPool.Enqueue(instance); // ¹Ù²Ü°÷
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
