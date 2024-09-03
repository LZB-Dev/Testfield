using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HPSize : MonoBehaviour
{
    [SerializeField] Slider AreaHealthSlider, AreaShieldSlider;
    [SerializeField] TextMeshProUGUI TextHealth, TextShield;
    private RectTransform AreaHealth, AreaShield;
    private RectTransform Bar;

    public int maxHealth, maxShield;
    private int currentHealth, currentShield;

    private void Awake()
    {
        AreaHealth = AreaHealthSlider.GetComponentInParent<RectTransform>();
        AreaShield = AreaShieldSlider.GetComponentInParent<RectTransform>();
        Bar = GetComponent<RectTransform>();
    }

    private void Start()
    {
        Presetting();
    }

    private void Presetting()
    {
        currentHealth = maxHealth;
        currentShield = maxShield;
        AreaHealthSlider.maxValue = maxHealth;
        AreaShieldSlider.maxValue = maxShield;
        UpdateBars();
        UpdateText();
        BarResize();
    }

    private void UpdateAreaPosition()
    {
        float HealthWidth = Bar.rect.width / 100f * (100f / (AreaHealthSlider.maxValue + AreaShieldSlider.maxValue) * AreaHealthSlider.maxValue);
        AreaShield.localPosition = new Vector2(HealthWidth / AreaHealthSlider.maxValue * AreaHealthSlider.value, 0);
        //Debug.Log($"AS pos = {AreaShield.localPosition} - x = {AreaShield.localPosition.x}, y = {AreaShield.localPosition.y}, z = {AreaShield.localPosition.z}");
        
    }

    private void BarResize()
    {
        float HealthWidth = Bar.rect.width / 100f * (100f / (AreaHealthSlider.maxValue + AreaShieldSlider.maxValue) * AreaHealthSlider.maxValue);
        AreaHealth.sizeDelta = new Vector2(HealthWidth, AreaHealth.sizeDelta.y);
        float ShieldWidth = Bar.rect.width - HealthWidth;
        AreaShield.sizeDelta = new Vector2(ShieldWidth, AreaShield.sizeDelta.y);
        //Debug.Log($"{Bar.rect.width} / 100 * ( 100 / ({AreaHealthSlider.maxValue} + {AreaShieldSlider.maxValue}) * {AreaHealthSlider.maxValue}) = {HealthWidth}" +
        //    $"\nBarWidth / 100 * ((AHS-max + ASS-max) / 100 * AHS-max) = HealthWidth");
        AreaShield.localPosition = new Vector2(HealthWidth / AreaHealthSlider.maxValue * AreaHealthSlider.value, 0);
    }

    private void UpdateBars()
    {
        AreaHealthSlider.value = currentHealth;
        AreaShieldSlider.value = currentShield;
    }

    private void UpdateText()
    {
        TextHealth.text = $"{currentHealth}";
        TextShield.text = $"{currentShield}";
    }

    public enum TargetType
    {
        Health, Shield
    }

    public enum Action
    {
        Damage, Restore
    }

    public void Interaction(TargetType target, Action action, int amount)
    {
        switch (target)
        {
            case TargetType.Health:
                switch (action)
                {
                    case Action.Damage:
                        currentHealth -= amount;
                        if (currentHealth < 0) { currentHealth = 0; }
                        break;
                    case Action.Restore:
                        currentHealth += amount;
                        if (currentHealth > maxHealth) { currentHealth = maxHealth; }
                        break;
                }
                break;
            case TargetType.Shield:
                switch (action)
                {
                    case Action.Damage:
                        currentShield -= amount;
                        if (currentShield < 0) { currentShield = 0; }
                        break;
                    case Action.Restore:
                        currentShield += amount;
                        if (currentShield > maxShield) { currentShield = maxShield; }
                        break;
                }
                break;
        }
        UpdateText();
        UpdateBars();
        UpdateAreaPosition();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1)) { Interaction(TargetType.Health, Action.Damage, 20); }
        else if (Input.GetKeyDown(KeyCode.Keypad2)) { Interaction(TargetType.Health, Action.Restore, 20); }
        else if (Input.GetKeyDown(KeyCode.Keypad4)) { Interaction(TargetType.Shield, Action.Damage, 20); }
        else if (Input.GetKeyDown(KeyCode.Keypad5)) { Interaction(TargetType.Shield, Action.Restore, 20); }
    }

    #region old code
    //[SerializeField] Image healthBar;  // —сылка на Image, представл€ющий здоровье
    //[SerializeField] Image shieldBar;  // —сылка на Image, представл€ющий щит
    //[SerializeField] TextMeshProUGUI healthNumber;
    //[SerializeField] TextMeshProUGUI shieldNumber;


    //public int maxShield = 100;
    //public int maxHealth = 100;

    //private int curentHealth;
    //private int curentShield;

    //private void Start()
    //{
    //    curentHealth = maxHealth;
    //    curentShield = maxShield;
    //    healthNumber.text = $"{curentHealth}";
    //    shieldNumber.text = $"{curentShield}";
    //}

    //private void ShieldBarMovement()
    //{
    //    float HPX = healthBar.rectTransform.rect.x;
    //    float HPW = healthBar.rectTransform.rect.width;
    //    shieldBar.rectTransform.position = new Vector2(healthBar.rectTransform.position.x + HPW / 2, shieldBar.rectTransform.position.y);
    //}

    //private void UpdateBars()
    //{
    //    healthNumber.text = $"{curentHealth}";
    //    shieldNumber.text = $"{curentShield}";
    //    Debug.Log($"FillAmount - {healthBar.fillAmount}, maxHealth - {maxHealth}, curentHealth - {curentHealth}");
    //    healthBar.fillAmount = curentHealth;
    //}

    //public void TakeDamage(int damageAmount)
    //{
    //    curentHealth -= damageAmount;
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Keypad1))
    //    {
    //        TakeDamage(10);
    //        UpdateBars();
    //        ShieldBarMovement();
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Keypad2))
    //    {
    //        TakeDamage(-10);
    //        UpdateBars();
    //        ShieldBarMovement();
    //    }
    //}
    #endregion
}
