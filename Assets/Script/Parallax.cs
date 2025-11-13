using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Parallax : MonoBehaviour
{
    Renderer rend;
    Material mat;
    float distance;

    [Range(0f, 5f)] public float speed = 0.2f;
    public string textureProperty = "_MainTex";
    int texId;

    void Awake()
    {
        rend = GetComponent<Renderer>();

        if (rend == null)
            rend = GetComponentInChildren<Renderer>();

        if (rend == null)
        {
            Debug.LogError("[Parallax] No se encontró Renderer en " + gameObject.name);
            enabled = false;
            return;
        }

        mat = rend.material;
        if (mat == null)
        {
            Debug.LogError("[Parallax] Renderer no tiene material asignado en " + gameObject.name);
            enabled = false;
            return;
        }

        texId = Shader.PropertyToID(textureProperty);
        if (!mat.HasProperty(texId))
        {
            Debug.LogWarning("[Parallax] El material no tiene la propiedad de textura: " + textureProperty);
        }
    }

    void Update()
    {
        if (mat == null) return;

        distance += speed * Time.deltaTime;
        Vector2 offset = mat.GetTextureOffset(texId);
        offset.x = distance;
        mat.SetTextureOffset(texId, offset);
    }
}
