using UnityEngine;

public class HealthManager : MonoBehaviour
{
    int HealthLevel = 100;
    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EnemyBullet")){
            //TakeDamage();
        }
    }
    private void TakeDamage(int damage)
    {
        HealthLevel -= damage;
        int currentHealth = HealthLevel;
        if(HealthLevel <= 0)
        {
            PlayerKilled();
        }else{
            // here we can reduces the health bar to current health bar in the future.
        }
    }
    private void PlayerKilled()
    {

    }



}
