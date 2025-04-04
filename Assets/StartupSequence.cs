using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartupSequence : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject systemInitiatingText;   // “System Initiating” 文字UI
    public Slider progressBar;                // 进度条 Slider 对象
    public GameObject reticle;                // reticle 对象
    public GameObject peripheralContainer;    // peripheralContainer 对象（包含 peripheralData 文本和背景 Image）
    public GameObject panelTime;              // panel time 对象
    public GameObject liveContainer;          // liveContainer 对象（包含 liveText 文本和背景 Image）

    [Header("Audio")]
    public AudioSource audioSource;           // 用于播放语音的 AudioSource
    public AudioClip systemInitiatingClip;    // “System Initiating” 的语音剪辑

    [Header("Timing")]
    public float displayDuration = 5f;        // “System Initiating” 显示及进度条填满的总时长（秒）

    void Start()
    {
        // 初始状态：显示 System Initiating 和进度条，隐藏其他 UI 元素
        systemInitiatingText.SetActive(true);
        progressBar.gameObject.SetActive(true);
        reticle.SetActive(false);
        peripheralContainer.SetActive(false);
        panelTime.SetActive(false);
        liveContainer.SetActive(false);

        // 播放语音
        if (audioSource != null && systemInitiatingClip != null)
        {
            audioSource.PlayOneShot(systemInitiatingClip);
        }

        // 开始启动流程
        StartCoroutine(RunStartupSequence());
    }

    IEnumerator RunStartupSequence()
    {
        float timer = 0f;
        progressBar.value = 0f;

        // 在 displayDuration 内逐渐填满进度条
        while (timer < displayDuration)
        {
            timer += Time.deltaTime;
            progressBar.value = timer / displayDuration;
            yield return null;
        }

        // 进度条填满后，隐藏 System Initiating 和进度条
        systemInitiatingText.SetActive(false);
        progressBar.gameObject.SetActive(false);

        // 激活其他 UI 元素
        reticle.SetActive(true);
        peripheralContainer.SetActive(true);
        panelTime.SetActive(true);
        liveContainer.SetActive(true);

        // 强制设置背景框（Image组件）的颜色为黑色，以确保背景显示
        Image peripheralImage = peripheralContainer.GetComponent<Image>();
        if (peripheralImage != null)
        {
            peripheralImage.color = new Color(0, 0, 0, 1);
        }
        Image liveImage = liveContainer.GetComponent<Image>();
        if (liveImage != null)
        {
            liveImage.color = new Color(0, 0, 0, 1);
        }

        Debug.Log("Activated reticle, peripheralContainer, panelTime, and liveContainer.");
    }
}
