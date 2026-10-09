using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacterManager : MonoBehaviour
{
    [SerializeField] GameObject scoreCanvas; // gọi giao diện điểm của trò chơi

    [SerializeField] GameObject DinoCharacter;

    [ SerializeField] GameObject FrogCharacter;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0; // dừng thời gian chọn nhân vật trong trò chơi
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    // phương thức kích hoạt giao diện điểm và trò  chơi

    public void BeginGame()
    {
        Time.timeScale = 1; // thời gian bắt đầu game
        scoreCanvas.SetActive(true); // sau thời gian bắt đầu trò chơi thì bật giao diện điểm
        gameObject.SetActive(false); //GameObject đang gắn script SelectCharacterManager này
    }

    // method choose character Dino

    public void ChooseDino()
    {
        DinoCharacter.SetActive(true); // nếu người chơi chọn Dino thì gọi phương thức bắt đầu trò chơi
        BeginGame();
    }

    public void ChooseFrog()
    {
        FrogCharacter.SetActive(true);
        BeginGame();
    }
}
