using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPSize : MonoBehaviour
{
    [SerializeField] Image shieldBar;  // —сылка на Image, представл€ющий щит
    [SerializeField] Image healthBar;  // —сылка на Image, представл€ющий здоровье

    public int maxShield = 100;
    public int maxHealth = 100;

    private int curentHealth;
    private int curentShield;

    private void Start()
    {
        curentHealth = maxHealth;
        curentShield = maxShield;
    }

    private void ShieldBarMovement()
    {
        float HPX = healthBar.rectTransform.rect.x;
        float HPW = healthBar.rectTransform.rect.width;
        shieldBar.rectTransform.position = new Vector2(healthBar.rectTransform.position.x + HPW / 2, shieldBar.rectTransform.position.y);
    }

    private void UpdateBars()
    {
        Debug.Log($"FillAmount - {healthBar.fillAmount}, maxHealth - {maxHealth}, curentHealth - {curentHealth}");
        //healthBar.
    }

    public void TakeDamage(int damageAmount)
    {
        curentHealth -= damageAmount;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            TakeDamage(10);
            UpdateBars();
            ShieldBarMovement();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            TakeDamage(-10);
            UpdateBars();
            ShieldBarMovement();
        }
    }
}
