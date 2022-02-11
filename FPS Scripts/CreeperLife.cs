using UnityEngine;
using UnityEngine.UI;

public class CreeperLife : MonoBehaviour
{
    [SerializeField] private Image fillHealth;
    public float maxHealth;
    public float currentHealth;
    [SerializeField] private CreeperReset creeperReset;
    [SerializeField] private float healthBarSpeed;
    
    void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        fillHealth.fillAmount = Mathf.Lerp(fillHealth.fillAmount, currentHealth / maxHealth, Time.deltaTime*healthBarSpeed);
    }

    public void SetHealth(int damage)
    {
        if (currentHealth-damage<=0)
        {
            Dead();
            creeperReset.ResetCreeper();
        }
        else
        {
            currentHealth -= damage;  
        }
    }

    void Dead()
    {
        Pooler.instance.DePop("Creeper",gameObject);
        CreeperSpawner.instance.creeperCount -= 1;
    }
}
