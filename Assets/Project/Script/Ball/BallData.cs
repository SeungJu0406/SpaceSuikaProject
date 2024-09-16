using UnityEngine;

[CreateAssetMenu(menuName = "Ball")]
public class BallData : ScriptableObject
{
    [SerializeField] public Ball prefab;

    [SerializeField] public GameObject ball;

    [SerializeField] public GameObject nextBall;

    [SerializeField] public BallType ballType;

    [SerializeField] public Sprite sprite;
    [SerializeField] public int score { get { return ((int)ballType + 1) * ((int)ballType + 1); } }
}
