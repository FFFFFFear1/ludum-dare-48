using UnityEngine;
using System.Collections;
using System.Timers;

public class throwhook : MonoBehaviour {


	public GameObject hook;


	public bool ropeActive;
	public int grappableLayerNumber = 9;
	GameObject curHook;
	
	Vector2 Mouse_FirePoint_DistanceVector;
	
	
	[SerializeField] private bool hasMaxDistance = true;
	[SerializeField] private float maxDistance = 40;


	private float timer_1 = 0.1f;
	private float timer_2 = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Mouse_FirePoint_DistanceVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

		timer_1 -= Time.deltaTime;
		timer_2 -= Time.deltaTime;

		if (Input.GetMouseButtonDown(0)) {

			RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Mouse_FirePoint_DistanceVector.normalized);
			// Debug.Log(hits[0].transform.gameObject.name);
			// Debug.Log(hits[2].transform.gameObject.layer == grappableLayerNumber);
			// Debug.Log(Vector2.Distance(hits[2].point, transform.position));
			// Debug.Log((Vector2.Distance(hits[2].point, transform.position) <= maxDistance));
			
			if (hits[2].transform.gameObject.layer == grappableLayerNumber &&
			    (Vector2.Distance(hits[2].point, transform.position) <= maxDistance))
			{
				if (ropeActive == false)
				{
					var pos = new Vector3(hits[2].point.x, hits[2].point.y,0);
					Debug.Log(pos);
					Vector2 destiny = pos;

					curHook = Instantiate(hook, transform.position, Quaternion.identity);

					curHook.GetComponent<RopeScript>().destiny = destiny;

					ropeActive = true;
				}
			}
		}
		if (Input.GetMouseButtonUp(0))
		{
			Destroy(curHook);
			ropeActive = false;
		}
		if (Input.GetKey(KeyCode.W))
		{
			if (timer_1 <= 0)
			{
				curHook.GetComponent<RopeScript>().DeleteNode();

				timer_1 = .1f;
			}
		}
		if (Input.GetKey(KeyCode.S))
		{
			if (timer_2 <= 0)
			{
				curHook.GetComponent<RopeScript>().AddNode();

				timer_2 = .1f;
			}
		}
	}
}
