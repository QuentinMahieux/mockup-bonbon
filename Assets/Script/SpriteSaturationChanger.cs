using UnityEngine;

public class SpriteSaturationChanger : MonoBehaviour
{
    [Range(0, 2)] public float saturation = 1f; // Valeur de saturation (1 = normal)
    public SpriteRenderer spriteRenderer;
    private MaterialPropertyBlock propertyBlock;
    private static readonly int SaturationID = Shader.PropertyToID("_Saturation");

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        propertyBlock = new MaterialPropertyBlock();
        UpdateSaturation();
    }

    void Update()
    {
        UpdateSaturation();
    }

    void UpdateSaturation()
    {
        spriteRenderer.GetPropertyBlock(propertyBlock);
        propertyBlock.SetFloat(SaturationID, saturation);
        spriteRenderer.SetPropertyBlock(propertyBlock);
    }
}
