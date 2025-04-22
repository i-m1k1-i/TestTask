using UnityEngine;
using UnityEngine.Pool;

public class AudioEffectsManager : MonoBehaviour
{
    public static AudioEffectsManager Instance { get; private set; }

    [SerializeField] private PooledAudioSource audioSourcePrefab;

    private ObjectPool<PooledAudioSource> pool;

    private void Awake()
    {
        Instance = this;

        pool = new ObjectPool<PooledAudioSource>(
            Create,
            OnGet,
            OnRelease,
            OnDestroyPooled,
            false,
            10,    
            20     
        );
    }

    private PooledAudioSource Create()
    {
        PooledAudioSource obj = Instantiate(audioSourcePrefab);
        obj.Initialize(pool);
        return obj;
    }

    private void OnGet(PooledAudioSource obj)
    {
        obj.gameObject.SetActive(true);
    }

    private void OnRelease(PooledAudioSource obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void OnDestroyPooled(PooledAudioSource source)
    {
        Destroy(source.gameObject);
    }

    public void PlayClip(AudioClip clip, Vector3 position)
    {
        PooledAudioSource audioSource = pool.Get();
        audioSource.PlayClip(clip, position);
    }
}
