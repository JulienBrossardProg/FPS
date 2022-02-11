using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreeperSpawner : MonoBehaviour
{
    public float creeperCount;
    [SerializeField] private bool isSpawning = false;
    public float spawnRange;
    [SerializeField] GameObject lastCreeper;
    private Vector2 randomPointOnCircle;
    public static CreeperSpawner instance;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (isSpawning == false && creeperCount<3)
        {
            StartCoroutine("CreeperSpawn");
        } 
    }

    IEnumerator CreeperSpawn()
    {
        isSpawning = true;
        yield return new WaitForSeconds(3);
        creeperCount++;
        isSpawning = false;
        lastCreeper = Pooler.instance.Pop("Creeper");
        lastCreeper.GetComponent<CreeperLife>().currentHealth = lastCreeper.GetComponent<CreeperLife>().maxHealth;
        randomPointOnCircle = Random.insideUnitCircle * spawnRange;
        lastCreeper.transform.position = transform.position+ new Vector3(randomPointOnCircle.x, 1 , randomPointOnCircle.y);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, spawnRange);
    }
}
