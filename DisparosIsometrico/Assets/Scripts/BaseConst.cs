using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseConst : MonoBehaviour
{
	// Valores inciales
	public float velocidadBalaInicial;
	public int cantidadBalasInicial;

	// Valores actuales
	public static float velocidadBalaActual;
	public static int cantidadBalasActual;

	void Start()
	{ 
		velocidadBalaActual = velocidadBalaInicial;
		cantidadBalasActual = cantidadBalasInicial;
	}
}
