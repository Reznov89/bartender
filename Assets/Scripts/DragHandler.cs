using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour 
{
	bool isDraggable = false,
		 isMoving = false,
		 checkCollision = false,
		 backAgain = false,
		 collideSomething = false;
	Ray ray;
	float speed = 0;
	Vector3 originalPosition;
	public BeerProperties beerProperties;
	public DefinitiveBeerManager beerManager;
	int glass, 
		beer,
		level;

	#region Public Methods
	public void DraggingOn()
	{
		isDraggable = true;
	}

	public void DraggingOff()
	{
		isDraggable = false;
	}

	#endregion

	#region Private Methods
	
	void Start()
	{
		originalPosition = transform.position;
	}

	void Update()
	{
		 if (Input.touchCount > 0 && isDraggable)
		{
			Touch touch = Input.GetTouch(0);
			Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
		
			switch (touch.phase)
			{
				case TouchPhase.Began:
					//print("began draggin");
					if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
					{
						isMoving = true;
					}
				break;

				case TouchPhase.Moved:
				if (isMoving)
					this.transform.position = touchPos;
				break;

				case TouchPhase.Ended:
					if (isMoving)
					{
						checkCollision = true;
						isMoving = false;
						backAgain = true;
						print("Release");
					}
				break;
			}
		}

		if (backAgain) 
		{
			speed = 100 * Time.deltaTime; 
			transform.position = Vector3.MoveTowards(transform.position, originalPosition, speed);
			if (transform.position == originalPosition)
			{
				speed = 0;
				backAgain = false;
				collideSomething = false;
				checkCollision = false;
			}
			//	
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (checkCollision)
		{
			print("Colliding checking " + col.name);

			if (col.gameObject.CompareTag("Drunk"))
			{
				print("cliente");
				glass = beerProperties.GetGlassSelected();
				beer = beerProperties.GetBeer();
				level = beerProperties.GetBeerLevel();
				col.gameObject.GetComponent<Drunk>().ReceiveBeer(glass, beer, level);
				beerManager.Remake();
				collideSomething = true;
				//backAgain = true;
			
				DraggingOff();
			}
			else if (col.gameObject.CompareTag("Player"))
			{
				print("On Barman");
				col.GetComponent<Barman>().Drink();
				beerManager.Remake();
				
				collideSomething = true;
				//backAgain = true;
				DraggingOff();
			}
		
			if (!collideSomething)
			{
				print("nothing");
				DraggingOff();
				beerManager.Remake();
				beerManager.Spilled();
				//backAgain = true;
				
			}

			checkCollision = false;
			print (collideSomething);
		}
	}

	/* 
	void ObjectTagDetection()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit2D raycast = Physics2D.Raycast(new Vector2(ray.origin.x, ray.origin.y), Vector3.forward);

		if (raycast.collider != null && raycast.collider.tag == "Beer")
		{
			raycast.collider.transform.position = new Vector3(ray.origin.x, ray.origin.y, raycast.collider.transform.position.z);
		}
	}
	*/

	#endregion

}
