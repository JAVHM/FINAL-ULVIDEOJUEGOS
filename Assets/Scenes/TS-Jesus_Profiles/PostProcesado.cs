using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.Rendering.PostProcessing;

public class PostProcesado : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    [SerializeField] public float intensity = 0f;
    [SerializeField] public float intensityBase = 0f;
    [SerializeField] public float minIntensity = -15f;
    private float timeElapsed;
    [SerializeField] private float accelerationTime = 4f;
    private LensDistortion lensDistortionEffect;

    public bool elTurbo;

    private void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings(out lensDistortionEffect);
        intensityBase = 0;
        elTurbo = false;
    }
    public void Update()
    {
        intensity = lensDistortionEffect.intensity.value;
        if (elTurbo)
        {
            lensDistortionEffect.intensity.value = Mathf.SmoothStep(intensity, minIntensity, timeElapsed / accelerationTime);//currentSpeed = Mathf.SmoothStep(currentSpeed, thrust, timeElapsed / accelerationTime);
            timeElapsed += Time.deltaTime;
        }
        else
        {
            lensDistortionEffect.intensity.value = Mathf.SmoothStep(intensity, intensityBase, timeElapsed / accelerationTime);//currentSpeed = Mathf.SmoothStep(currentSpeed, thrust, timeElapsed / accelerationTime);
            timeElapsed += Time.deltaTime;
        }
    }
}
