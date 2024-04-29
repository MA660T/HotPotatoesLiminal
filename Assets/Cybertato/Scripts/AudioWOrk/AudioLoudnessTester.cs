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
    private Color Newcolor;
    private float Red;
    private float green;
    private float blue;
    private Renderer Renderre;
    private float RandomMultiplier;
    private void Awake()
    {
        clipSampleData = new float[SampleDataLenth];
        Renderre = Cobject.GetComponent<Renderer>();
        RandomMultiplier = Random.Range(1f, 3f);

    }
    private void Start()
    {
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
        Red = Random.Range(0f, 1f);
        green = Random.Range(0f, 1f);
        blue = Random.Range(0f, 1f);
        Newcolor = new Color(Red, green, blue);
        Renderre.material.SetColor("_Color", Newcolor);
    }

}
