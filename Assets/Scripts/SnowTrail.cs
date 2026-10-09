using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowTrailParticle; // tạo biến để kéo hiệu ứng particle vào trong object có gắn script này
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor"); 
        if(collision.gameObject.layer == layerIndex)
        {
            snowTrailParticle.Play(); // phát hiệu ứng particle khi va chạm với đường => cách 2: phải kéo hiệu ứng particale vào trong object có găn script thì sử dụng cách này:
        }
    
        
    }


    void OnCollisionExit2D(Collision2D collision) // khi người chơi không chạm floor nữa thì dừng partical
    {
        int layerIndex = LayerMask.NameToLayer("Floor"); 
        if(collision.gameObject.layer == layerIndex)
        {
            snowTrailParticle.Stop(); // dừng hiệu ứng particle khi rời khỏi đường => cách 2: phải kéo hiệu ứng particale vào trong object có găn script thì sử dụng cách này:
        }
     
    }
}
