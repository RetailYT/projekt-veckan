using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerMovement : MonoBehaviour
{

    public float MoveSpeed = 5f;
    public Rigidbody2D Rigidbody;
    public bool running = false;

    public Image StaminaBar;

    public float Stamina, MaxStamina;

    public float AttackCost;
    public float RunCost;
    public float ChargeRate;

    private Coroutine recharge;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();



    }


    void Update()
    {


        Vector2 direction = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction.Normalize();

        if (Input.GetKeyDown(KeyCode.X))
        {
            running = true;
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            running = false;
        }

        if (running && (direction.x != 0 || direction.y != 0))
        {

            Rigidbody.linearVelocity = 1.5f * MoveSpeed * direction;

            Stamina -= RunCost * Time.deltaTime;
            if (Stamina < 0) Stamina = 0;
            StaminaBar.fillAmount = Stamina / MaxStamina;

            if (Stamina < 0) running = false;

            if (recharge != null) StopCoroutine(recharge);
            recharge = StartCoroutine(RechargeStamina());

        }
        else
        {

            Rigidbody.linearVelocity = direction * MoveSpeed;
        }


        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Attack!");

            Stamina -= AttackCost;
            if (Stamina < 0) Stamina = 0;
            StaminaBar.fillAmount = Stamina / MaxStamina;

            if (recharge != null) StopCoroutine(recharge);
            recharge = StartCoroutine(RechargeStamina());
        }

    }

    private IEnumerator RechargeStamina()
    {
        yield return new WaitForSeconds(1f);

        while (Stamina < MaxStamina)
        {
            Stamina += ChargeRate / 10f;
            if (Stamina > MaxStamina) Stamina = MaxStamina;
            StaminaBar.fillAmount = Stamina / MaxStamina;
            yield return new WaitForSeconds(.1f);
        }

    }

}