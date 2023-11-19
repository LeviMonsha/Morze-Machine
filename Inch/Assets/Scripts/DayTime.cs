using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DayTime : MonoBehaviour
{
    [SerializeField] Gradient direcrionalLightGradient;
    [SerializeField] Gradient ambientLightGradient;
    [SerializeField, Range(1,3600)] float timeDayInSeconds = 60;
    [SerializeField, Range(0f,1f)] float timeProgress;
    [SerializeField] Light dirLight;
    Vector3 defaultAngles;
    void Start()
    {
        defaultAngles = dirLight.transform.locatEulerAngles;
    }

    void Update()
    {
      if (Application.isPlaying)
        timeProgress += timeDayInSeconds.deltaTime / timeDayInSeconds;

        if (timeProgress > 1f) timeProgress = 0f;

        dirLight.color = direcrionalLightGradient.Evaluate(timeProgress);
        RenderSettings.ambientLight = ambientLightGradient.Evaluate(timeProgress);

        dirLight.transform.locatEulerAngles = new Vector3(360f * timeProgress - 90, defaultAngles.x, defaultAngles.z);
    }
}
