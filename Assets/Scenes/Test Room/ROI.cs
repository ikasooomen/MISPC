using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROI : MonoBehaviour
{

	[SerializeField]
	public GameObject cubePrefab;

	Vector3 cubeSize;
	Vector3 offset;
	const float min = -0.5f;
	const float max = 0.5f;

	int check = 0;

	void Start()
	{
		cubeSize = gameObject.transform.localScale;
		offset = gameObject.transform.localPosition;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			InstantiateSmallCubeAtRandom();
		}
	}

	void InstantiateSmallCubeAtRandom()
	{
		// �I�u�W�F�N�g�𗧕��̓��̃����_���Ȉʒu�ɃC���X�^���X������
			float xPos = GetRandomRangeInCube() * cubeSize.x;
			float yPos = GetRandomRangeInCube() * cubeSize.y;
			float zPos = GetRandomRangeInCube() * cubeSize.z;
			Vector3 position = new Vector3(xPos, yPos, zPos) + offset;

			// Prefab���C���X�^���X������
			GameObject obj = Instantiate(cubePrefab, position, Quaternion.identity);
			obj.transform.SetParent(gameObject.transform);
	}

	float GetRandomRangeInCube()
	{
		float randomRange = Random.Range(min, max);
		return randomRange;
	}
}