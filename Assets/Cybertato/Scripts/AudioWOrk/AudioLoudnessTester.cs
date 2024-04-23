using UnityEngine;

public class AudioLoudnessTester: MonoBehaviour
{
    public AudioSource AudioSource;
    public float UpdateStep = 0.1f;
    public int SampleDataLenth = 1024;

    private float currentUpdateTime = 0f;

    public float clipLoundness;
    private float[] clipSampleData;

    public GameObject Cobject;

    public float sizeFactor = 1;

    public float minSize = 0;
    public float MaxSize = 500;


    private void Awake()
    {
        clipSampleData = new float[SampleDataLenth];

    }

    private void Update()
    {
        currentUpdateTime += Time.deltaTime;

        if (currentUpdateTime >= UpdateStep)
        {
            currentUpdateTime = 0f;
            AudioSource.clip.GetData(clipSampleData, AudioSource.timeSamples);
            clipLoundness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoundness += Mathf.Abs(sample);
            }
            clipLoundness /= SampleDataLenth;

            clipLoundness *= sizeFactor;
            clipLoundness = Mathf.Clamp(clipLoundness, minSize, MaxSize);
            Cobject.transform.localScale = new Vector3(clipLoundness, clipLoundness, clipLoundness);
        }
    }


}
