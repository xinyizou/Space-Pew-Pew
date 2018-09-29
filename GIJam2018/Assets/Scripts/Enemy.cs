using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float lifeTime = 1;
	float startTime;
	float endTime;

	Camera camera;

	void Start()
	{
		startTime = Time.time;
		endTime = startTime + lifeTime;
		camera = Camera.main;
	}
	
	void Update()
	{
		if(camera == null)
		{
			camera = Camera.current;
			Debug.Log("couldn't find camera");
			return;
		}
		float t = (Time.time - startTime) / lifeTime % 1;
		float x = Mathf.Pow(Mathf.Cos((t - 0.125f) * 2 * Mathf.PI), 2);
		float y = 1 - Mathf.Pow(2 * (t - 0.125f), 2);
		Vector3 pos = new Vector3(x, y, 0);
		pos.Scale(new Vector3(camera.pixelWidth, camera.pixelHeight));
		pos = camera.ScreenToWorldPoint(pos);
		pos.z = 0;
		Debug.Log(pos);
		transform.position = pos;
	}
}
