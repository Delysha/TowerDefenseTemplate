using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]                         //deze header zorgt er voor dat info overbrengt over een externe functieaanroep
        [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    private Transform target;
    private int pathIndex = 0;
    private void Start()
    {
        target = LevelManager.main.path[pathIndex];  //deze target zorgt ervoor dat de code die in 
    }                                                // De levelmaneger code staat ook hier wordt gebruikt deze code gebruikt het voor de Waypoint die  worden aangeroepen in de levelmanager 

    private void Update()          //Deze regel berekent de afstand tussen het huidige doelpunt (target.position) en de positie van het object (transform.position) met behulp van Vector2.Distance
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)   
        {
            pathIndex++;

            if (pathIndex == LevelManager.main.path.Length)
            {
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.main.path[pathIndex];

            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;
    }
}
