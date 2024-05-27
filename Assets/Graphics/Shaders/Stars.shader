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
            #include "Colors.cginc"

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

            float3 spacePalette(float t)
            {
                float3 a = float3(0.821, 0.328, 0.242);
                float3 b = float3(0.659, 0.481, 0.896);
                float3 c = float3(0.612, 0.340, 0.296);
                float3 d = float3(2.820, 3.026, -0.273);
                return palette(t, a, b, c, d);
            }

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

                float n1 = simplex(i.localPos.xz * _StarScale + i.center.xz * _Parallax);
                float stars = pow(n1, 20);
                col += stars;

                float n2 = simplex(i.localPos.xz * _StarScale * 0.7 + 69 + i.center.xz * _Parallax * 0.9);
                float stars2 = pow(n2, 20);
                col += stars2;

                float n3 = simplex(i.localPos.xz * 5) * 0.4;
                float a = n3 + _Time.y * 0.1;
                float2 galaxyOffset = float2(cos(a), sin(a));
                float3 galaxyPos = i.localPos * _StarScale * 0.01;
                float galaxy = simplex(galaxyPos.xz * 3 + galaxyOffset * 0.2 + n3 * 1 + pow(n2, 5)  * 0.03);
                col += pow(galaxy, 3) * spacePalette(length(galaxyPos)) * 0.1;
                col += galaxy * spacePalette(galaxyPos.x * 1) * 0.1;

                return float4(col, 0);
            }
            ENDCG
        }
    }
}
