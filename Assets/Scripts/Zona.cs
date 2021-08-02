using UnityEngine;

public class Zona : MonoBehaviour
{
	public Transform target;

	public float scrollSpeed = 10.0f;

	public float zoomMin = 1.0f;

	public float zoomMax = 20.0f;

	public float distance;

	public Vector3 position;

	float x = 0.0f;

	float y = 0.0f;


	void Start()
	{
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
	}



	void LateUpdate()
	{	if (Input.GetAxis("Mouse ScrollWheel") != 0)

		{
			distance = Vector3.Distance(transform.position, target.position);
				distance = ZoomLimit(distance - Input.GetAxis("Mouse ScrollWheel") * scrollSpeed, zoomMin, zoomMax);
				position = -(transform.forward * distance) + target.position;
				transform.position = position;
		}

	}



	public static float ZoomLimit(float dist, float min, float max)

	{
		if (dist < min)
			dist = min;
		if (dist > max)
			dist = max;
		return dist;
	}
}
