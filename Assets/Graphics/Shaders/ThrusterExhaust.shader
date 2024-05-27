Shader "Unlit/ThrusterExhaust"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }       
        Blend One OneMinusSrcColor

        ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float4 texcoord0 : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                uint index : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            float3 _Color;

            v2f vert (appdata v)
            {
                v2f o;

                float2 uv = v.texcoord0.xy;
                uint index = v.texcoord0.z;

                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(uv, _MainTex);
                o.index = index;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uvOffset = 0;
                uvOffset.x = i.index % 2;
                uvOffset.y = (i.index % 4) >= 2;

                float2 uv = i.uv / 2 + uvOffset * 0.5;

                fixed4 col = tex2D(_MainTex, uv);
                col *= 2;
                return float4(col.xyz * _Color, col.w);
            }
            ENDCG
        }
    }
}
