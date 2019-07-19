// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:False,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32703,y:32433,varname:node_4013,prsc:2|emission-5985-OUT,alpha-3702-OUT,clip-5327-OUT;n:type:ShaderForge.SFN_NormalVector,id:1183,x:30760,y:32038,prsc:2,pt:True;n:type:ShaderForge.SFN_Dot,id:6226,x:31002,y:31988,varname:node_6226,prsc:2,dt:4|A-9055-OUT,B-1183-OUT;n:type:ShaderForge.SFN_ViewVector,id:9055,x:30668,y:31851,varname:node_9055,prsc:2;n:type:ShaderForge.SFN_OneMinus,id:3702,x:31549,y:32296,varname:node_3702,prsc:2|IN-99-OUT;n:type:ShaderForge.SFN_Color,id:6476,x:31556,y:31873,ptovrint:False,ptlb:Rim Ccolor,ptin:_RimCcolor,varname:node_6476,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.3266652,c2:0.7535616,c3:0.8382353,c4:1;n:type:ShaderForge.SFN_Slider,id:4149,x:31443,y:33026,ptovrint:False,ptlb:Cutoff value,ptin:_Cutoffvalue,varname:node_4149,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8252872,max:1;n:type:ShaderForge.SFN_Add,id:6246,x:32153,y:32738,varname:node_6246,prsc:2|A-8986-OUT,B-9804-OUT;n:type:ShaderForge.SFN_Multiply,id:5327,x:32412,y:32886,varname:node_5327,prsc:2|A-6246-OUT,B-5314-OUT;n:type:ShaderForge.SFN_RemapRange,id:9804,x:31838,y:32848,varname:node_9804,prsc:2,frmn:0,frmx:1,tomn:0,tomx:0.5|IN-4149-OUT;n:type:ShaderForge.SFN_RemapRange,id:5314,x:31852,y:33057,varname:node_5314,prsc:2,frmn:0,frmx:1,tomn:0.5,tomx:1|IN-4149-OUT;n:type:ShaderForge.SFN_Power,id:99,x:31236,y:32081,varname:node_99,prsc:2|VAL-6226-OUT,EXP-6277-OUT;n:type:ShaderForge.SFN_Slider,id:6277,x:30631,y:32222,ptovrint:False,ptlb:Rim Power,ptin:_RimPower,varname:node_6277,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.026745,max:4;n:type:ShaderForge.SFN_Multiply,id:948,x:31010,y:32438,varname:node_948,prsc:2|A-8203-OUT,B-8203-OUT;n:type:ShaderForge.SFN_Abs,id:8203,x:30801,y:32438,varname:node_8203,prsc:2|IN-7324-OUT;n:type:ShaderForge.SFN_Append,id:6857,x:30509,y:32631,varname:node_6857,prsc:2|A-9135-Y,B-9135-Z;n:type:ShaderForge.SFN_Append,id:7667,x:30509,y:32764,varname:node_7667,prsc:2|A-9135-Z,B-9135-X;n:type:ShaderForge.SFN_Append,id:9697,x:30509,y:32902,varname:node_9697,prsc:2|A-9135-X,B-9135-Y;n:type:ShaderForge.SFN_NormalVector,id:7324,x:30602,y:32404,prsc:2,pt:False;n:type:ShaderForge.SFN_FragmentPosition,id:9135,x:30216,y:32743,varname:node_9135,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:5979,x:30509,y:33070,ptovrint:False,ptlb:Tiling,ptin:_Tiling,varname:node_1563,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:1191,x:30730,y:32902,varname:node_1191,prsc:2|A-9697-OUT,B-5979-OUT;n:type:ShaderForge.SFN_Multiply,id:9647,x:30730,y:32632,varname:node_9647,prsc:2|A-6857-OUT,B-5979-OUT;n:type:ShaderForge.SFN_Multiply,id:4271,x:30730,y:32767,varname:node_4271,prsc:2|A-7667-OUT,B-5979-OUT;n:type:ShaderForge.SFN_ChannelBlend,id:8986,x:31468,y:32669,varname:node_8986,prsc:2,chbt:0|M-948-OUT,R-7874-R,G-2204-R,B-4582-R;n:type:ShaderForge.SFN_Tex2d,id:7874,x:31020,y:32614,varname:node_6829,prsc:2,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-9647-OUT,TEX-5777-TEX;n:type:ShaderForge.SFN_Tex2d,id:2204,x:31020,y:32804,varname:_node_6829_copy,prsc:2,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-4271-OUT,TEX-5777-TEX;n:type:ShaderForge.SFN_Tex2d,id:4582,x:31020,y:32994,varname:_node_6829_copy_copy,prsc:2,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-1191-OUT,TEX-5777-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:5777,x:30723,y:33176,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:_Texture_copy,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:5985,x:31897,y:32126,varname:node_5985,prsc:2|A-6476-RGB,B-3702-OUT;proporder:4149-6476-6277-5979-5777;pass:END;sub:END;*/

