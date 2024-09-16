using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShooterModel : MonoBehaviour
{
    [SerializeField] float maxShootPower;
    [HideInInspector] public float MaxShootPower { get { return maxShootPower; } }

    [SerializeField] float minShootPower;
    [HideInInspector] public float MinShootPower { get {return minShootPower; } }

    [SerializeField] float shootPower;
    [HideInInspector] public float ShootPower { get { return shootPower; } set { shootPower = value; OnChangePower?.Invoke(); } }
    public event UnityAction OnChangePower;

    [SerializeField] float coolTime;
    [HideInInspector] public float CoolTime { get { return coolTime; } }

    [SerializeField] float remainCoolTime;
    [HideInInspector] public float RemainCoolTime { get { return remainCoolTime; } set { remainCoolTime = value; OnChangeRemainCoolTime?.Invoke(); } }
    public event UnityAction OnChangeRemainCoolTime;

    [SerializeField] BallType maxBallType;
    [HideInInspector] public BallType MaxBallType { get { return maxBallType; } }

    [SerializeField] int score;
    [SerializeField] public int Score { get { return score; } set { score = value; OnChangeScore?.Invoke(); } }
    public event UnityAction OnChangeScore;
}
