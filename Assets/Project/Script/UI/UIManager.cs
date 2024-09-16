using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Image curBallUI;
    public Image nextBallUI;

    public Slider powerBar;
    public Slider coolTimeBar;

    public TextMeshProUGUI score;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
}
