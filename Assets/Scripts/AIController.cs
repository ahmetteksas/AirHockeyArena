using UnityEngine;

[System.Serializable]
public class AIBoundarie
{
	public float xMin, xMax, zMin, zMax;
}

public class AIController : MonoBehaviour {

	private Rigidbody rb;
	private GameObject diskObject;
	private bool opponentSide = true;
    private float diskOffset;
	private Vector3 targetPos;

	public GameObject disk;
	public AIBoundarie boundarie;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();

		diskObject = GameObject.FindWithTag ("Disk");
	}

	void LateUpdate ()
	{
		var aiPos = new Vector3
			(
				Mathf.Clamp (rb.position.x, boundarie.xMin, boundarie.xMax),
				0.55f,
				Mathf.Clamp (rb.position.z, boundarie.zMin, boundarie.zMax)
			);

		float speed;

		if (diskObject.transform.position.z < 0)
        {
            if (opponentSide)
            {
                opponentSide = false;
                diskOffset = Random.Range(-1f, 1f);
            }
 
            speed = 10 * Random.Range(0.1f, 0.3f);

            targetPos = new Vector3
			(
				Mathf.Clamp(diskObject.transform.position.x + diskOffset, boundarie.xMin, boundarie.xMax),
				0.0f,
				5.0f
			);
        }
        else
        {

            opponentSide = true;
 
            speed = Random.Range(12,16);

            targetPos = new Vector3
			(
				Mathf.Clamp(diskObject.transform.position.x, boundarie.xMin, boundarie.xMax),
				0.0f,
                Mathf.Clamp(diskObject.transform.position.z, boundarie.zMin, boundarie.zMax)
			);
        }

        if (Variables.diskmovecontrol == false)
        {
			rb.MovePosition(Vector3.MoveTowards(aiPos, targetPos, speed * Time.fixedDeltaTime));
		}



		float dist = Vector3.Distance(gameObject.transform.position, disk.transform.position);
		if (dist < 1f)
        {
			opponentSide = false;
			Debug.Log(dist);
			//disk.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 3000));
			disk.transform.position = new Vector3(disk.transform.position.x, disk.transform.position.y, disk.transform.position.z - 0.5f);
		}


	}



}
