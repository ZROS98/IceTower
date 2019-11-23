using UnityEngine;

public class ScrollUV : MonoBehaviour
{
    public float paralax = 2;
    private void Update()
    {      
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        Material mat = meshRenderer.material;
        Vector2 offset = mat.mainTextureOffset;
        offset.y += Time.deltaTime / paralax;
        mat.mainTextureOffset = offset;
    }
}
