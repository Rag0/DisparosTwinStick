using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad;
    public GameObject bullet;
	public GameObject bulletDoble;
    private Rigidbody2D rb2d;

	public float nextFire;
	public static float fireRate;

    public static float disparoActual;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        disparoActual = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");

        /*if (movHorizontal > 0)
        {
            disparoActual = 1;
        }

        else if (movHorizontal < 0)
        {
            disparoActual = 2;
        }

        if (movVertical > 0)
        {
            disparoActual = 3;
        }

        else if (movVertical < 0)
        {
            disparoActual = 4;
        }*/

        Vector2 movimiento = new Vector2(movHorizontal, movVertical);

        rb2d.AddForce(movimiento * velocidad);
    }

    void Update()
    {
        if (!GameController.gameOver)
        {
			Quaternion rotacionBala = Quaternion.identity;

			if (Input.GetButton("Fire1") && Time.time > nextFire) // Abajo
            {
				rotacionBala = Quaternion.Euler(new Vector3(0, 0, -90));
				SetDisparoYNextFire (4);
            }

			else if (Input.GetButton("Fire2") && Time.time > nextFire) // Derecha
			{
				SetDisparoYNextFire (1);
			}

			else if (Input.GetButton("Fire3") && Time.time > nextFire) // Izquierda
			{
				SetDisparoYNextFire (2);
			}

			else if (Input.GetButton("Jump") && Time.time > nextFire) // Arriba
			{
				rotacionBala = Quaternion.Euler(new Vector3(0, 0, 90));
				SetDisparoYNextFire (3);
			}

			if (disparoActual > 0) 
			{
				switch (BaseConst.cantidadBalasActual)
				{
					case 1:
						Instantiate (bullet, transform.position, Quaternion.identity);

						break;

					case 2:
						Instantiate (bulletDoble, transform.position,  rotacionBala);

						break;

					default:
						Debug.Log ("NO HAY BALAS!");

						break;
				}

			}
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemigo1")
        {
            Destroy(gameObject);
            GameController.gameOver = true;
        }
    }

	private void SetDisparoYNextFire(float disparoActu)
	{
		nextFire = Time.time + fireRate;
		disparoActual = disparoActu;
	}
}
