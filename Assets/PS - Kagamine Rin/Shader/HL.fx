#define RimLight_Bone "Rim_Rin.pmx"


#define additive_alpha

#define Eyelight_Speed 15
#define Eyelight_Range 0.005

#define use_distortion

#define _DistortionFPS 12

#define distortion1 "eye_distortion.png"


#define _DistortionTexTilingX 0.65f
#define _DistortionTexTilingY 0.65

#define _DistortionScrollSpeed 0.8f

#define _DistortionScrollX 0.602f
#define _DistortionScrollY 0.62f

#define _DistortionIntensity 0.5f
#define _DistortionIntensityX 0.1f
#define _DistortionIntensityY 0.3f

#define _DistortionOffsetX 0
#define _DistortionOffsetY 0

#define force_front_light // Only affects facemap lighting


#define _OutlineWidth 0.001f
#define _OutlineL 0.5
#define _OutlineOffset 0 

#define _SekaiShadowThreshold 0.5f

#define facemap "faceSdf.png"

#define _CharacterId 0

#define _SekaiShadowColor float4(1.0f, 1.0f, 1.0f, 1.0f)

#define _SekaiCharacterAmbientLightColor float4(1.0, 1.0, 1.0, 1.0) // one of the many things needed that do nothing lol


#define _SekaiRimLightColor float4(0.0, 0.0, 0.0, 1.0)
#define _SekaiShadowRimLightColor float4(0.5, 0.5, 0.5, 1.0)
#define _SekaiRimLightFactor float4(200.0, 0.0, 1000.0, 0.015)
#define _RimThreshold 0.5f
#define _SekaiRimLightShadowSharpness 0.51f

#define _SpecularPower 22.0f // not a lot of models use it?
#define _SekaiCharacterSpecularColor float4(1.0f, 1.0f, 1.0f, 0.0f)

#include <shader.fxsub>