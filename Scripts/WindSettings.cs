using UnityEngine;

[System.Serializable]
public class WindSettings
{
    [Header("Global")]
    [SerializeField]
    [Range(0f, 1f)] public float windGlobalStrengthScale = 0.5f;
    [Range(0f, 3f)] public float windGlobalStrengthScale2 = 1f;
    [Range(0f, 360f)] public float windDirection = 65f;
    [Range(0f, 30f)] public float windDirectionVariance = 25f;
    [Range(0.01f, 20f)] public float windDirectionVariancePeriod = 15f;
    [Range(0f, 5f)] public float windZoneIntensityOffset = 0.1f;
    [Range(0f, 5f)] public float windZoneIntensityBaseScale = 0.25f;
    [Range(0f, 5f)] public float windZoneIntensityGustScale = 0.5f;
    public bool windZoneIntensityFromGrass = true;

    [Header("Grass Base")]
    [Range(0f, 75f)] public float windBaseStrength = 15f;
    [Range(0f, 3f)] public float windBaseStrengthOffset = 0.25f;
    [Range(0f, 10f)] public float windBaseStrengthPhase = 3f;
    [Range(0f, 10f)] public float windBaseStrengthPhase2 = 0f;
    [Range(0.01f, 20f)] public float windBaseStrengthVariancePeriod = 10f;

    [Header("Grass Gust")]
    [Range(0f, 75f)] public float windGustStrength = 25f;
    [Range(0f, 5f)] public float windGustStrengthOffset = 1f;
    [Range(0f, 10f)] public float windGustStrengthPhase = 3f;
    [Range(0f, 10f)] public float windGustStrengthPhase2 = 3f;
    [Range(0.01f, 10f)] public float windGustStrengthVariancePeriod = 2f;
    [Range(0f, 5f)] public float windGustInnerCosScale = 2f;
    public AnimationCurve windGustStrengthControl = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(10f, 1f));

    [Header("Grass Flutter")]
    [Range(0f, 10f)] public float windFlutterStrength = 0.4f;
    [Range(0f, 10f)] public float windFlutterGustStrength = 0.2f;
    [Range(0f, 75f)] public float windFlutterGustStrengthOffset = 50f;
    [Range(0f, 75f)] public float windFlutterGustStrengthScale = 75f;
    [Range(0.01f, 2f)] public float windFlutterGustVariancePeriod = 0.25f;

    [Header("Tree Base")]
    [Range(0f, 10f)] public float windTreeBaseStrength = 0.25f;
    [Range(0f, 5f)] public float windTreeBaseStrengthOffset = 1f;
    [Range(0f, 2f)] public float windTreeBaseStrengthPhase = 0.5f;
    [Range(0f, 2f)] public float windTreeBaseStrengthPhase2 = 0f;
    [Range(0.01f, 20f)] public float windTreeBaseStrengthVariancePeriod = 6f;

    [Header("Tree Gust")]
    [Range(0f, 10f)] public float windTreeGustStrength = 3f;
    [Range(0f, 5f)] public float windTreeGustStrengthOffset = 1f;
    [Range(0f, 10f)] public float windTreeGustStrengthPhase = 2f;
    [Range(0f, 10f)] public float windTreeGustStrengthPhase2 = 3f;
    [Range(0.01f, 10f)] public float windTreeGustStrengthVariancePeriod = 4f;
    [Range(0f, 5f)] public float windTreeGustInnerCosScale = 2f;
    public AnimationCurve windTreeGustStrengthControl = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(10f, 1f));

    [Header("Tree Flutter")]
    [Range(0f, 5f)] public float windTreeFlutterStrength = 0.1f;
    [Range(0f, 5f)] public float windTreeFlutterGustStrength = 0.5f;
    [Range(0f, 75f)] public float windTreeFlutterGustStrengthOffset = 12.5f;
    [Range(0f, 75f)] public float windTreeFlutterGustStrengthScale = 25f;
    [Range(0.01f, 2f)] public float windTreeFlutterGustVariancePeriod = 0.1f;
}
