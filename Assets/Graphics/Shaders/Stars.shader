Shader "Unlit/Stars"
{
    Properties
    {
        _StarScale ("Star Scale", float) = 1
        _Parallax ("Parallax", float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry-1" }
        LOD 100
        // ZWrite Off
        ZTest Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "Noise.cginc"
            #include "Math.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 localPos : TEXCOORD0;
                float3 center : TEXCOORD1;
            };

            float _StarScale;
            float _Parallax;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.localPos = v.vertex;
                o.center = localToWorld(0);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float3 col = 0;

                float stars = simplex(i.localPos.xz * _StarScale + i.center.xz * _Parallax);
                stars = pow(stars, 20);
                col += stars;

                return float4(col, 0);
            }
            ENDCG
        }
    }
}
