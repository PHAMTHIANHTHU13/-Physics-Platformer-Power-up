
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float TorqueAmount = 1f; // khởi tạo giá trị mô men xoắn = 1
    InputAction moveAction; // khởi tạo biến lấy giá trị từ Input System
    Rigidbody2D rb; // khởi tạo biến lấy giá trị vật lí cho nhân vật

    Vector2 moveVector;// khởi tạo biến lưu giá trị di chuyển của nhân vật

    [SerializeField] float BaseSpeed = 15f; // khởi tạo giá trị tốc độ cơ bản = 15

    [SerializeField] float BoostSpeed = 20f; // khởi tạo giá trị tốc độ tăng cường = 30 

    SurfaceEffector2D surfaceEffector2D; // khởi tạo biến lấy giá trị vật lí của bề mặt

    public bool canController = true; 

    // tính điểm số lần lật của người chơi
    float previousRotation; // lần lật trước đó

    float totalScore; // tổng số điểm

    // gọi phương thức addscore
    [SerializeField] ScoreText scoreText;

    // tạo particale cho powerup
    [SerializeField] ParticleSystem powerupParticle;

    int activeParticleCount = 0; // biến đếm số lượng particle đang hoạt động




    // Start is called before the first frame update
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move"); // tìm kiếm hành động "Move" trong Input System
        rb = GetComponent<Rigidbody2D>();// lấy giá trị vật lí của nhân vật
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>(); // tìm kiếm bề mặt vật lí trong scene
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canController) 
        {
            RoatePlayer(); // gọi hàm xoay nhân vật
            BoostPlayer(); // gọi hàm tăng tốc cho nhân vật
            CalculateFlipScore(); // gọi hàm tính điểm số lần lật

        }

    }

    void RoatePlayer()
    {

        moveVector = moveAction.ReadValue<Vector2>(); // đọc giá trị di chuyển của nhân vật từ Input System
        // print(moveVector); // tương tự như Debug.Log(moveVector);
        if (moveVector.x < 0) // nếu người chơi nhấn phím trái thì xoay mô men xoắn
        {
            rb.AddTorque(TorqueAmount);
        }
        else if (moveVector.x > 0)
        {
            rb.AddTorque(TorqueAmount);
        }
    }

    void BoostPlayer()
    {
        // if(moveVector.y > 0) // nếu người chơi nhấn phím lên thì tăng tốc
        // {
        //     surfaceEffector2D.speed = BoostSpeed; // tăng tốc độ bề mặt vật lí
        // }
        // else
        // {
        //     surfaceEffector2D.speed = BaseSpeed; // trở về tốc độ cơ bản
        // }

        if (moveVector.y > 0)
        {
            surfaceEffector2D.speed = BoostSpeed;

        }
        else
        {
            surfaceEffector2D.speed = BaseSpeed;
        }
    }
     
    // Điểm số lần xoay của nhân vật
    void CalculateFlipScore()
    {
        float currentRotation = transform.rotation.eulerAngles.z; // tính giá trị góc xoay hiện tại của nhân vật

        totalScore += Mathf.DeltaAngle(previousRotation, currentRotation); // tính tổng số điểm số lần lật của nhân vật

        if(totalScore > 360 || totalScore < -360)
        {
    
            totalScore = 0; // Reset the score after a full rotation
            scoreText.AddSCore(100); // gọi phương thức AddScore bên file scoreText.cs để cộng thêm 100 điểm cho người chơi khi lật được 1 vòng
        }

        previousRotation = currentRotation; // số lần lật trước đó = số lần lật hiện tại

        
    }
    public void disableControls() 
    {
        canController = false; // tắt điều khiển nhân vật
    }

    public void ActivatePowerup(PowerupData powerup) // phương thức kích hoạt powerup
    {
        powerupParticle.Play(); // phát particle khi nhân vật nhận powerup
        activeParticleCount +=1; // tăng số lượng particle đang hoạt động lên 1
        if(powerup.GetPowerupType() == "Speed")
        {
            // Activate the powerup logic here
            BaseSpeed += powerup.GetvalueChange(); 
            BoostSpeed += powerup.GetvalueChange(); 

        }
        else if (powerup.GetPowerupType() == "Torque")
        {
            TorqueAmount += powerup.GetvalueChange();
            
        }
    }

    public void DeacativePowerup(PowerupData powerup) // nếu hết giờ thì gọi phương thức này để tắt powerup
    {
        activeParticleCount -=1; // giảm số lượng particle đang hoạt động xuống 1
        if(activeParticleCount <= 0) // nếu không còn particle nào đang hoạt động thì
        {
            powerupParticle.Stop(); // dừng particle khi hết powerup
        }
        if (powerup.GetPowerupType() == "Speed")
        {
            // Deactivate the powerup logic here
            BaseSpeed -= powerup.GetvalueChange(); 
            BoostSpeed -= powerup.GetvalueChange(); 

        }
        else if (powerup.GetPowerupType() == "Torque")
        {
            TorqueAmount -= powerup.GetvalueChange();
        }
    }
}
