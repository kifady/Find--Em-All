// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:32886,y:32585,varname:node_4013,prsc:2|diff-7733-OUT,emission-7733-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:31996,y:32391,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_TexCoord,id:2929,x:31331,y:32858,varname:node_2929,prsc:2,uv:0;n:type:ShaderForge.SFN_ComponentMask,id:8021,x:31543,y:32850,varname:node_8021,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-2929-U;n:type:ShaderForge.SFN_Multiply,id:4488,x:31735,y:32926,varname:node_4488,prsc:2|A-8021-OUT,B-3817-OUT;n:type:ShaderForge.SFN_Sin,id:9253,x:31899,y:32926,varname:node_9253,prsc:2|IN-4488-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3817,x:31543,y:33019,ptovrint:False,ptlb:Sin Multiplier,ptin:_SinMultiplier,varname:node_3817,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Lerp,id:7733,x:32507,y:32615,varname:node_7733,prsc:2|A-5841-RGB,B-7732-RGB,T-8881-OUT;n:type:ShaderForge.SFN_Color,id:5841,x:32221,y:32303,ptovrint:False,ptlb:Color1,ptin:_Color1,varname:node_5841,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2929282,c2:0.3759443,c3:0.9264706,c4:1;n:type:ShaderForge.SFN_Color,id:7732,x:32221,y:32488,ptovrint:False,ptlb:Color2,ptin:_Color2,varname:_Color2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.007352948,c2:0.1374238,c3:1,c4:1;n:type:ShaderForge.SFN_Time,id:880,x:31811,y:32550,varname:node_880,prsc:2;n:type:ShaderForge.SFN_Frac,id:4324,x:32320,y:32820,varname:node_4324,prsc:2|IN-5393-OUT;n:type:ShaderForge.SFN_Add,id:5393,x:32035,y:32742,varname:node_5393,prsc:2|A-1738-OUT,B-9253-OUT;n:type:ShaderForge.SFN_OneMinus,id:9805,x:31704,y:32773,varname:node_9805,prsc:2|IN-8021-OUT;n:type:ShaderForge.SFN_Sin,id:1716,x:32237,y:32910,varname:node_1716,prsc:2|IN-5393-OUT;n:type:ShaderForge.SFN_Clamp01,id:8881,x:32300,y:32688,varname:node_8881,prsc:2|IN-1716-OUT;n:type:ShaderForge.SFN_ValueProperty,id:212,x:31811,y:32695,ptovrint:False,ptlb:Speed,ptin:_Speed,varname:_SinMultiplier_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:1738,x:32095,y:32604,varname:node_1738,prsc:2|A-880-T,B-212-OUT;proporder:1304-3817-5841-7732-212;pass:END;sub:END;*/

Shader "Shader Forge/Pulse" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _SinMultiplier ("Sin Multiplier", Float ) = 1
        _Color1 ("Color1", Color) = (0.2929282,0.3759443,0.9264706,1)
        _Color2 ("Color2", Color) = (0.007352948,0.1374238,1,1)
        _Speed ("Speed", Float ) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float _SinMultiplier;
            uniform float4 _Color1;
            uniform float4 _Color2;
            uniform float _Speed;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 node_880 = _Time + _TimeEditor;
                float node_8021 = i.uv0.r.r;
                float node_5393 = ((node_880.g*_Speed)+sin((node_8021*_SinMultiplier)));
                float3 node_7733 = lerp(_Color1.rgb,_Color2.rgb,saturate(sin(node_5393)));
                float3 diffuseColor = node_7733;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = node_7733;
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float _SinMultiplier;
            uniform float4 _Color1;
            uniform float4 _Color2;
            uniform float _Speed;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 node_880 = _Time + _TimeEditor;
                float node_8021 = i.uv0.r.r;
                float node_5393 = ((node_880.g*_Speed)+sin((node_8021*_SinMultiplier)));
                float3 node_7733 = lerp(_Color1.rgb,_Color2.rgb,saturate(sin(node_5393)));
                float3 diffuseColor = node_7733;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
