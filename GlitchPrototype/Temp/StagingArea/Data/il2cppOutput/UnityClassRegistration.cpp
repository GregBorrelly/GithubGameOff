template <typename T> void RegisterClass();
template <typename T> void RegisterStrippedTypeInfo(int, const char*, const char*);

void InvokeRegisterStaticallyLinkedModuleClasses()
{
	// Do nothing (we're in stripping mode)
}

void RegisterStaticallyLinkedModulesGranular()
{
	void RegisterModule_Animation();
	RegisterModule_Animation();

	void RegisterModule_Audio();
	RegisterModule_Audio();

	void RegisterModule_CloudWebServices();
	RegisterModule_CloudWebServices();

	void RegisterModule_PerformanceReporting();
	RegisterModule_PerformanceReporting();

	void RegisterModule_Physics2D();
	RegisterModule_Physics2D();

	void RegisterModule_TextRendering();
	RegisterModule_TextRendering();

	void RegisterModule_UI();
	RegisterModule_UI();

	void RegisterModule_UnityAnalytics();
	RegisterModule_UnityAnalytics();

	void RegisterModule_UnityConnect();
	RegisterModule_UnityConnect();

	void RegisterModule_IMGUI();
	RegisterModule_IMGUI();

	void RegisterModule_JSONSerialize();
	RegisterModule_JSONSerialize();

	void RegisterModule_UnityWebRequest();
	RegisterModule_UnityWebRequest();

}

