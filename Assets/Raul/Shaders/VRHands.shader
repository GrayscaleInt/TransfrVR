Shader "Unlit/Custom Shaders/VRHands"
{
    
    Properties
    {
        _baseColor ("Base Color", Color) = (1, 1, 1, 1)
        _rimThickness ("Rim Thickness", Range(0, 45)) = 0.5
        _opacityIntensity ("Opacity Intensity", Range(0, 1)) = 0.5
    }
    
    SubShader
    {
        Tags { "Queue" = "Transparent" }
        
        Pass
        {
            ZWrite On
            ColorMask 0
        }
        
        CGPROGRAM
        
        #pragma surface surf Lambert alpha:fade
        
        fixed4 _baseColor;
        half _rimThickness;
        half _opacityIntensity;
        
        struct Input
        {
            float2 uv_mainTex;
            float3 viewDir;
        };
        
        void surf(Input IN, inout SurfaceOutput o)
        {
            half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
            
            o.Emission = _baseColor.rgb * pow(rim, _rimThickness) * 10.0;
            o.Alpha = pow(rim, _rimThickness) * _opacityIntensity;
        }
        ENDCG
    }
    
    Fallback "DIFFUSE"
}