using UnityEngine; 
using System.Collections;

public class Move : MonoBehaviour
{
    private float Target;
	[SerializeField]
	private Transform CameraPos;
    private void Start()
    {
		Target = OverridingSettings.menuTarget;
		transform.position = new Vector3(transform.position.x, transform.position.y, OverridingSettings.menuCameraZ);
	}
    void Update()
	{
		//Target +=  -Time.deltaTime / 125;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, Target), 0.05f);
		if (transform.position.z >= -100)
		{ 
			Target = -500;
		}
		if (transform.position.z <= -500)
		{ 
			Target = -100;
		}
	}
}