class EditorExtension; template <> void RegisterClass<EditorExtension>();
namespace Unity { class Component; } template <> void RegisterClass<Unity::Component>();
class Behaviour; template <> void RegisterClass<Behaviour>();
class Animation; 
class Animator; template <> void RegisterClass<Animator>();
class AudioBehaviour; template <> void RegisterClass<AudioBehaviour>();
class AudioListener; template <> void RegisterClass<AudioListener>();
class AudioSource; template <> void RegisterClass<AudioSource>();
class AudioFilter; 
class AudioChorusFilter; 
class AudioDistortionFilter; 
class AudioEchoFilter; 
class AudioHighPassFilter; 
class AudioLowPassFilter; 
class AudioReverbFilter; 
class AudioReverbZone; 
class Camera; template <> void RegisterClass<Camera>();
namespace UI { class Canvas; } template <> void RegisterClass<UI::Canvas>();
namespace UI { class CanvasGroup; } template <> void RegisterClass<UI::CanvasGroup>();
namespace Unity { class Cloth; } 
class Collider2D; template <> void RegisterClass<Collider2D>();
class BoxCollider2D; template <> void RegisterClass<BoxCollider2D>();
class CapsuleCollider2D; 
class CircleCollider2D; 
class CompositeCollider2D; 
class EdgeCollider2D; 
class PolygonCollider2D; template <> void RegisterClass<PolygonCollider2D>();
class TilemapCollider2D; 
class ConstantForce; 
class Effector2D; 
class AreaEffector2D; 
class BuoyancyEffector2D; 
class PlatformEffector2D; 
class PointEffector2D; 
class SurfaceEffector2D; 
class FlareLayer; template <> void RegisterClass<FlareLayer>();
class GUIElement; template <> void RegisterClass<GUIElement>();
namespace TextRenderingPrivate { class GUIText; } 
class GUITexture; 
class GUILayer; template <> void RegisterClass<GUILayer>();
class GridLayout; 
class Grid; 
class Tilemap; 
class Halo; 
class HaloLayer; 
class Joint2D; 
class AnchoredJoint2D; 
class DistanceJoint2D; 
class FixedJoint2D; 
class FrictionJoint2D; 
class HingeJoint2D; 
class SliderJoint2D; 
class SpringJoint2D; 
class WheelJoint2D; 
class RelativeJoint2D; 
class TargetJoint2D; 
class LensFlare; 
class Light; 
class LightProbeGroup; 
class LightProbeProxyVolume; 
class MonoBehaviour; template <> void RegisterClass<MonoBehaviour>();
class NavMeshAgent; 
class NavMeshObstacle; 
class OffMeshLink; 
class PhysicsUpdateBehaviour2D; 
class ConstantForce2D; 
class PlayableDirector; 
class Projector; 
class ReflectionProbe; 
class Skybox; 
class SortingGroup; 
class Terrain; 
class VideoPlayer; 
class WindZone; 
namespace UI { class CanvasRenderer; } template <> void RegisterClass<UI::CanvasRenderer>();
class Collider; 
class BoxCollider; 
class CapsuleCollider; 
class CharacterController; 
class MeshCollider; 
class SphereCollider; 
class TerrainCollider; 
class WheelCollider; 
namespace Unity { class Joint; } 
namespace Unity { class CharacterJoint; } 
namespace Unity { class ConfigurableJoint; } 
namespace Unity { class FixedJoint; } 
namespace Unity { class HingeJoint; } 
namespace Unity { class SpringJoint; } 
class LODGroup; 
class MeshFilter; template <> void RegisterClass<MeshFilter>();
class OcclusionArea; 
class OcclusionPortal; 
class ParticleAnimator; 
class ParticleEmitter; 
class EllipsoidParticleEmitter; 
class MeshParticleEmitter; 
class ParticleSystem; 
class Renderer; template <> void RegisterClass<Renderer>();
class BillboardRenderer; 
class LineRenderer; 
class MeshRenderer; template <> void RegisterClass<MeshRenderer>();
class ParticleRenderer; 
class ParticleSystemRenderer; 
class SkinnedMeshRenderer; 
class SpriteMask; 
class SpriteRenderer; template <> void RegisterClass<SpriteRenderer>();
class TilemapRenderer; 
class TrailRenderer; 
class Rigidbody; 
class Rigidbody2D; template <> void RegisterClass<Rigidbody2D>();
namespace TextRenderingPrivate { class TextMesh; } 
class Transform; template <> void RegisterClass<Transform>();
namespace UI { class RectTransform; } template <> void RegisterClass<UI::RectTransform>();
class Tree; 
class WorldParticleCollider; 
class GameObject; template <> void RegisterClass<GameObject>();
class NamedObject; template <> void RegisterClass<NamedObject>();
class AssetBundle; 
class AssetBundleManifest; 
class ScriptedImporter; 
class AudioMixer; 
class AudioMixerController; 
class AudioMixerGroup; 
class AudioMixerGroupController; 
class AudioMixerSnapshot; 
class AudioMixerSnapshotController; 
class Avatar; 
class AvatarMask; 
class BillboardAsset; 
class ComputeShader; 
class Flare; 
namespace TextRendering { class Font; } template <> void RegisterClass<TextRendering::Font>();
class GameObjectRecorder; 
class LightProbes; 
class Material; template <> void RegisterClass<Material>();
class ProceduralMaterial; 
class Mesh; template <> void RegisterClass<Mesh>();
class Motion; template <> void RegisterClass<Motion>();
class AnimationClip; template <> void RegisterClass<AnimationClip>();
class PreviewAnimationClip; 
class NavMeshData; 
class OcclusionCullingData; 
class PhysicMaterial; 
class PhysicsMaterial2D; template <> void RegisterClass<PhysicsMaterial2D>();
class PreloadData; template <> void RegisterClass<PreloadData>();
class RuntimeAnimatorController; template <> void RegisterClass<RuntimeAnimatorController>();
class AnimatorController; template <> void RegisterClass<AnimatorController>();
class AnimatorOverrideController; 
class SampleClip; template <> void RegisterClass<SampleClip>();
class AudioClip; template <> void RegisterClass<AudioClip>();
class Shader; template <> void RegisterClass<Shader>();
class ShaderVariantCollection; 
class SpeedTreeWindAsset; 
class Sprite; template <> void RegisterClass<Sprite>();
class SpriteAtlas; 
class SubstanceArchive; 
class TerrainData; 
class TextAsset; template <> void RegisterClass<TextAsset>();
class CGProgram; 
class MonoScript; template <> void RegisterClass<MonoScript>();
class Texture; template <> void RegisterClass<Texture>();
class BaseVideoTexture; template <> void RegisterClass<BaseVideoTexture>();
class WebCamTexture; template <> void RegisterClass<WebCamTexture>();
class CubemapArray; 
class LowerResBlitTexture; template <> void RegisterClass<LowerResBlitTexture>();
class ProceduralTexture; 
class RenderTexture; template <> void RegisterClass<RenderTexture>();
class CustomRenderTexture; 
class SparseTexture; 
class Texture2D; template <> void RegisterClass<Texture2D>();
class Cubemap; template <> void RegisterClass<Cubemap>();
class Texture2DArray; template <> void RegisterClass<Texture2DArray>();
class Texture3D; template <> void RegisterClass<Texture3D>();
class VideoClip; 
class GameManager; template <> void RegisterClass<GameManager>();
class GlobalGameManager; template <> void RegisterClass<GlobalGameManager>();
class AudioManager; template <> void RegisterClass<AudioManager>();
class BuildSettings; template <> void RegisterClass<BuildSettings>();
class CloudWebServicesManager; template <> void RegisterClass<CloudWebServicesManager>();
class CrashReportManager; 
class DelayedCallManager; template <> void RegisterClass<DelayedCallManager>();
class GraphicsSettings; template <> void RegisterClass<GraphicsSettings>();
class InputManager; template <> void RegisterClass<InputManager>();
class MonoManager; template <> void RegisterClass<MonoManager>();
class NavMeshProjectSettings; 
class PerformanceReportingManager; template <> void RegisterClass<PerformanceReportingManager>();
class Physics2DSettings; template <> void RegisterClass<Physics2DSettings>();
class PhysicsManager; 
class PlayerSettings; template <> void RegisterClass<PlayerSettings>();
class QualitySettings; template <> void RegisterClass<QualitySettings>();
class ResourceManager; template <> void RegisterClass<ResourceManager>();
class RuntimeInitializeOnLoadManager; template <> void RegisterClass<RuntimeInitializeOnLoadManager>();
class ScriptMapper; template <> void RegisterClass<ScriptMapper>();
class TagManager; template <> void RegisterClass<TagManager>();
class TimeManager; template <> void RegisterClass<TimeManager>();
class UnityAnalyticsManager; template <> void RegisterClass<UnityAnalyticsManager>();
class UnityConnectSettings; template <> void RegisterClass<UnityConnectSettings>();
class LevelGameManager; template <> void RegisterClass<LevelGameManager>();
class LightmapSettings; template <> void RegisterClass<LightmapSettings>();
class NavMeshSettings; 
class OcclusionCullingSettings; 
class RenderSettings; template <> void RegisterClass<RenderSettings>();
class RenderPassAttachment; 

