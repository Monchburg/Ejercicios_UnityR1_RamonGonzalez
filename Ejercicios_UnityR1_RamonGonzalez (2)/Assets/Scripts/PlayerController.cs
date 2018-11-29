using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody2D player;
	Animator anim;

	public float xDirection;
	public int velocidadMovimiento;
	public float velocidadMaxima;

	public bool controlFlechas;
	public bool controlRaton;
	public bool controlSeguimientoRaton;

	void Start () {
		player = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	void Update (){
		
	}

	void FixedUpdate (){
		if (controlFlechas){
			xDirection = Input.GetAxis("Horizontal");
			Mover();
		}
		if (controlRaton){
			MoverRaton();
		}
		if (controlSeguimientoRaton){
			if (Input.GetMouseButton(0)){
				SigueRaton();
			}
		}
	}

	void Mover(){
		float xVelocity = xDirection * velocidadMaxima;
		float yVelocity = player.velocity.y;
		Vector2 velocity = new Vector2 (xVelocity, yVelocity);
		player.velocity = velocity;
	}
	void MoverRaton (){
		//Unity nos da este valor en coordenadas de la pantalla, por ello hay que utilizar otra función
		//Camera.main.ScreenToWorld hace que las coordenadas del ratón sean las coordenadas de la cámara principal, que está
		//dentro del juego. 
		Vector2 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 new_player_position = new Vector2 (mouse_position.x,transform.position.y);
		transform.position = new_player_position;
	}
	void SigueRaton(){
		Vector2 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = Vector2.MoveTowards(transform.position, mouse_position, velocidadMovimiento * Time.deltaTime);
	}	
}
