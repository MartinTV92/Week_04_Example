using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelect_Basic : MonoBehaviour
{
    
	public GameObject[] weapons = new GameObject[4];
	public int currentWeapon;
	void Start()
    {
        
    }

  
    void Update()
    {
        GetInputs();
	}

	void GetInputs()
	{
		for (int i = 0; i < 9; i++)
		{
			if (Input.GetKeyDown((i + 1).ToString()))
				SwitchWeapon(i);
		}
	}

	void SwitchWeapon(int target)
	{
		for(int i = 0; i < weapons.Length; i++)
			weapons[i].gameObject.SetActive(false);

		weapons[target].SetActive(true);
		currentWeapon = target;
	}
}
