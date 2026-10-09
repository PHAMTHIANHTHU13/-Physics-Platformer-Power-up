using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{
    
    [SerializeField] ParticleSystem effectParticle; // tạo biến để kéo hiệu ứng particle vào trong object có gắn script này

    PlayerController playerController;

    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>(); // tìm kiếm object có gắn script PlayerController
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor"); // lấy giá trị số của layer
        if(collision.gameObject.layer == layerIndex) // giá trị layer  = layer floor của người chơi thì game over
        {
            playerController.canController = false; // tắt khả năng điều khiển nhân vật
            // GetComponent<ParticleSystem>().Play(); // phát hiệu ứng particle khi va chạm với đường
            effectParticle.Play(); // phát hiệu ứng particle khi va chạm với đường => cách 2: phải kéo hiệu ứng particale vào trong object có găn script thì sử dụng cách này:
            Invoke("LoadScene", 1f); // gọi hàm LoadScene sau 1 giây
        }
        
    }

    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
