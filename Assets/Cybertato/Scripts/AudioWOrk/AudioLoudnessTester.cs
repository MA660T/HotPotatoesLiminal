using UnityEngine;

public class AudioLoudnessTester : MonoBehaviour
{
    public AudioSource AudioSource;
    public float UpdateStep = 0.01f;
    public int SampleDataLenth = 1024;
    private float currentUpdateTime = 0f;
    public float clipLoundness;
    private float[] clipSampleData;
    public GameObject Cobject;
    public float sizeFactor = 1;
    public float minSize = 0;
    public float MaxSize = 500;

    Color Pink = new Color(255, 0, 193, 1);
    Color Purple = new Color(150, 0, 255, 1);
    Color DBlue = new Color(73, 0, 255, 1);
    Color Mblue = new Color(0, 184, 255, 1);
    Color Lblue = new Color(0, 255, 149, 1);
    Color salmon = new Color(255, 2165, 151, 1);
    Color coral = new Color(255, 174, 151, 1);
    Color orange = new Color(255, 197, 108, 1);
    Color yellow = new Color(255, 299, 86, 1);

    private Color[] RandomColor;

    private Renderer Renderre;
    private float RandomMultiplier;

    private void Awake()
    {
        clipSampleData = new float[SampleDataLenth];
        Renderre = Cobject.GetComponent<Renderer>();
        RandomMultiplier = Random.Range(1f, 3f);
        RandomColor = new Color[] { Pink, Purple, DBlue, Mblue, Lblue,salmon,coral,orange,yellow };
        SetColor();
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
            Cobject.transform.localScale = new Vector3(1, clipLoundness*RandomMultiplier, 1);
        }
    }

    private void SetColor()
    {
        int RandomPick = Random.Range(0,RandomColor.Length);
        Renderre.material.SetColor("_Color", RandomColor[RandomPick]);
    }

}
