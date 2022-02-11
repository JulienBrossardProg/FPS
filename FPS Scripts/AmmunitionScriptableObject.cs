using UnityEngine;


[CreateAssetMenu(menuName = "Create new munition", fileName = "Munition")]
public class AmmunitionScriptableObject : ScriptableObject
{
    public string munitionName;
    public int damage;
    public float speed;
    public Color color;
    public int price;
    public Texture2D icon;
}
