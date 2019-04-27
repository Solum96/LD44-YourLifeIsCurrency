// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Enemy"
{
    Properties
    {
    	_Color ("Color", Color) = (0,0,0,1)
    	_Color2 ("Color2", Color) = (0,0,0,1)
    	_Amount ("Amount", Range(0,1)) = 0.05
    	_Shift ("Shift", Range(0,1)) = 0.2
    	_Frequency ("Frequency", Range(0,1)) = 0.75
    	_Speed ("Speed", Range(0,100)) = 8
    }
 
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
                #include "UnityCG.cginc"
                #pragma vertex vert
                #pragma fragment frag
 
                struct v2f
                {
                    half4 color : COLOR;
                    fixed4 pos : SV_POSITION;
                };

				float rand(float3 myVector)  
				{
             		return frac(sin(dot(myVector ,float3(12.9898,78.233,45.5432) )) * 43758.5453);
             		//return frac(sin(dot(uv ,float3(12.9898,78.233,45.5432) )) * 43758.5453);
             		//return frac(sin(dot(uv ,float2(200,500)*1.0)) * 100);

         		}
                fixed4 _Color;
                fixed4 _Color2;

                float _Amount;
                float _Frequency;
                float _Speed;
                float _Shift;
           
                v2f vert(appdata_full v)
                {
		            float anim = (sin((_Time * (_Speed * 10)) + (rand(v.vertex.xyz) * (_Frequency * 10))) + _Shift );
		            anim = anim * anim * anim;
                	v.vertex.xyz += v.normal * (0.5 + (anim * 0.5)) * _Amount;

                    v2f o;
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.color = lerp(_Color2, _Color, anim);
                    return o;
                }
       
                fixed4 frag(v2f i) : COLOR
                {
                    return i.color;
                }

            ENDCG
        }
    }
}