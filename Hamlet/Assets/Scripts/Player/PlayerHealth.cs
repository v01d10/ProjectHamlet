using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private float Health;
    private float LerpTimer;
    public float MaxHealth = 100f;
    public float ChipSpeed;
    public Image FrontHealthBar;
    public Image BackHealthBar;
    public TMP_Text HealthText;
    
    void Start()
    {
        Health = MaxHealth;
    }

    void Update()
    {
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        UpdateHealthUI();
        HealthText.SetText(Health.ToString()+" HP");
    }

    public void UpdateHealthUI()
    {
        float fillF = FrontHealthBar.fillAmount;
        float fillB = BackHealthBar.fillAmount;
        float hFraction = Health / MaxHealth;
        if(fillB > hFraction)
        {
            FrontHealthBar.fillAmount = hFraction;
            //BackHealthBar.color = Color.red;
            LerpTimer += Time.time;
            float percentComplete = LerpTimer / ChipSpeed;
            BackHealthBar.fillAmount = Mathf.Lerp(fillB,hFraction,percentComplete);

        }
    }

    public void TakeDamage(int Damage)
    {
        Health -= Damage;
        LerpTimer = 0f;

        if(Health <= 0)
        {
            gameObject.SetActive(false);
            Death();
        }
    }

    public void Death()
    {
        FrontHealthBar.fillAmount = 0;
        HealthText.SetText("Dumbass");
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
