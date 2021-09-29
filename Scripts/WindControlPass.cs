#if UNITY_HDRP
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;

class WindControlPass : CustomPass
{
    [Header("Wind Settings")]
    [SerializeField]
    WindSettings ws;

    protected float WindDirectionAngle
    {
        get
        {
            var time = Application.isPlaying ? Time.time : Time.realtimeSinceStartup;
            return ws.windDirection + Mathf.Cos(Mathf.PI * 2f * time / ws.windDirectionVariancePeriod) * ws.windDirectionVariance;
        }
    }

    protected Vector3 WindDirectionVector
    {
        get
        {
            return Quaternion.Euler(0f, WindDirectionAngle, 0f) * Vector3.forward;
        }
    }

    protected Vector3 WindDirectionStableVector
    {
        get
        {
            return Quaternion.Euler(0f, ws.windDirection, 0f) * Vector3.forward;
        }
    }

    protected float RealTime { get { return Application.isPlaying ? Time.time : Time.realtimeSinceStartup; } }

    // It can be used to configure render targets and their clear state. Also to create temporary render target textures.
    // When empty this render pass will render to the active camera render target.
    // You should never call CommandBuffer.SetRenderTarget. Instead call <c>ConfigureTarget</c> and <c>ConfigureClear</c>.
    // The render pipeline will ensure target setup and clearing happens in an performance manner.
    protected override void Setup(ScriptableRenderContext renderContext, CommandBuffer cmd)
    {
        // Setup code here
    }

    protected override void Execute(ScriptableRenderContext renderContext, CommandBuffer cmd, HDCamera hdCamera, CullingResults cullingResult)
    {
        SetShaderUniforms(cmd);
    }

    protected override void Cleanup()
    {
        // Cleanup code
    }

    protected virtual void SetShaderUniforms(CommandBuffer cb)
    {
        var gustStrength = ws.windGustStrengthControl.Evaluate(RealTime);
        var treeGustStrength = ws.windTreeGustStrengthControl.Evaluate(RealTime);

        var _WindData_0_0 = (Vector4)WindDirectionVector; _WindData_0_0.w = 1f;
        var _WindData_0_1 = (Vector4)WindDirectionStableVector; _WindData_0_1.w = RealTime;
        var _WindData_0 = new Matrix4x4(_WindData_0_0, _WindData_0_1, Vector4.zero, Vector4.zero);
        cb.SetGlobalMatrix("_WindData_0", _WindData_0.transpose);

        var _WindData_1_0 = new Vector4(ws.windBaseStrength * ws.windGlobalStrengthScale * ws.windGlobalStrengthScale2, ws.windBaseStrengthOffset, ws.windBaseStrengthPhase, ws.windBaseStrengthPhase2);
        var _WindData_1_1 = new Vector4(ws.windBaseStrengthVariancePeriod, ws.windGustStrength * gustStrength * ws.windGlobalStrengthScale * ws.windGlobalStrengthScale2, ws.windGustStrengthOffset, ws.windGustStrengthPhase);
        var _WindData_1_2 = new Vector4(ws.windGustStrengthPhase2, ws.windGustStrengthVariancePeriod, ws.windGustInnerCosScale, ws.windFlutterStrength * ws.windGlobalStrengthScale * ws.windGlobalStrengthScale2);
        var _WindData_1_3 = new Vector4(ws.windFlutterGustStrength * ws.windGlobalStrengthScale * ws.windGlobalStrengthScale2, ws.windFlutterGustStrengthOffset, ws.windFlutterGustStrengthScale, ws.windFlutterGustVariancePeriod);

        var _WindData_1 = new Matrix4x4(_WindData_1_0, _WindData_1_1, _WindData_1_2, _WindData_1_3);
        cb.SetGlobalMatrix("_WindData_1", _WindData_1.transpose);

        var _WindData_2_0 = new Vector4(ws.windTreeBaseStrength * ws.windGlobalStrengthScale * ws.windGlobalStrengthScale2, ws.windTreeBaseStrengthOffset, ws.windTreeBaseStrengthPhase, ws.windTreeBaseStrengthPhase2);
        var _WindData_2_1 = new Vector4(ws.windTreeBaseStrengthVariancePeriod, ws.windTreeGustStrength * treeGustStrength * ws.windGlobalStrengthScale * ws.windGlobalStrengthScale2, ws.windTreeGustStrengthOffset, ws.windTreeGustStrengthPhase);
        var _WindData_2_2 = new Vector4(ws.windTreeGustStrengthPhase2, ws.windTreeGustStrengthVariancePeriod, ws.windTreeGustInnerCosScale, ws.windTreeFlutterStrength * ws.windGlobalStrengthScale * ws.windGlobalStrengthScale2);
        var _WindData_2_3 = new Vector4(ws.windTreeFlutterGustStrength * ws.windGlobalStrengthScale * ws.windGlobalStrengthScale2, ws.windTreeFlutterGustStrengthOffset, ws.windTreeFlutterGustStrengthScale, ws.windTreeFlutterGustVariancePeriod);

        var _WindData_2 = new Matrix4x4(_WindData_2_0, _WindData_2_1, _WindData_2_2, _WindData_2_3);
        cb.SetGlobalMatrix("_WindData_2", _WindData_2.transpose);
    }
}
#endif