Shader "Shader Forge/Additive Rim with 3PlanarCutoffMask" {
    Properties {
        _Cutoffvalue ("Cutoff value", Range(0, 1)) = 0.8252872
        _RimCcolor ("Rim Ccolor", Color) = (0.3266652,0.7535616,0.8382353,1)
        _RimPower ("Rim Power", Range(0, 4)) = 1.026745
        _Tiling ("Tiling", Float ) = 1
        _Texture ("Texture", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float4 _RimCcolor;
            uniform float _Cutoffvalue;
            uniform float _RimPower;
            uniform float _Tiling;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 node_8203 = abs(i.normalDir);
                float3 node_948 = (node_8203*node_8203);
                float2 node_9647 = (float2(i.posWorld.g,i.posWorld.b)*_Tiling);
                float4 node_6829 = tex2D(_Texture,TRANSFORM_TEX(node_9647, _Texture));
                float2 node_4271 = (float2(i.posWorld.b,i.posWorld.r)*_Tiling);
                float4 _node_6829_copy = tex2D(_Texture,TRANSFORM_TEX(node_4271, _Texture));
                float2 node_1191 = (float2(i.posWorld.r,i.posWorld.g)*_Tiling);
                float4 _node_6829_copy_copy = tex2D(_Texture,TRANSFORM_TEX(node_1191, _Texture));
                clip((((node_948.r*node_6829.r + node_948.g*_node_6829_copy.r + node_948.b*_node_6829_copy_copy.r)+(_Cutoffvalue*0.5+0.0))*(_Cutoffvalue*0.5+0.5)) - 0.5);
////// Lighting:
////// Emissive:
                float node_3702 = (1.0 - pow(0.5*dot(viewDirection,normalDirection)+0.5,_RimPower));
                float3 emissive = (_RimCcolor.rgb*node_3702);
                float3 finalColor = emissive;
                return fixed4(finalColor,node_3702);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float _Cutoffvalue;
            uniform float _Tiling;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 node_8203 = abs(i.normalDir);
                float3 node_948 = (node_8203*node_8203);
                float2 node_9647 = (float2(i.posWorld.g,i.posWorld.b)*_Tiling);
                float4 node_6829 = tex2D(_Texture,TRANSFORM_TEX(node_9647, _Texture));
                float2 node_4271 = (float2(i.posWorld.b,i.posWorld.r)*_Tiling);
                float4 _node_6829_copy = tex2D(_Texture,TRANSFORM_TEX(node_4271, _Texture));
                float2 node_1191 = (float2(i.posWorld.r,i.posWorld.g)*_Tiling);
                float4 _node_6829_copy_copy = tex2D(_Texture,TRANSFORM_TEX(node_1191, _Texture));
                clip((((node_948.r*node_6829.r + node_948.g*_node_6829_copy.r + node_948.b*_node_6829_copy_copy.r)+(_Cutoffvalue*0.5+0.0))*(_Cutoffvalue*0.5+0.5)) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
