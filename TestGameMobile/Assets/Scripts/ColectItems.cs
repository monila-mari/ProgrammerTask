using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColectItems : MonoBehaviour
{
    public Slider collectBar; 
    public TextMeshProUGUI statusText;
    public Image barFill;
    public float collectBarValue = 0f;
    public float moneyValueIncrease = 0.05f;
    public float bottleValueDecrease = 0.1f;

    private float maxBarValue = 1f;
    private float minBarValue = 0f;

    void Start()
    {
        UpdateCollectBar();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            collectBarValue += moneyValueIncrease;
            collectBarValue = Mathf.Clamp(collectBarValue, minBarValue, maxBarValue);
            Destroy(other.gameObject);
            UpdateCollectBar();
        }
        else if (other.gameObject.CompareTag("Bottle"))
        {
            collectBarValue -= bottleValueDecrease;
            collectBarValue = Mathf.Clamp(collectBarValue, minBarValue, maxBarValue);
            Destroy(other.gameObject);
            UpdateCollectBar();
        }
    }

    void UpdateCollectBar()
    {
        collectBar.value = collectBarValue;

        if (collectBarValue < 0.33f)
        {
            statusText.text = "Бедный";
            barFill.color = Color.red;
        }
        else if (collectBarValue < 0.66f)
        {
            statusText.text = "Состоятельный";
            barFill.color = Color.yellow;
        }
        else
        {
            statusText.text = "Богатый";
            barFill.color = Color.green;
        }
    }
}
