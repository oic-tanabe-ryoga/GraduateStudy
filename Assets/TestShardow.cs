using UnityEngine;
using System.Collections;

public class TestShardow : MonoBehaviour {

	private RenderTexture renderTex;
	private GameObject Live2D_Quad;
	private GameObject Live2D_Cam;
	private Renderer Quad_render;
	private Camera dummyCam;
	// 影のX,Y軸ずらす
	private float transX =  0.04f;
	private float transY =  0.02f;
	// RenderTextureがぼやける場合は2048にする
	public int renderSize = 1024;
	// カラー調整用(実行中に変更するとエラーになるので実行前に値を変更)
	public Color rgba = new Color(0.0f, 0.0f, 0.0f, 1.0f);  // 黒


	void Awake () {

		// 一時的なRenderTextureを割り当てます(迅速にRenderTextureを表示したい場合)
		renderTex = RenderTexture.GetTemporary(renderSize, renderSize, 16, RenderTextureFormat.ARGB32);

		// Quadを生成(RenderTexture描画用)
		Live2D_Quad = GameObject.CreatePrimitive(PrimitiveType.Quad); 

		// Live2Dモデルの座標をセット
		Live2D_Quad.transform.position = new Vector3(transX + gameObject.transform.position.x, transY + gameObject.transform.position.y, 0.0f);

		// シェーダー指定とRenderTextureをセット
		Quad_render = Live2D_Quad.GetComponent<Renderer>();
		// Unity5.3からUI/Defaultが上手く機能しなくなったのでSpritesにする
		// Quad_render.material.shader = Shader.Find("UI/Default");
		Quad_render.material.shader = Shader.Find("Sprites/Default");
		Quad_render.material.SetTexture("_MainTex", renderTex);
		Quad_render.name = gameObject.name + "_Quad"; 
		// Quadのカラーを変更
		Quad_render.material.color = rgba;


		// Live2Dを映す第2カメラ
		Live2D_Cam = new GameObject("Live2D Camera");
		Live2D_Cam.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
		Live2D_Cam.AddComponent<Camera>(); 

		// カメラの設定とRenderTextureをセット
		dummyCam = Live2D_Cam.GetComponent<Camera>();
		dummyCam.orthographic = true;
		dummyCam.orthographicSize = 1;
		dummyCam.backgroundColor = new Color (1.0f ,1.0f, 1.0f, 0.0f);  // アルファを0.0にしないとノイズが入る
		dummyCam.clearFlags = CameraClearFlags.SolidColor;
		dummyCam.targetTexture = renderTex; 

	}

	void Update () {
		// QuadとLive2Dモデルサイズを同期
		Live2D_Quad.transform.localScale = gameObject.transform.localScale * 4.0f;
		// orthographicSizeとLive2Dモデルサイズを同期
		dummyCam.orthographicSize = Mathf.Max(gameObject.transform.localScale.x, gameObject.transform.localScale.y) * 2.0f;

		if(Live2D_Quad){
			Quad_render.material.color = rgba;

		}
	}

	void OnDestroy(){
		// Live2DのGameObjectが削除されたらダミーで作ったものも削除
		RenderTexture.ReleaseTemporary(renderTex);
		Destroy(Live2D_Cam);
		Destroy(Live2D_Quad);
	}
}