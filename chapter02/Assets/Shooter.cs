using UnityEngine;
using System.Collections;

//可直接拖拽脚本文件到要作用的游戏对象上
public class Shooter : MonoBehaviour {

	public Rigidbody bullet;
	public float power = 1500f;
	public float moveSpeed = 2f;
	
	void Start () {
	
	}

	void Update () {
		//Input.GetAxis返回-1到1之间的小数
		float hVal = Input.GetAxis ("Horizontal");
		//print("hVal="+hVal);
		float h = hVal * Time.deltaTime * moveSpeed;

		float vVal = Input.GetAxis ("Vertical");
		//print("vVal="+vVal);
		float v = vVal * Time.deltaTime * moveSpeed;

		//transform可以直接被使用是因为每个游戏对象都有Transform组件，Vector3是形如(x,y,z)的三维向量
		transform.Translate (h, v, 0);
		if(Input.GetButtonUp("Fire1")){
			//使用Instantiate创建（克隆）预设（模板）对象，as是C#里面做声明转换
			Rigidbody instance = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
			//使用TransformDirection把本地坐标转换为世界坐标，此处Vector3.forward为(0,0,1)代表z轴1个单位（即前方）
			Vector3 fwd = transform.TransformDirection(Vector3.forward);
			//使用Rigidbody.AddForce为刚体添加作用力，力的方向由其参数Vector3指定，此处即代表正前方*power的力
			instance.AddForce(fwd * power);
		}

		//当玩家按下Esc键后退出
		if(Input.GetKeyDown(KeyCode.Escape)){
			UnityEditor.EditorApplication.isPlaying = false; //编辑器模式下退出
			Application.Quit(); //游戏模式下退出
		}
	}
}
