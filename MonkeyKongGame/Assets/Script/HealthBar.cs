using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private RectTransform bar;
    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<RectTransform>();
        setSize(Health.totalHealth);
    }
    public void Damage (float damage)
    {
        if ((Health.totalHealth -= damage) >= 0f) 
        {
            Health.totalHealth -= damage;
        }
        else
        {
            Health.totalHealth = 0f;
        }
    }
    public void setSize (float size)
    {
        bar.localScale = new Vector3(size, 1f);
    }
}
