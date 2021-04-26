using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class RopeScript : MonoBehaviour {

	public Vector2 destiny;

	public float speed= 1;
	
	public float distance = 2;
	public GameObject nodePrefab;
	public GameObject player;
	public GameObject lastNode;
	public LineRenderer lr;

	int vertexCount=2;
	public List<GameObject> Nodes = new List<GameObject>();


	bool done = false;

	void Start () {
		
		lr = GetComponent<LineRenderer> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		lastNode = transform.gameObject;
		Nodes.Add (transform.gameObject);
	}
	
	void Update () {
		
		transform.position = Vector2.MoveTowards (transform.position,destiny,speed);
		if ((Vector2)transform.position != destiny) {
			if (Vector2.Distance (player.transform.position, lastNode.transform.position) > distance/2)
			{
				CreateNode();
			}
		} else if (done == false) {
			done = true;
			while(Vector2.Distance (player.transform.position, lastNode.transform.position) > distance/2)
			{
				CreateNode ();
			}
			lastNode.GetComponent<SpringJoint2D> ().connectedBody = player.GetComponent<Rigidbody2D> ();
		}
		RenderLine ();
	}


	void RenderLine()
	{
		lr.SetVertexCount (vertexCount);
		int i;
		for (i = 0; i < Nodes.Count; i++) {
			lr.SetPosition (i, Nodes [i].transform.position);
		}
		lr.SetPosition (i, player.transform.position);
	}


	public void CreateNode()
	{
		Vector2 pos2Create = player.transform.position - lastNode.transform.position;
		pos2Create.Normalize();
		pos2Create *= distance;
		pos2Create += (Vector2) lastNode.transform.position;

		GameObject go = Instantiate(nodePrefab, pos2Create, Quaternion.identity);

		go.transform.SetParent(transform);
		lastNode.GetComponent<SpringJoint2D>().connectedBody = go.GetComponent<Rigidbody2D>();
		lastNode.GetComponent<SpringJoint2D>().autoConfigureDistance = false;
		lastNode.GetComponent<SpringJoint2D>().distance = 0.005f;
		lastNode.GetComponent<SpringJoint2D>().frequency = 2.5f;
		lastNode.GetComponent<SpringJoint2D>().dampingRatio = 40;
		lastNode = go;

		Nodes.Add(lastNode);

		vertexCount++;
	}

	public void AddNode()
	{
		Vector2 pos2Create = player.transform.position - lastNode.transform.position;
		pos2Create.Normalize ();
		pos2Create *= distance;
		pos2Create += (Vector2)lastNode.transform.position;

		Debug.Log(pos2Create);
		GameObject go = Instantiate (nodePrefab, pos2Create, Quaternion.identity);

		go.transform.SetParent (transform);
		lastNode.GetComponent<SpringJoint2D> ().connectedBody = go.GetComponent<Rigidbody2D> ();
		lastNode.GetComponent<SpringJoint2D>().autoConfigureDistance = false;
		lastNode.GetComponent<SpringJoint2D>().distance = 0.005f;
		lastNode.GetComponent<SpringJoint2D>().frequency = 2.5f;
		lastNode.GetComponent<SpringJoint2D>().dampingRatio = 40;
		lastNode = go;

		lastNode.GetComponent<SpringJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
		
		Nodes.Add (lastNode);

		vertexCount++;

	}
	
	
	public void DeleteNode()
	{
		// Nodes.First().
		Vector2 pos2Delete = player.transform.position - lastNode.transform.position;
		pos2Delete.Normalize ();
		pos2Delete *= distance;
		pos2Delete += (Vector2)lastNode.transform.position;
		
		// player.transform.Translate(pos2Delete);

		// GameObject go = (GameObject)	Instantiate (nodePrefab, pos2Delete, Quaternion.identity);

		// go.transform.SetParent (transform);

		// lastNode.GetComponent<HingeJoint2D> ().connectedBody = go.GetComponent<Rigidbody2D> ();
		//
		// lastNode = go;

		Destroy(lastNode.gameObject);
		Nodes.Remove(lastNode);
		lastNode = Nodes.Last().gameObject;
		lastNode.GetComponent<SpringJoint2D> ().connectedBody = player.GetComponent<Rigidbody2D> ();

		vertexCount--;

	}



}
