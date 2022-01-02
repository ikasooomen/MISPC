using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjInstanciate : MonoBehaviour
{

	[SerializeField]
	GameObject cubePrefab;

	[SerializeField]
	int batchNum = 5;

	Vector3 cubeSize;
	Vector3 offset;
	const float min = -0.5f;
	const float max = 0.5f;

	void Start()
	{
		cubeSize = gameObject.transform.localScale;
		offset = gameObject.transform.localPosition;
	}

	void Update()
	{
		InstantiateSmallCubeAtRandom();
	}

	void InstantiateSmallCubeAtRandom()
	{
		// オブジェクトを立方体内のランダムな位置にインスタンス化する
		for (int i = 1; i <= batchNum; i++)
		{
			float xPos = GetRandomRangeInCube() * cubeSize.x;
			float yPos = GetRandomRangeInCube() * cubeSize.y;
			float zPos = GetRandomRangeInCube() * cubeSize.z;
			Vector3 position = new Vector3(xPos, yPos, zPos) + offset;

			// Prefabをインスタンス化する
			GameObject obj = Instantiate(cubePrefab, position, Quaternion.identity);
			obj.transform.SetParent(gameObject.transform);
		}
	}

	float GetRandomRangeInCube()
	{
		float randomRange = Random.Range(min, max);
		return randomRange;
	}
}