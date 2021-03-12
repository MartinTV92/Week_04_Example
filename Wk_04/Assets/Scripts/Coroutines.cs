using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutines : MonoBehaviour
{
	int moveDistance = 500;
	public EnemyType eType;
	private void Start()
	{
		StartCoroutine(Move());
	}

	void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
			StartCoroutine(Move());
    }

    // Update is called once per frame
    IEnumerator Move()
	{
		for(int i = 0; i < moveDistance; i++)
		{
			transform.Translate(Vector3.forward * Time.deltaTime);
			yield return null;
		}

		yield return new WaitForSeconds(3);

		for (int i = 0; i < moveDistance; i++)
		{
			transform.Translate(Vector3.back * Time.deltaTime);
			yield return null;
		}
	}
}



