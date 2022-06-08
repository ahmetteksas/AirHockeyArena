using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
	public UI_Manager UI_Manager;
	public DiskController diskcontroller;

	private Rigidbody rb;

	public float moveSpeed = 10f;
	public float maxSpeed;

	private Touch touch;

	private bool uicontrol = false;

    void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{

		//Touch Controls
		
		if (Input.touchCount > 0)
		{
			touch = Input.GetTouch(0);

            switch (touch.phase)
            {
				case TouchPhase.Began:
					//Make sure that pointer is not over UI before calling
					if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
					{
						if (uicontrol == false)
						{
							Variables.firsttouch = 1;
							UI_Manager.GetComponent<UI_Manager>().FirstTouchThanDisappear();
							diskcontroller.TimeDecreasefunc();
							uicontrol = true;
						}

					}
					break;

				case TouchPhase.Moved:

                    if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    {
						rb.velocity = (new Vector3(touch.deltaPosition.x * moveSpeed * Time.deltaTime,
												   transform.position.y,
												   touch.deltaPosition.y * moveSpeed * Time.deltaTime));


						if (uicontrol == false)
						{
							Variables.firsttouch = 1;
							UI_Manager.GetComponent<UI_Manager>().FirstTouchThanDisappear();
							diskcontroller.TimeDecreasefunc();
							uicontrol = true;
						}
					}
					break;

				case TouchPhase.Stationary:
					rb.velocity = new Vector3(0, 0, 0);
					break;
				case TouchPhase.Ended:
					rb.velocity = new Vector3(0, 0, 0);					
					break;
            }


			//Ray ray = Camera.main.ScreenPointToRay(touch.position);
			//RaycastHit Hitinfo;

   //         if (Physics.Raycast(ray, out Hitinfo))
   //         {
   //             gameObject.transform.position = Vector3.MoveTowards(new Vector3(gameObject.transform.position.x, 0.55f, gameObject.transform.position.z), new Vector3(Hitinfo.point.x, 0.55f, Hitinfo.point.z + 2f), 35 * Time.deltaTime);
   //         }



        }

		//Hız kısıtlaması
		if (rb.velocity.magnitude > maxSpeed)
		{
			rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
		}
	}



}
