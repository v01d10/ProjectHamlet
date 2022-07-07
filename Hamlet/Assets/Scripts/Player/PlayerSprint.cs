using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSprint : MonoBehaviour
{
    public float TotalStamina;
    float Stamina
        {
            get { return _stamina; }
            set { _stamina = Mathf.Clamp(value, 0, 100); }
        }
        [SerializeField, Range(0, 100)] private float _stamina;

    private float LerpTimer;
    public float DrainRate;
    public float RechargeRate;
    public float sChipSpeed;

    public Image FrontStaminaBar;
    public Image BackStaminaBar;
    public TMP_Text StaminaText;

    public static bool isRunning;


    void Awake()
    {
        Stamina = TotalStamina;
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) && Stamina > 1)
        {
            isRunning = true;
            Stamina -= DrainRate;
        }
        else
        {
            isRunning = false;
        }

        if(Stamina<100 && Input.GetKey(KeyCode.LeftShift))
        {
            Stamina += 0.25f;
        }

        if(isRunning)
        {
           LerpTimer = 0f;
        }
        else
        {
             Stamina += Time.deltaTime/RechargeRate;
        }

        UpdateStaminaUI();
        StaminaText.SetText(((int)Stamina).ToString()+" SP");
    }
    
    public void UpdateStaminaUI()
    {
        float sFillF = FrontStaminaBar.fillAmount;
        float sFillB = BackStaminaBar.fillAmount;
        float shFraction = Stamina / TotalStamina;

        if(sFillB > shFraction)
        {
            FrontStaminaBar.fillAmount = shFraction;
            LerpTimer += Time.time;
            float percentComplete = LerpTimer / sChipSpeed;
            BackStaminaBar.fillAmount = Mathf.Lerp(sFillB,shFraction,percentComplete);

        }
    }
}
