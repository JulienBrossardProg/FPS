using UnityEngine;

public class CreeperReset : MonoBehaviour
{
    [SerializeField] private CreeperMovement creeperMovement;
    [SerializeField] private Material green;
    [SerializeField] private MeshRenderer creeperMesh;
    [SerializeField] private CreeperExplosion creeperExplosion;

    public void ResetCreeper()
    {
        creeperMesh.material = green;
        creeperExplosion.isCanExplose = false;
        creeperMovement.isCloseX = false;
        creeperMovement.isCloseZ = false;
        creeperMovement.isClosePlayerX = false;
        creeperMovement.isClosePlayerZ = false;
        creeperExplosion.StopAnim();
        creeperMovement.anim.clip = creeperMovement.creeperMovementAnim;
        creeperMovement.anim.playAutomatically = true;
        creeperExplosion.isBlinking = false;
    }
    
}
