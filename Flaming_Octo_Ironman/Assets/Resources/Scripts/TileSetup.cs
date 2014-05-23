using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Grid))]
public class TileSetup : MonoBehaviour {

	public bool update = false;
	public bool murderChildren = false;
	public GameObject tilePrefab;


	void Awake()
	{
		if(transform.localScale != Vector3.one)
		{
			BoxCollider2D box = GetComponent<BoxCollider2D>();
			box.size = new Vector2(box.size.x * transform.localScale.x, box.size.y * transform.localScale.y);
			transform.localScale = Vector3.one;
			DestroyImmediate(GetComponent<SpriteRenderer>());
		}
	}
	
	void Update()
	{
		if(murderChildren)
		{
			List<GameObject> children = new List<GameObject>();

			foreach(Transform child in transform)
			{
				children.Add(child.gameObject);
			}

			foreach(GameObject babySeal in children)
			{
				DestroyImmediate(babySeal);
			}
			murderChildren = false;
		}

		if(update)
		{
			Setup();
			update = false;
		}
	}

	void Setup()
	{
		GameObject go = (GameObject)Instantiate(tilePrefab, Vector3.zero, Quaternion.identity);
		Grid grid = GetComponent<Grid>();
		BoxCollider2D box = GetComponent<BoxCollider2D>();
		go.transform.parent = transform;	
		Vector3 scale;
		Grid.Direction dir;
		bool at90Degrees = false;
		if( Mathf.Abs ( Mathf.Abs(transform.localRotation.z) - 0.7f ) < 0.1f)
		{
			at90Degrees = true;
		}

		if(box.size.y > box.size.x)
		{
			if(at90Degrees)
			{
				grid.direction = Grid.Direction.Horizontal;
			}
			else
			{
				grid.direction = Grid.Direction.Vertical;
			}
			scale = new Vector3(box.size.x * 3.2f, box.size.x * 3.2f, go.transform.localScale.z);
			grid.cellWidth = box.size.x;
			grid.cellHeight = box.size.x;
			go.transform.localScale = scale;

			for(int i=1; i<(box.size.y / grid.cellHeight); i++)
			{
				GameObject tile = (GameObject)Instantiate(tilePrefab, Vector3.zero, Quaternion.identity);
				tile.transform.parent = transform;
				tile.transform.localScale = scale;
			}

		}
		else
		{
			if(at90Degrees)
			{
				grid.direction = Grid.Direction.Vertical;
			}
			else
			{
				grid.direction = Grid.Direction.Horizontal;
			}
			scale = new Vector3(box.size.y * 3.2f, box.size.y * 3.2f, go.transform.localScale.z);
			grid.cellWidth = box.size.y;
			grid.cellHeight = box.size.y;
			go.transform.localScale = scale;
			for(int i=1; i<(box.size.x / grid.cellWidth); i++)
			{
				GameObject tile = (GameObject)Instantiate(tilePrefab, Vector3.zero, Quaternion.identity);
				tile.transform.parent = transform;
				tile.transform.localScale = scale;
			}

		}
		grid.centerElements = true;
		grid.Refresh();
	}
}
