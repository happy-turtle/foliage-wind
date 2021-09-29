using UnityEngine;

// https://answers.unity.com/questions/157940/getoutputdata-and-getspectrumdata-they-represent-t.html
public static class AudioVolumeAnalyzer
{
    // RMS value for 0dB
    public static float refValue = 0.1f;

    private static float[] samples = new float[4096];

    public static float DBVolume
    {
        get { return SampleDecibelVolume(); }
    }
    public static float RMS
    {
        get { return SampleRMSVolume(); }
    }


    static float SampleDecibelVolume()
    {
        AudioListener.GetOutputData(samples, 0);
        float sum = 0;
        for (int i = 0; i < samples.Length; i++)
        {
            sum += samples[i] * samples[i];
        }
        float rootMeanSquare = Mathf.Sqrt(sum);
        return Mathf.Clamp(20 * Mathf.Log10(rootMeanSquare / refValue), -100, 100);
    }

    static float SampleRMSVolume()
    {
        AudioListener.GetOutputData(samples, 0);
        float sum = 0;
        for (int i = 0; i < samples.Length; i++)
        {
            sum += samples[i] * samples[i];
        }
        return Mathf.Sqrt(sum);
    }
}
