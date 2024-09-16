using UnityEngine;
using UnityEngine.Events;

public class BallCreator : MonoBehaviour
{
    public static BallCreator Instance;

    public event UnityAction<int> OnGetScore;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }


    public int count;

    public void CreateBall(Ball ball,Transform tf, GameObject next)
    {
        count++;
        if(count == 2)
        {
            BallPool.Instance.GetPool(ball.ballData.ballType + 1, tf.position, tf.rotation);
            OnGetScore?.Invoke(ball.ballData.score);
            count = 0;
        }
    }
}
