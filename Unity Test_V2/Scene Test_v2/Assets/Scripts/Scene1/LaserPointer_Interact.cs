using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;



public class LaserPointer_Interact : MonoBehaviour {

	public Material m0;
	public Material m1;
	public Material m2;
	public Material m3;
	public Material m4;
	public Material m5;
	public Material m6;
    public Material m7;
    public Material m8;
    public Material m9;

    //get screen position on shell
    public GameObject eye;
    private Vector3 hitPoint2;

	private Renderer rend;
	
    //show laser beam when raycasting
	public GameObject laserPrefab;
	private GameObject laser;
	private Transform laserTransform;

    //object hit by raycast
	private Vector3 hitPoint; 

	public GameObject screen;

    //controller vibration when player hits selectin
    private SelectinDrag selectinDragScript;
    public GameObject player;
    
    //vive controller tracking and input
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device Controller
	{
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}



	void Awake()
	{
		
		trackedObj = GetComponent<SteamVR_TrackedObject>();
		rend = screen.GetComponent<Renderer>();
        
        screen.SetActive(false);

        selectinDragScript = player.GetComponent<SelectinDrag>();
	}




	void Start () {

		laser = Instantiate(laserPrefab);
		laserTransform = laser.transform;

		rend.material = m0;
                
	}
	


	void Update () {

		if (Controller.GetHairTrigger())
		{
//            if(Controller.index == SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost))
//            {
                
                RaycastHit hit;
                
                if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 1000))
                {
                    //Debug.DrawRay(trackedObj.transform.position, transform.forward * 500, Color.red);
                    
                    hitPoint = hit.point;
                    ShowLaser(hit);

                    int layerMask = 1 << 9;
                    RaycastHit hitInfo;
                    if (Physics.Linecast(hitPoint, eye.transform.position, out hitInfo, layerMask))
                    {

                        if (hitInfo.collider.tag == "Shell")
                        {
                            hitPoint2 = hitInfo.point;
                            screen.transform.position = new Vector3(hitPoint2.x - 0.5f, hitPoint2.y, hitPoint2.z);
                            //Debug.Log("shell");
                        }
                    }

                
                    if (hit.collider.tag == "Cytotoxic T Cell")
                    {
                        screen.SetActive(true);
                        rend.material = m1;
                    }
                    


                    if (hit.collider.tag == "Helper T Cell")
                    {
                        screen.SetActive(true);
                        rend.material = m2;
                    }
                    


                    if (hit.collider.tag == "Macrophage")
                    {
                        //if(Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
                        screen.SetActive(true);
                        rend.material = m3;

                    
                    }
                    


                    if (hit.collider.tag == "Neutrophil")
                    {
                        screen.SetActive(true);
                        rend.material = m4;
                    }
                    


                    if (hit.collider.tag == "Plasma B Cell")
                    {
                        screen.SetActive(true);
                        rend.material = m5;
                    }
                    


                    if (hit.collider.tag == "Dendritic Cell")
                    {
                        screen.SetActive(true);
                        rend.material = m6;
                     }
                    


                    if (hit.collider.tag == "Selectin")
                    {
                        screen.SetActive(true);
                        rend.material = m7;
                    }

                    if (hit.collider.tag == "Red Blood Cell")
                    {
                        screen.SetActive(true);
                        rend.material = m8;
                    }

                    if (hit.collider.tag == "Platelet")
                    {
                        screen.SetActive(true);
                        rend.material = m9;
                    }
                }

//            }
			
		}
		else 
		{
            laser.SetActive(false);
            screen.SetActive(false);
		}

        
        //vibration when hit by a selectin
        if (selectinDragScript.vibrate)
        {
            Controller.TriggerHapticPulse(500);
        }

    }



    private void ShowLaser(RaycastHit hit)
	{
		laser.SetActive(true);
		laserTransform.position = Vector3.Lerp(trackedObj.transform.position, hitPoint, .5f);
		laserTransform.LookAt(hitPoint); 
		laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y, hit.distance);
	}

}
