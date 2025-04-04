using UnityEngine;

public class StartupAudioPlayer : MonoBehaviour
{
    public AudioSource audioSource;       // 引用 AudioManager 上的 AudioSource
    public AudioClip systemInitiatingClip; // 引用“system initiating”语音剪辑

    void Start()
    {
        // 检查是否赋值，并播放语音
        if (audioSource != null && systemInitiatingClip != null)
        {
            audioSource.PlayOneShot(systemInitiatingClip);
        }
        else
        {
            Debug.LogWarning("AudioSource 或 System Initiating Clip 未赋值！");
        }
    }
}
