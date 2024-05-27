Shader "Unlit/Stars"
{
    Properties
    {
        _StarScale ("Star Scale", float) = 1
        _Parallax ("Parallax", float) = 1
        _StarZ ("Star Z", float) = 20
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" }

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
            float _StarZ;

            v2f vert (appdata v)
            {
                v2f o;
                o.localPos = v.vertex;
                o.center = localToWorld(0);

                float3 worldPos = localToWorld(v.vertex);
                float3 camToWorld = worldPos - _WorldSpaceCameraPos;
                worldPos = _WorldSpaceCameraPos + camToWorld * _StarZ;
                o.vertex = UnityObjectToClipPos(worldToLocal(worldPos));
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
