using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public TextMeshProUGUI healthText;
    public void UpdateHealthBar(float health, float maxHealth)
    {
        healthBar.fillAmount = health / maxHealth;
        healthText.text = $"{health} / {maxHealth}";
    }
}
