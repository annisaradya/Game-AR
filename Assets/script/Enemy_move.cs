using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_move : MonoBehaviour
{
	public float speed = 3.0f;
	public float obstacleRange = 5.0f;

	private bool _alive;

	public GameObject paintballPrefab;
	private GameObject _paintball;

	void Start () {
		StartCoroutine ("Move");
		_alive = true;
	}

	void Update () {
		if (_alive) {
			transform.Translate (0, 0, speed * Time.deltaTime);
		}

		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;
		if (Physics.SphereCast (ray, 0.75f, out hit)) {
			GameObject hitObject = hit.transform.gameObject;
			if (hitObject.GetComponent<PlayerInfo> ()) {
				if (_paintball == null) {
					_paintball = Instantiate (paintballPrefab) as GameObject;
					_paintball.transform.position = transform.TransformPoint (Vector3.forward * 1.5f);
					_paintball.transform.rotation = transform.rotation;
				}
			} else if (hit.distance < obstacleRange) {
				float angle = Random.Range (-110, 110);
				transform.Rotate (0, angle, 0);
			}
		}
	}

	public void SetAlive(bool alive) {
		_alive = alive;
	}
	IEnumerator Move() {
    while (true) {
      yield return new WaitForSeconds (3f);
      transform.eulerAngles += new Vector3 (0, 180f, 0);
      transform.eulerAngles += new Vector3 (0, 90f, 0);
      transform.eulerAngles += new Vector3 (0, 45f, 0);
    }
  }
}
