using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public float max_HP;
    [SerializeField] float current_HP;

        // Start is called before the first frame update
    void Start()
    {
        current_HP = max_HP;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public void Get_Damage (float damage)
    {
        current_HP = current_HP - damage;
        if (current_HP <= 0)
        {
            Die();
        }
    }

    public void Heal (float heal) 
    {
        if (current_HP + heal >= max_HP)
        {
            current_HP = max_HP;
        }
        else
        {
            current_HP = current_HP + heal;
        }
       
    }
    void Die ()
    {
    
    }
}
