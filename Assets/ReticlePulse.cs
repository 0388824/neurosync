using UnityEngine;
using UnityEngine.UI;

public class ReticlePulse : MonoBehaviour
{
    [SerializeField] private Image reticleImage;
    [SerializeField] private float pulseSpeed = 2f;
    [SerializeField] private float minScale = 0.8f;
    [SerializeField] private float maxScale = 3.0f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime * pulseSpeed;
        float scale = Mathf.Lerp(minScale, maxScale, (Mathf.Sin(timer) + 1) / 2f);
        transform.localScale = new Vector3(scale, scale, 1);
    }
}
