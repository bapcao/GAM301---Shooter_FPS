using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //Tham chiếu
    [SerializeField] private Light directionalLight; // Tên biến đã được sửa
    [SerializeField] private LightingPreset preset; // Tên biến đã được sửa
    [SerializeField] private Transform orbitCenter; // Thêm tâm quỹ đạo
    [SerializeField, Range(0, 24)] private float timeOfDay; // Tên biến đã được sửa

    // Tham số quỹ đạo
    [SerializeField] private float orbitRadius = 100f; // Bán kính quỹ đạo
    [SerializeField] private float orbitHeight = 50f; // Độ cao so với địa hình


    private void Update()
    {
        if (preset == null || directionalLight == null || orbitCenter == null)
            return;

        if (Application.isPlaying)
        {
            timeOfDay += Time.deltaTime;
            timeOfDay %= 24; // Giới hạn giữa 0-24
            UpdateLighting(timeOfDay / 24f);
        }
        else
        {
            UpdateLighting(timeOfDay / 24f);
        }
    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.FogColor.Evaluate(timePercent);

        // Tính toán vị trí quỹ đạo
        float angle = timePercent * 360f;
        Vector3 orbitPosition = orbitCenter.position + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad) * orbitRadius, orbitHeight, Mathf.Sin(angle * Mathf.Deg2Rad) * orbitRadius);

        // Thiết lập vị trí và xoay đèn
        directionalLight.transform.position = orbitPosition;
        directionalLight.transform.LookAt(orbitCenter); // Hướng đèn về phía tâm

        directionalLight.color = preset.DirectionalColor.Evaluate(timePercent); // Sử dụng DirectionalColor
    }

    private void OnValidate()
    {
        if (directionalLight != null)
            return;

        if (RenderSettings.sun != null)
        {
            directionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    directionalLight = light;
                    return;
                }
            }
        }
    }
}