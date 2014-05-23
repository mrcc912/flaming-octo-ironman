using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Grid : MonoBehaviour {

#if UNITY_EDITOR
	public bool refreshNow = false;
#endif
	public float cellWidth = 2.0f;
	public float cellHeight = 2.0f;
	public Direction direction;
	public bool centerElements = false;
	public bool ignoreScale = false;
	public List<GameObject> elements;


	// Use this for initialization
	void Start () 
	{
		elements = new List<GameObject>();
		Refresh();
	}

#if UNITY_EDITOR
	void Update()
	{
		if(refreshNow)
		{
			Refresh();
			refreshNow = false;
		}
	}
#endif

	public void Refresh()
	{
		elements.Clear();
		int count = 0;
		foreach(Transform child in transform)
		{
			child.localPosition = Vector3.zero; // resetting to the center of the grid.
			Vector3 toPosition = child.position;
			if(direction == Direction.Horizontal)
			{
				toPosition.x += cellWidth * count;
			}
			else
			{
				toPosition.y += cellHeight * count;
			}
			child.position = toPosition;
			elements.Add(child.gameObject);
			++count;
		}
		if(centerElements)
		{
			foreach(Transform child in transform)
			{
				Vector3 toPosition = child.position;
				if(direction == Direction.Horizontal)
				{
					toPosition.x -= ((count-1) * (cellWidth/2));
				}
				else
				{
					toPosition.y -= ((count-1) * (cellHeight/2));
				}
				child.position = toPosition;
			}

		}
	}

	public enum Direction
	{
		Horizontal,
		Vertical
	}
}
