using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    [SerializeField] Transform cursorPos;

    [Header("BallType")]
    [SerializeField] Ball firstBall;
    [SerializeField] Ball secondBall;
    [SerializeField] Ball thirdBall;
    [SerializeField] Ball fourthBall;
    [SerializeField] Ball fifthBall;
    [SerializeField] Ball sixthBall;
    [SerializeField] Ball seventhBall;
    [SerializeField] Ball eighthBall;
    [SerializeField] Ball ninthBall;
    [SerializeField] Ball tenthBall;


    [SerializeField] int ballCount;
    LinkedList<Ball> balls;

    [Header("Shoot Status")]
    [SerializeField] ShooterModel model;

    bool canShoot;
    WaitForSeconds shootDelay;
    WaitForSeconds chargeDelay;
    WaitForSeconds shootOffDelay;

    Coroutine chargeRoutine;

    StringBuilder sb= new StringBuilder();
    private void Awake()
    {
        model = GetComponent<ShooterModel>();
        model.OnChangePower += UpdatePowerBar;
        model.OnChangeRemainCoolTime += UpdateCoolTimeBar;
        model.OnChangeScore += UpdateScore;

        balls = new LinkedList<Ball>();
        canShoot = true;
        
        model.ShootPower = model.MinShootPower;
        chargeDelay = new WaitForSeconds(0.1f);
        
        shootDelay = new WaitForSeconds(model.CoolTime);
        UIManager.Instance.coolTimeBar.maxValue = model.CoolTime;

        BallCreator.Instance.OnGetScore += GetScore;
        model.Score = 0;
    }

    private void Start()
    {
       for(int i = 0; i<ballCount; i++)
       {
            AddRandomBall();
       }

       UpdateBallUI();
    }

    private void Update()
    {
        Rotate();
        Shoot();      
    }

    void Rotate()
    {
        transform.LookAt(cursorPos);

        transform.Rotate(0, -90, 0);
    }
    void Shoot()
    {
        if (!canShoot) return; 
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.visible = false;
            if (chargeRoutine == null) 
            {
                chargeRoutine = StartCoroutine(ChargeRoutine());
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (chargeRoutine != null)
            {
                StopCoroutine(chargeRoutine);
                chargeRoutine = null;

                Ball ball=balls.First();
                balls.RemoveFirst();
                AddRandomBall();

                ball.speed = model.ShootPower;
                ball.isShoot = true;
                BallType instanceType = ball.ballData.ballType;
                BallPool.Instance.GetPool(instanceType, transform.position, transform.rotation);
                StartCoroutine(CoolTimeRoution());
                StartCoroutine(CheckCoolTimeRoutine());
                model.ShootPower = model.MinShootPower;

                StartCoroutine(ShootOffRoutine(ball));
                UpdateBallUI();
            }
        }
    }

    IEnumerator ShootOffRoutine(Ball ball)
    {
        yield return null;
        ball.isShoot =false;
    }

    IEnumerator ChargeRoutine()
    {
        while (true)
        {
            model.ShootPower += 0.1f;
            if(model.ShootPower > model.MaxShootPower)
            {
                model.ShootPower = model.MaxShootPower;
            }
            yield return chargeDelay;
        }
    }
    IEnumerator CoolTimeRoution()
    {
        canShoot = false;
        yield return shootDelay;
        canShoot = true;
    }
    IEnumerator CheckCoolTimeRoutine()
    {
        model.RemainCoolTime = model.CoolTime;
        while (true) 
        {
            model.RemainCoolTime -= Time.deltaTime;
            if (model.RemainCoolTime <= 0)
                break;
            yield return null;
        }      
    }

    void AddRandomBall()
    {
        switch (Util.Random(0, (int)model.MaxBallType))
        {
            case (int)BallType.First:
                balls.AddLast(firstBall);
                break;
            case (int)BallType.Second:
                balls.AddLast(secondBall);
                break;
            case (int)BallType.Third:
                balls.AddLast(thirdBall);
                break;
            case (int)BallType.Fourth:
                balls.AddLast(fourthBall);
                break;
            case (int)BallType.Fifth:
                balls.AddLast(fifthBall);
                break;
            case (int)BallType.Sixth:
                balls.AddLast(sixthBall);
                break;
            case (int)BallType.Seventh:
                balls.AddLast(seventhBall);
                break;
            case (int)BallType.Eighth:
                balls.AddLast(eighthBall);
                break;
            case (int)BallType.Ninth:
                balls.AddLast(ninthBall);
                break;
            case (int)BallType.Tenth:
                balls.AddLast(tenthBall);
                break;
        }
    }

    void UpdateBallUI()
    {
        UIManager.Instance.curBallUI.sprite = balls.First().ballData.sprite;

        UIManager.Instance.nextBallUI.sprite = balls.Last().ballData.sprite;
    }

    void UpdatePowerBar()
    {
        UIManager.Instance.powerBar.value = model.ShootPower;
    }
    void UpdateCoolTimeBar()
    {
        UIManager.Instance.coolTimeBar.value = model.RemainCoolTime;
    }
    void GetScore(int score)
    {
        model.Score += score;
    }
    void UpdateScore()
    {
        sb.Clear();
        sb.Append(model.Score);
        UIManager.Instance.score.SetText(sb);
    }
}
