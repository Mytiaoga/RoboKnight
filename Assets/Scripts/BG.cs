using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    public UnityEngine.UI.RawImage img;
    [SerializeField] bool flip;

    private Texture2D backgroundTexture;
    [SerializeField] float r, g, b;

    void Awake()
    {
        if (!flip)
        {
            backgroundTexture = new Texture2D(1, 2);
            backgroundTexture.wrapMode = TextureWrapMode.Clamp;
            backgroundTexture.filterMode = FilterMode.Bilinear;
            //SetColor(Color.black, Color.white);
            //SetColor(Color.black, Color.blue);
            //SetColor(Color.black, new Color32(0, 151, 255, 255));
            SetColor(Color.black, new Color32((byte)r, (byte)g, (byte)b, 255));
        }
        if (flip)
        {
            backgroundTexture = new Texture2D(1, 2);
            backgroundTexture.wrapMode = TextureWrapMode.Clamp;
            backgroundTexture.filterMode = FilterMode.Bilinear;
            SetColor(new Color32((byte)r, (byte)g, (byte)b, 255), Color.black);
        }

    }

    public void SetColor(Color color1, Color color2)
    {
        backgroundTexture.SetPixels(new Color[] { color1, color2 });
        backgroundTexture.Apply();
        img.texture = backgroundTexture;
    }
}
