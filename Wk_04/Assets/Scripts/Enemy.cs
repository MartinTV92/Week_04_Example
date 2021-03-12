using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public static int[] enemyHealths = new int[]
	{
		10,15,30,5
	};

	public EnemyType eType;
	public int health;


    void Start()
    {
        SetStartHealth();
    }

	void SetStartHealth()
	{
		/*
		if(eType == EnemyType.Defualt)
			health = 10;
		else if(eType == EnemyType.Light)
			health = 15;
		else if (eType == EnemyType.Heavy)
			health = 30;
		else if (eType == EnemyType.Ranged)
			health = 5;
	//	*/

	//	health = enemyHealths[(int)eType];

		switch(eType)
		{
			case EnemyType.Defualt:
				health = 10;
				break;
			case EnemyType.Light:
				health = 15;
				break;
		}

	}

    
}

public enum EnemyType
{
	Defualt,
	Light,
	Heavy,
	Ranged
}
