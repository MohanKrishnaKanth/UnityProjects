using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class GraphCreator : MonoBehaviour
{
	public Transform primitivePrefab;
	[Range(10, 100)]
	public int resolution = 10;
	Transform[] points, points2, points3, points4, points5, points6, points7, points8;
	public bool doubleSin, verticalDualSin, CosSin, normalSin;
	private void Start()
	{
		float step = 2f / resolution; // Range -1 to 1 means 2 units / resolution will halve all objects in 2 from -1 to 1
		Vector3 scale = Vector3.one * step;
		Vector3 position = new Vector3();
		position.z = 0f;

		points = new Transform[resolution];
		points2 = new Transform[resolution];
		points3 = new Transform[resolution];
		points4 = new Transform[resolution];
		points5 = new Transform[resolution];
		points6 = new Transform[resolution];
		points7 = new Transform[resolution];
		points8 = new Transform[resolution];

		if (normalSin)
		{

			for (int i = 0; i < points.Length; i++)
			{
				Transform point = Instantiate(primitivePrefab);
				//position.y = (i) /resolution;  -->> makes "n" no of objects will be placed in between 2 units i.e -1 to 1
				//above thing is calculated as "step" and multiplied to position on x
				//basically now it is 0 to 2 range , we subtract by 1 on calculated vector to make -1 to 1 range on x.
				//now it ranges like from -1.1 to 0.8 we added 0.5 to shift half a cube by right which becomes -1 to 1 range.
				position.x = (i + 0.5f) * step - 1f;

				position.x += 3.5f; // placing position to see in scene at good position

				point.localPosition = position;
				point.localScale = scale;
				point.SetParent(transform, false);
				points[i] = point;
			}


			if(doubleSin)
			{
				for (int i = 0; i < points2.Length; i++)
				{
					Transform point = Instantiate(primitivePrefab);
					position.x = (i + 0.5f) * step - 1f;

					position.x -= 3.5f; // placing position to see in scene at good position

					point.localPosition = position;
					point.localScale = scale;
					point.SetParent(transform, false);
					points2[i] = point;
				}
			}
		}

		if (verticalDualSin)
		{
			for(int i = 0; i < points3.Length;++i)
			{
				Transform point = Instantiate(primitivePrefab);
				Transform point2 = Instantiate(primitivePrefab);
				position.y = (i + 0.5f) * step - 1f;

				position.y -= 1.3f; // placing position to see in scene at good position

				point.localPosition = point2.localPosition = position;
				point.localScale = point2.localScale =  scale;
				point.SetParent(transform, false);
				point2.SetParent(transform, false);
				points3[i] = point;
				points4[i] = point2;
			}
		}

		if (CosSin)
		{
			for (int i = 0; i < points5.Length; i++)
			{
				Transform point = Instantiate(primitivePrefab);
				Transform point2 = Instantiate(primitivePrefab);
				position.x = (i + 0.5f) * step - 1f;
				point.localPosition =  position;

				position.x -= 3.5f; // placing position to see in scene at good position


				point2.localPosition = position;
				point.localScale = point2.localScale = scale;
				point.SetParent(transform, false);
				point2.SetParent(transform, false);
				points5[i] = point;
				points6[i] = point2;
			}

			for (int i = 0; i < points7.Length; i++)
			{
				Transform point = Instantiate(primitivePrefab);
				Transform point2 = Instantiate(primitivePrefab);
				position.y = (i + 0.5f) * step - 1f;

				position.y += 1.6f; // placing position to see in scene at good position

				point.localPosition = point2.localPosition = position;
				point.localScale = point2.localScale = scale;
				point.SetParent(transform, false);
				point2.SetParent(transform, false);
				points7[i] = point;
				points8[i] = point2;
			}

		}



	}

	private void Update()
	{
		float t = Time.time;

		if (normalSin)
		{
			for (int i = 0; i < points.Length; i++)
			{
				Transform point = points[i];
				Vector3 position = point.localPosition;

				//position.y=doubleSin? SineFunction(position.x, t) : MultiSineFunction(position.x, t);

				position.y = SineFunction(position.x, t);

				position.y -= 1.3f; // placing position to see in scene at good position

				point.localPosition = position;
			}


			if(doubleSin)
			{

				for (int i = 0; i < points4.Length; i++)
				{
					Transform point = points2[i];
					Vector3 position = point.localPosition;
					position.y = MultiSineFunction(position.x, t);

					position.y -= 1.3f; // placing position to see in scene at good position
					point.localPosition = position;
				}
			}

		}



		if (verticalDualSin)
		{
			for (int i = 0; i < points2.Length; i++)
			{
				Transform point = points3[i];
				Vector3 position = point.localPosition;
				position.x = SineFunction(position.y, t) ;
				point.localPosition = position;

				point = points4[i];
				position = point.localPosition;
				position.x = -(Mathf.Sin(Mathf.PI * (position.y + t)));
				point.localPosition = position;

			}
		}

		if (CosSin)
		{
			for (int i = 0; i < points.Length; i++)
			{
				Transform point = points5[i];
				Vector3 position = point.localPosition;
				position.y = Mathf.Sin(Mathf.PI * (position.x * t));

				position.y += 1.6f; // placing position to see in scene at good position
				point.localPosition = position;

				point = points6[i];
				position = point.localPosition;
				position.y = Mathf.Cos(Mathf.PI/2 * (position.x - t));

				position.y += 1.6f; // placing position to see in scene at good position
				point.localPosition = position;

			}


			for (int i = 0; i < points.Length; i++)
			{
				Transform point = points7[i];
				Vector3 position = point.localPosition;
				position.x = (Mathf.Sin(Mathf.PI * (position.y - t)));

				position.x += 3.5f; // placing position to see in scene at good position

				point.localPosition = position;

				point = points8[i];
				position = point.localPosition;
				position.x = -(Mathf.Cos(Mathf.PI * (position.y + t)));

				position.x += 3.5f; // placing position to see in scene at good position
				point.localPosition = position;

			}


		}

		

	}


	float SineFunction(float xPosition, float time)
	{
		return Mathf.Sin(Mathf.PI * (xPosition + time));
	}

	float MultiSineFunction(float xPosition, float time)
	{
		float y = Mathf.Sin(Mathf.PI * (xPosition + time));
		y += Mathf.Sin(2f * Mathf.PI * (xPosition + 2f * time))/2f; // doubled sine and to keep shape as original sine we divided by 2 
		y *= 2f / 3f; // sine function are 1 and −1, the max and mini values of this new function will be 1.5 and −1.5 so we divide by 1.5 which is the same as multiplying by 2/3
		return y;

	}
}
