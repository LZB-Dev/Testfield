using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSize : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int maxShield;
    [SerializeField] RectTransform Bar;
    [SerializeField] RectTransform Health;
    [SerializeField] RectTransform Shield;

    public void HPBar()
    {
        Bar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 210*3);
        Health.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100*3);
        Shield.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100* 3);
    }

    void Start()
    {

    }

    void Update()
    {
        HPBar();
    }
}
