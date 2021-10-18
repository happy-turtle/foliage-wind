using UnityEngine.Rendering.Universal;

public class WindControlRenderFeature : ScriptableRendererFeature
{
    public WindSettings windSettings = new WindSettings();
    WindControlPass windControlPass;

    public override void Create()
    {
        windControlPass = new WindControlPass(windSettings);
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(windControlPass);
    }
}
