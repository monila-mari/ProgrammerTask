using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColectItems : MonoBehaviour
{
    public Slider collectBar; 
    public float collectBarValue = 0f; 
    public float moneyValueIncrease = 0.1f; 
    public float bottleValueDecrease = 0.2f; 

    private float maxBarValue = 1f;
    private float minBarValue = 0f;

    void Start()
    {
        UpdateCollectBar(); // Инициализируем бар
    }

    // Метод для обнаружения столкновения с объектом
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money")) 
        {
            collectBarValue += moneyValueIncrease; 
            collectBarValue = Mathf.Clamp(collectBarValue, minBarValue, maxBarValue); // Ограничиваем значение от 0 до 1
            Destroy(other.gameObject); 
            UpdateCollectBar(); 
        }
        else if (other.gameObject.CompareTag("Bottle")) 
        {
            collectBarValue -= bottleValueDecrease;
            collectBarValue = Mathf.Clamp(collectBarValue, minBarValue, maxBarValue); // Ограничиваем значение от 0 до 1
            Destroy(other.gameObject); 
            UpdateCollectBar(); 
        }
    }

    // Метод обновления бара
    void UpdateCollectBar()
    {
        collectBar.value = collectBarValue; // Устанавливаем значение в UI-баре
    }
}
