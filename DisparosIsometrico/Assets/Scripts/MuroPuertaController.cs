using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuroPuertaController : MonoBehaviour
{
	public int tipoMuro; // 1 = Izquierda, 2 = Derecha
	public float velocidadMovMuro;
	public float tamanoBloque;

	private float posFinalMov;

	private bool puedeMoverse;

	// Use this for initialization
	void Start () 
	{
		if (tipoMuro == 1)
		{
			posFinalMov = transform.position.x - tamanoBloque;
		}

		else if (tipoMuro == 2)
		{
			posFinalMov = transform.position.x + tamanoBloque;
		}

		puedeMoverse = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (!GameController.gameOver)
		{
			if (GameController.score >= BaseConst.scoreNecesarioActual)
			{
				BaseConst.activarBoss = true;
				puedeMoverse = true;
			}

			if (gameObject != null && puedeMoverse == true)
			{
				float posActualX = transform.position.x;

				if (tipoMuro == 1)
				{
					if (posActualX <= posFinalMov)
					{
						Destroy (gameObject);
						puedeMoverse = false;
					}

					posActualX = posActualX - velocidadMovMuro;
				}

				else if (tipoMuro == 2)
				{
					if (posActualX >= posFinalMov)
					{
						Destroy (gameObject);
						puedeMoverse = false;
					}

					posActualX = posActualX + velocidadMovMuro;
				}

				transform.position = new Vector3(posActualX, transform.position.y, transform.position.z);
			}
		}
	}
}
