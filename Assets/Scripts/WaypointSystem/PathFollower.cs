using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
	public float _speed;
	[SerializeField] private float _arrivalThresholds;

	private PlayerHeath _playerHealth;
	private EnemyBehavior _EnemyBehavior;
	private EnemySpawner _enemySpawner;
	private Path _path;
	private Waypoint _currentWaypoint;

	// Start is called before the first frame update
	void Start()
	{
		SetupPath();
	}

	// Update is called once per frame
	void Update()
	{
		_speed = _EnemyBehavior._speed;

		Vector3 WaypointPosition = _currentWaypoint.GetPosition();
		transform.LookAt(_currentWaypoint.GetPosition() + new Vector3(0,transform.position.y,0));
		transform.Translate(Vector3.forward * _speed * Time.deltaTime);

		float DistanceToWaypoint = Vector3.Distance(transform.position, WaypointPosition);
		if (DistanceToWaypoint < _arrivalThresholds)
		{
			//Debug.Log("NEXT ONE");

			if (_currentWaypoint == _path.GetEndPath())
			{
				pathComplete();
			}
			else
			{
				_currentWaypoint = _path.NextWaypoint(_currentWaypoint);
				transform.LookAt(_currentWaypoint.GetPosition());
			}
		}
	}

	private void pathComplete()
	{
		//Debug.Log("PathComplete");
		Destroy(gameObject);
		_enemySpawner.targetsCount.Remove(gameObject);

		_playerHealth.MinHealth(1);

	}

	private void SetupPath()
	{
		_playerHealth = FindObjectOfType<PlayerHeath>();
		_EnemyBehavior = FindObjectOfType<EnemyBehavior>();
		_enemySpawner = FindObjectOfType<EnemySpawner>();

		_path = FindObjectOfType<Path>();
		_currentWaypoint = _path.GetWaypoint();
	}
}
