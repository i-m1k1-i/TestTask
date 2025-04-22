using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(AudioSource))]
public class PooledAudioSource : MonoBehaviour
{
    private AudioSource audioSource;
    private IObjectPool<PooledAudioSource> pool;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Initialize(IObjectPool<PooledAudioSource> pool)
    {
        this.pool = pool;
    }

    public void PlayClip(AudioClip clip, Vector3 position)
    {
        audioSource.transform.position = position;
        audioSource.clip = clip;
        audioSource.Play();
        StartCoroutine(ReleaseAfter(clip.length));
    }

    private IEnumerator ReleaseAfter(float length)
    {
        yield return new WaitForSeconds(length);

        pool?.Release(this);
    }
}
