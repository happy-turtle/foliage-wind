using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class MoveSlider : MonoBehaviour
{
    public float maxSliderSpeed = 0.1f;
    CinemachineTrackedDolly dolly;

    float start = 0f;
    float end = 1f;
    float currentTarget;
    float velocity = 0f;

    void Start()
    {
        CinemachineVirtualCamera cam = GetComponent<CinemachineVirtualCamera>();
        dolly = cam.GetCinemachineComponent<CinemachineTrackedDolly>();
        dolly.m_PathPosition = 0f;
        currentTarget = end;
    }

    // Update is called once per frame
    void Update()
    {
        if (dolly != null)
        {
            dolly.m_PathPosition = Mathf.SmoothDamp(dolly.m_PathPosition, currentTarget, ref velocity, Time.deltaTime, maxSliderSpeed);
        }
        if (dolly.m_PathPosition >= 1f)
        {
            currentTarget = start;
        }
        else if (dolly.m_PathPosition <= 0f)
        {
            currentTarget = end;
        }
    }
}
