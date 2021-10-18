# Foliage Wind in Unity's HDRP and URP

![Animation](https://user-images.githubusercontent.com/18415215/135335027-c538e787-7998-4c2f-9016-4d4253e9602c.gif)

These are some experiments with the assets and wind system of Unity's demo project [Book of the Dead](https://unity.com/demos/book-dead). The wind system they built is described in [this blog post](https://blogs.unity3d.com/pt/2018/06/29/book-of-the-dead-quixel-wind-scene-building-and-content-optimization-tricks/).
I updated the wind shader and wrote Custom Passes in the High Definition Render Pipeline and Universal Render Pipeline to integrate the wind system and assets in Unity 2020.
I experimented a bit with getting basic audio volume level to control the wind strength. Like they also mentioned in their blog post. My HDRP implementation is on the main branch, while the URP version got a separate branch in this repository.

## Wind Shader

The wind calculations are updated to work with current versions of ShaderGraph. Unfortunately the wind shader is only usable with assets of the Book of the Dead project!
The pivot information for the trees, grass and bushes is baked into the assets' UV maps using different bit ranges for each value (see code example below). To reuse this wind system it would probably be easier to split the different shader parts for tree trunk, tree branches and grass into separate shaders.
And then define the pivots by splitting the assets into multiple objects for trunk and branches. Just like Unity's [Fontainebleau demo](https://github.com/Unity-Technologies/FontainebleauDemo) is doing it.

    // packedData.x
    // Bit 0-9 	= pivotPos0.z
    // Bit 10-21 	= pivotPos0.y
    // Bit 21-31 	= pivotPos0.x
    //************
    // packedData.y
    // Bit 0      = pivotFwd1.y
    // Bit 1-7    = pivotFwd1.z
    // Bit 8-15   = pivotFwd1.x
    // Bit 16 	= pivotFwd0.y
    // Bit 17-23	= pivotFwd0.z
    // Bit 24-31 	= pivotFwd0.x
    //************
    // packedData.z
    // Bit 0 	= pivotPos1.z
    // Bit 1-7      = pivotPos1.y
    // Bit 8-16 	= pivotPos1.x
