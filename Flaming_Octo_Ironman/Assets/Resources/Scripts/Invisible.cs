using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Invisible : MonoBehaviour {

	private List<SpriteRenderer> renderers = new List<SpriteRenderer>();

	void Awake()
	{
		if(Application.isPlaying)
		{
			renderers.AddRange(GetComponentsInChildren<SpriteRenderer>());
			foreach(SpriteRenderer r in renderers)
			{
				Color c = r.color;
				c.a = 0;
				r.color = c;
			}
		}
		else
		{
			if( transform.parent.GetComponent<Invisible>())
			{
				if(transform.localPosition != Vector3.zero)
				{
					transform.parent.position = transform.position;
					transform.localPosition = Vector3.zero;
				}

				if(transform.parent.localScale != Vector3.one)
				{
					BoxCollider parentBox = transform.parent.GetComponent<BoxCollider>();
					parentBox.size = new Vector3(parentBox.size.x * transform.parent.localScale.x, parentBox.size.y * transform.parent.localScale.y, parentBox.size.z);
					transform.parent.localScale = Vector3.one;


					BoxCollider2D box = GetComponent<BoxCollider2D>();
					transform.localScale = Vector3.one;
					box.size = new Vector2(parentBox.size.x, parentBox.size.y);
				}

				if(transform.parent.localRotation != Quaternion.identity)
				{
					BoxCollider parentBox = transform.parent.GetComponent<BoxCollider>();
					if( Mathf.Abs ( Mathf.Abs(transform.parent.localRotation.z) - 0.7f ) < 0.1f)
					{
						parentBox.size = new Vector3(parentBox.size.y, parentBox.size.x, parentBox.size.z);
					}

					transform.localRotation = transform.parent.localRotation;
					transform.parent.localRotation = Quaternion.identity;
				}

				if(GetComponent<SpriteRenderer>())
				{
					DestroyImmediate(GetComponent<SpriteRenderer>());
				}

				if(!GetComponent<TileSetup>())
				{
					Grid g = this.gameObject.AddComponent<Grid>();
					TileSetup setup = this.gameObject.AddComponent<TileSetup>();
					setup.tilePrefab = PrefabHolder.instance.spikePrefab;
					setup.update = true;
				}

			}

		}
	}

	public void SetVisible(bool visible)
	{
		foreach(SpriteRenderer r in renderers)
		{
			Color c = r.color;
			c.a = visible ? 1.0f : 0f;
			r.color = c;
		}
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if(c.GetComponent<MagicLens>())
			SetVisible(true);
	}

	void OnTriggerExit2D(Collider2D c)
	{
		if(c.GetComponent<MagicLens>())
			SetVisible(false);
	}
}