void RegisterAllClasses()
{
void RegisterBuiltinTypes();
RegisterBuiltinTypes();
	//Total: 74 non stripped classes
	//0. Rigidbody2D
	RegisterClass<Rigidbody2D>();
	//1. Unity::Component
	RegisterClass<Unity::Component>();
	//2. EditorExtension
	RegisterClass<EditorExtension>();
	//3. Collider2D
	RegisterClass<Collider2D>();
	//4. Behaviour
	RegisterClass<Behaviour>();
	//5. BoxCollider2D
	RegisterClass<BoxCollider2D>();
	//6. Camera
	RegisterClass<Camera>();
	//7. GameObject
	RegisterClass<GameObject>();
	//8. QualitySettings
	RegisterClass<QualitySettings>();
	//9. GlobalGameManager
	RegisterClass<GlobalGameManager>();
	//10. GameManager
	RegisterClass<GameManager>();
	//11. Renderer
	RegisterClass<Renderer>();
	//12. GUIElement
	RegisterClass<GUIElement>();
	//13. GUILayer
	RegisterClass<GUILayer>();
	//14. Mesh
	RegisterClass<Mesh>();
	//15. NamedObject
	RegisterClass<NamedObject>();
	//16. MonoBehaviour
	RegisterClass<MonoBehaviour>();
	//17. Shader
	RegisterClass<Shader>();
	//18. Material
	RegisterClass<Material>();
	//19. Sprite
	RegisterClass<Sprite>();
	//20. SpriteRenderer
	RegisterClass<SpriteRenderer>();
	//21. Texture
	RegisterClass<Texture>();
	//22. Texture2D
	RegisterClass<Texture2D>();
	//23. RenderTexture
	RegisterClass<RenderTexture>();
	//24. Transform
	RegisterClass<Transform>();
	//25. UI::RectTransform
	RegisterClass<UI::RectTransform>();
	//26. Animator
	RegisterClass<Animator>();
	//27. AudioClip
	RegisterClass<AudioClip>();
	//28. SampleClip
	RegisterClass<SampleClip>();
	//29. AudioListener
	RegisterClass<AudioListener>();
	//30. AudioBehaviour
	RegisterClass<AudioBehaviour>();
	//31. AudioSource
	RegisterClass<AudioSource>();
	//32. WebCamTexture
	RegisterClass<WebCamTexture>();
	//33. BaseVideoTexture
	RegisterClass<BaseVideoTexture>();
	//34. TextRendering::Font
	RegisterClass<TextRendering::Font>();
	//35. UI::Canvas
	RegisterClass<UI::Canvas>();
	//36. UI::CanvasGroup
	RegisterClass<UI::CanvasGroup>();
	//37. UI::CanvasRenderer
	RegisterClass<UI::CanvasRenderer>();
	//38. PreloadData
	RegisterClass<PreloadData>();
	//39. Cubemap
	RegisterClass<Cubemap>();
	//40. Texture3D
	RegisterClass<Texture3D>();
	//41. Texture2DArray
	RegisterClass<Texture2DArray>();
	//42. MeshFilter
	RegisterClass<MeshFilter>();
	//43. MeshRenderer
	RegisterClass<MeshRenderer>();
	//44. LowerResBlitTexture
	RegisterClass<LowerResBlitTexture>();
	//45. GraphicsSettings
	RegisterClass<GraphicsSettings>();
	//46. InputManager
	RegisterClass<InputManager>();
	//47. PlayerSettings
	RegisterClass<PlayerSettings>();
	//48. ResourceManager
	RegisterClass<ResourceManager>();
	//49. RuntimeInitializeOnLoadManager
	RegisterClass<RuntimeInitializeOnLoadManager>();
	//50. TimeManager
	RegisterClass<TimeManager>();
	//51. TagManager
	RegisterClass<TagManager>();
	//52. DelayedCallManager
	RegisterClass<DelayedCallManager>();
	//53. BuildSettings
	RegisterClass<BuildSettings>();
	//54. ScriptMapper
	RegisterClass<ScriptMapper>();
	//55. MonoScript
	RegisterClass<MonoScript>();
	//56. TextAsset
	RegisterClass<TextAsset>();
	//57. MonoManager
	RegisterClass<MonoManager>();
	//58. UnityAnalyticsManager
	RegisterClass<UnityAnalyticsManager>();
	//59. PerformanceReportingManager
	RegisterClass<PerformanceReportingManager>();
	//60. UnityConnectSettings
	RegisterClass<UnityConnectSettings>();
	//61. CloudWebServicesManager
	RegisterClass<CloudWebServicesManager>();
	//62. AudioManager
	RegisterClass<AudioManager>();
	//63. Physics2DSettings
	RegisterClass<Physics2DSettings>();
	//64. LevelGameManager
	RegisterClass<LevelGameManager>();
	//65. FlareLayer
	RegisterClass<FlareLayer>();
	//66. RenderSettings
	RegisterClass<RenderSettings>();
	//67. LightmapSettings
	RegisterClass<LightmapSettings>();
	//68. Motion
	RegisterClass<Motion>();
	//69. AnimatorController
	RegisterClass<AnimatorController>();
	//70. RuntimeAnimatorController
	RegisterClass<RuntimeAnimatorController>();
	//71. AnimationClip
	RegisterClass<AnimationClip>();
	//72. PhysicsMaterial2D
	RegisterClass<PhysicsMaterial2D>();
	//73. PolygonCollider2D
	RegisterClass<PolygonCollider2D>();

}
