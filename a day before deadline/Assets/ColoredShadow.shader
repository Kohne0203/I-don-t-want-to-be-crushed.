Shader "Example/ColoredShadow" {

    Properties{
        _MainTex("Texture", 2D) = "white" {}
        _ShadowColor("ShadowColor", Color) = (0,0,1,1)

    }

    SubShader{
        Tags { "RenderType" = "Opaque" }

        CGPROGRAM
        #pragma surface surf SimpleLambert
        sampler2D _MainTex;
        half4 _ShadowColor;

        // uv座標
        struct Input {
            float2 uv_MainTex; 
        };

        void surf(Input IN, inout SurfaceOutput o) {

            o.Albedo = tex2D(_MainTex, IN.uv_MainTex); //テクスチャ貼り付け

        }

        // SimpleLambertの設定 lightDir:光方向 atten:影のパラメータ
        half4 LightingSimpleLambert(SurfaceOutput s, half3 lightDir, half atten) {

            //ライティング計算（表面法線と光方向の内積）

            half NdotL = dot(s.Normal, lightDir);
            half4 c;

            c.rgb = s.Albedo * _LightColor0.rgb * (NdotL * min((atten + _ShadowColor.rgb), 1) * 1.5); //影に色を付ける
            c.a = s.Alpha;

            return c;
        }
        ENDCG
    }
    Fallback "Diffuse"
}