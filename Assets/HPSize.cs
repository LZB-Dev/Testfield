using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HPSize : MonoBehaviour
{
    [SerializeField] GameObject AreaHealth, AreaShield;
    [SerializeField] Image FillHealth, FillShield;
    [SerializeField] TextMeshProUGUI TextHealth, TextShield;

    public int maxHealth = 250, maxShield = 250;
    private int currentHealth, currentShield;

    private void Start()
    {
        currentHealth = maxHealth;
        currentShield = maxShield;
        TextHealth.text = $"{currentHealth}";
        TextShield.text = $"{currentShield}";
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
