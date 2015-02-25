using UnityEngine;
using System.Collections;

public class FiringManager : MonoBehaviour 
{
    [SerializeField]
    int BulletMax;

    [SerializeField]
    float chargeTime = 1f;

    float timerMax;
    float timer;

    [SerializeField]
    UISlider[] sliders;

    void Awake()
    {

        BulletMax = sliders.Length;
        timerMax = chargeTime * BulletMax;
        timer = BulletMax;
    }

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;
        if (timer > timerMax)
        {
            timer = timerMax;
        }

        UpdateSlider();
  	}

    /// <summary>
    /// 戦車から弾が発射されたとにに呼びます
    /// </summary>
    public void OnFire()
    {
        timer -= chargeTime;
    }

    /// <summary>
    /// たまが発砲できる状態かを返します
    /// </summary>
    public bool CanFire()
    {
        return (timer >= chargeTime);
    }

    /// <summary>
    /// スライダーのアップデート
    /// </summary>
    void UpdateSlider()
    {
        int max = 0;
        float temp = timer;

        while (temp >= chargeTime)
        {
            max += 1;
            temp -= chargeTime;
        }

        float modulo = temp;

        //フル
        if (max > 0)
        {
            for (int i = 0; i < max; i++)
            {
                sliders[i].sliderValue = 1f;
            }
        }

        //
        if (max != BulletMax)
        {
            sliders[max].sliderValue = (modulo/chargeTime);
            Debug.Log(modulo);
        }

        //空
        if (max + 1 < sliders.Length)
        {
            for (int i = max + 1; i < sliders.Length; i++)
            {
                sliders[i].sliderValue = 0f;
            }
        }
    }
}
