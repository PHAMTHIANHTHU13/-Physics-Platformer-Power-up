using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ManagerPowerup : MonoBehaviour
{
    [SerializeField] PowerupData powerup;

    PlayerController player;

    // ẩn powerup khi player chạm vào

    SpriteRenderer spriteRenderer;

    // thời gian hiển thị powerup
    float timeLeft;

    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timeLeft = powerup.GetTime(); // lấy thời gian hiển thị powerup từ PowerupData
    }

    void Update()
    {
        CoudownTimePowerup();
    }

    void CoudownTimePowerup()
    {
        if (spriteRenderer.enabled == false) // nếu powerup ko hiển thị trên UI thì đếm ngược thời gian
        {
            if (timeLeft >0)
            {
                timeLeft -= Time.deltaTime;
                
                if(timeLeft <= 0)
                {
                    player.DeacativePowerup(powerup); // gọi phương thức tắt powerup của player
                    
                }
            }

        }
    }

    void OnTriggerEnter2D(Collider2D conllision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if (conllision.gameObject.layer == layerIndex && spriteRenderer.enabled == true) // && spriteRenderer.enabled == true này để kiểm tra xem powerup có đang hiển thị hay không, nếu đang hiển thị thì mới thực hiện logic kích hoạt powerup
        {
            // ẩn powerup khi player chạm vào
            spriteRenderer.enabled = false;
            // Handle powerup activation logic here
            player.ActivatePowerup(powerup);
            
        }
    }
}
