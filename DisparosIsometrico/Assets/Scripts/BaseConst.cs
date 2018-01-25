using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseConst : MonoBehaviour
{
	// Valores inciales
	public float velocidadBalaInicial;
	public int cantidadBalasInicial;
	public int tipoBulletInicial;
	public int scoreNecesarioInicial;

	// Valores actuales
	public static float velocidadBalaActual;
	public static int cantidadBalasActual;
	public static int tipoBulletActual;
	public static int scoreNecesarioActual;
	public static bool activarBoss;

	void Start()
	{ 
		activarBoss = false;
		scoreNecesarioActual = scoreNecesarioInicial;
		velocidadBalaActual = velocidadBalaInicial;
		cantidadBalasActual = cantidadBalasInicial;
		tipoBulletActual = tipoBulletInicial;
	}
}
