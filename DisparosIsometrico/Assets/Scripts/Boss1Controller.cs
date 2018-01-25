using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1Controller : MonoBehaviour
{
	public GameObject muroBarrera;

	public Image barraVida;
	public static bool estaDanado = false;

	public GameObject player;
	public float velocidad;
	public GameObject bulletEnemigo1;

	private Rigidbody2D rb2d;
	private float movHorizontal;
	private float movVertical;

	public static float vidaInicialBoss1 = 100;
	public static float vidaActualBoss1;

	public float fireDelta = 0.5F;
	public float siguienteDisparo;
	private float myTime = 0.0F;

	public int maximoBalas;

	private bool movimientoLibre;

	public static int puntaje = 100;

	// Use this for initialization
	void Start ()
	{
		vidaActualBoss1 = vidaInicialBoss1;

		movimientoLibre = false;

		movHorizontal = 0f;
		movVertical = -1f;

		rb2d = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (!GameController.gameOver)
		{
			if (movimientoLibre)
			{
				if (player.transform.position.x < transform.position.x)
				{
					movHorizontal = -1f;
				}

				else if (player.transform.position.x > transform.position.x)
				{
					movHorizontal = 1f;

				}

				if (player.transform.position.y < transform.position.y)
				{
					movVertical = -1f;
				}

				else if (player.transform.position.y > transform.position.y)
				{
					movVertical = 1f;
				}

				// instanciar balas
				myTime = myTime + Time.deltaTime;

				if (myTime > siguienteDisparo)
				{
					siguienteDisparo = myTime + fireDelta;

					instanciarBalaEnemigo1();

					siguienteDisparo = siguienteDisparo - myTime;
					myTime = 0.0F;
				}
			}

			Vector2 movimiento = new Vector2(movHorizontal, movVertical);

			rb2d.AddForce(movimiento * velocidad);

			if (estaDanado)
			{
				vidaActualBoss1 -= BulletController.danhoBulletPlayer;

				barraVida.fillAmount = vidaActualBoss1 / vidaInicialBoss1;

				GameController.score = GameController.score + puntaje;

				if (vidaActualBoss1 <= 0)
				{
					// Efecto antes de morir
					//Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);

					// Destruir boss
					Destroy(gameObject);

					// Abrir Muro barrera
					Destroy(muroBarrera);
				}

				estaDanado = false;
			}
		}
	}

	void Update()
	{
		if (!GameController.gameOver && movimientoLibre == true)
		{
			
		}
	}

	void instanciarBalaEnemigo1()
	{
		for (int i = 0; i < maximoBalas; i++)
		{
			BulletBoss1Controller.movInicialBalaEnem = i + 1;
			Instantiate(bulletEnemigo1, transform.position, transform.rotation);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "MuroChoque")
		{
			Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "MuroMedio") 
		{
			movimientoLibre = true;

			Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>());
		}
	}
}
