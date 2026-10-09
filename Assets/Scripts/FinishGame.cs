using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    [SerializeField] float delaySceneLoad = 1f;
    //cách phát partical 2:
    [SerializeField] ParticleSystem effectParticle; // tạo biến để kéo hiệu ứng particle vào trong object có gắn script này
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player"); //
        if(collision.gameObject.layer == layerIndex) // nếu cái layer của vật thể va chạm trùng với layer của Player thì in ra thông báo "Finish Game"
        {
            // GetComponent<ParticleSystem>().Play(); // phát hiệu ứng particle khi va chạm => cách 1: phải kéo
            // hiệu ứng particale vào trong object có găn script thì sử dụng cách này:
            effectParticle.Play(); // phát hiệu ứng particle khi va chạm => cách 2: phải kéo hiệu ứng particale vào trong object có găn script thì sử dụng cách này:
            Invoke("LoadScene", delaySceneLoad);
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
