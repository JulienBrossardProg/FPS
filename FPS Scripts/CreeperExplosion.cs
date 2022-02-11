using System.Collections;
using UnityEngine;

public class CreeperExplosion : MonoBehaviour
{
        public bool isCanExplose;
        [SerializeField] private Vector3 distance;
        [SerializeField] private float explosionForce;
        [SerializeField] private float distanceForce;
        [SerializeField] private Animation anim;
        [SerializeField] private MeshRenderer creeperMesh;
        [SerializeField] private Material red;
        [SerializeField] private Material green;
        [SerializeField] private float timeBlinking;
        public bool isBlinking;
        [SerializeField] private AnimationClip creeperExplosion;
        [SerializeField] private CreeperReset creeperReset;

        private void OnTriggerStay(Collider other)
        {
            if (isCanExplose && (other.gameObject.CompareTag("Player")||other.gameObject.CompareTag("Block") || other.gameObject.CompareTag("Creeper")))
            {
                distance = other.gameObject.transform.position - gameObject.transform.position;
                distanceForce = distance.x + distance.y + distance.z;
                if (distanceForce<0)
                {
                    distanceForce = -distanceForce;
                }

                other.gameObject.GetComponent<Rigidbody>().AddForce(distance * explosionForce * 1 / distanceForce);
            }
        }

        public void PlayAnim()
        {
            anim.clip = creeperExplosion;
            anim.playAutomatically = false;
            anim.Play();
            if (!isBlinking)
            {
                isBlinking = true;
                StartCoroutine(Blinking(timeBlinking));
            }
        }

        public void StopAnim()
        {
            anim.Stop();
        }

        IEnumerator Blinking(float t)
        {
            if (t>0)
            {
                creeperMesh.material = red;
                yield return new WaitForSeconds(t);
                creeperMesh.material = green;
                yield return new WaitForSeconds(t);
                StartCoroutine(Blinking(t-0.1f));
            }
            else
            {
                isBlinking = false;
                yield return new WaitForSeconds(0);
            }
            
        }
        
        public IEnumerator Explose()
        {
            PlayAnim();
            yield return new WaitForSeconds(3);
            isCanExplose = true;
            Pooler.instance.Pop("ExplosionParticle").transform.position = gameObject.transform.position;
            yield return new WaitForSeconds(0.1f);
            Pooler.instance.DePop("Creeper",gameObject.transform.parent.gameObject);
            CreeperSpawner.instance.creeperCount--;
            creeperReset.ResetCreeper();
        }
        
}
