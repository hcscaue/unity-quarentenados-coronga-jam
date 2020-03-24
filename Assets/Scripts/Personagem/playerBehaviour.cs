﻿    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class playerBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    public Rigidbody2D my_Rb; public Animator my_anim;
    public string estadoMovimento;

    private void Awake() { 
    }

    private void FixedUpdate() {
    
        Movimentacao(speed);
        Animation();
       
        barsBerraviour.PerderBarra(0, 0.0001f * 4f);

        //0.0001f / 1.5f - ~5.0min 
        //0.0001f * 1.0f - ~3.15min
        //0.0001f * 2.0f - ~1.45min
        //0.0001f * 2.5f - ~1.15min

    }

    public static bool cima, baixo, esquerda, direita;
    void Animation() {
        if (Input.GetAxisRaw("Vertical") == 1) estadoMovimento = "Cima";
        else if (Input.GetAxisRaw("Vertical") == -1) estadoMovimento = "Baixo";
        else if (Input.GetAxisRaw("Horizontal") == 1 && Input.GetAxisRaw("Vertical") == 0) estadoMovimento = "Direita";
        else if (Input.GetAxisRaw("Horizontal") == -1 && Input.GetAxisRaw("Vertical") == 0) estadoMovimento = "Esquerda";

        if(my_Rb.velocity == Vector2.zero) {
            my_anim.SetBool("inMovement", false);
        } else my_anim.SetBool("inMovement", true   );

        my_anim.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        my_anim.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));

        if(estadoMovimento == "Cima") {
            cima = true; baixo = false; esquerda = false; direita = false;
        }
            else if (estadoMovimento == "Baixo") {
                cima = false; baixo = true; esquerda = false; direita = false;
            }
                else if (estadoMovimento == "Direita") {
                    cima = false; baixo = false; esquerda = false; direita = true;
                }
                    else if (estadoMovimento == "Esquerda") {
                        cima = false; baixo = false; esquerda = true; direita = false;
                    }

        my_anim.SetBool("Cima", cima);
        my_anim.SetBool("Baixo", baixo);
        my_anim.SetBool("Direita", direita);
        my_anim.SetBool("Esquerda", esquerda);
        my_anim.SetBool("Cima", cima);
    }

    void Movimentacao(float speed) {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        my_Rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}
