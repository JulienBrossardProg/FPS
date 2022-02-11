using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private MeshRenderer buttonMaterial;
    [SerializeField] private Material greenMaterial;
    [SerializeField] private Material redMaterial;
    [SerializeField] private GameObject explosionParticle;
    [SerializeField] private ExplosionBump explosionBump;
    [SerializeField] private ExplosionButton explosionButton;
    [SerializeField] private GameObject proximity;
    [SerializeField] private SphereCollider explosionRadius;



    void Start()
    {
        
    }
    
    void Update()
    {
        if (Detection.isDetect)
        {
            Detection.isDetect = false;
            Destroy(proximity);
            MineExplosion();
        }

        if (explosionBump.isExplose)
        {
            explosionRadius.radius++;
        }
    }

    IEnumerator ExplosionDelay()
    {
        buttonMaterial.material = redMaterial;
        explosionButton.isStopExplosion = false;
        yield return new WaitForSeconds(1);
        buttonMaterial.material = greenMaterial;
        explosionButton.isStopExplosion = true;
        yield return new WaitForSeconds(1);
        buttonMaterial.material = redMaterial;
        explosionButton.isStopExplosion = false;
        yield return new WaitForSeconds(1);
        buttonMaterial.material = greenMaterial;
        explosionButton.isStopExplosion = true;
        yield return new WaitForSeconds(1);
        buttonMaterial.material = redMaterial;
        explosionButton.isStopExplosion = false;
        yield return new WaitForSeconds(1);
        StartCoroutine(Destruction());
    }

    void MineExplosion()
    {
        StartCoroutine("ExplosionDelay");
    }

    public IEnumerator Destruction()
    {
        explosionParticle.SetActive(true);
        explosionBump.isExplose = true;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
