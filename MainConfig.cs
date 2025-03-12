using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Sprite.UGUI.UIscript
{
  public class MainConfig : MonoBehaviour
  {
    //Todo 메인 설정창의 선택바를 inventory 내에 있는 선택바 이동 함수를 사용할 수 없나? 
    //Todo X버튼 선택시 Config 창을 삭제 하기 
    //Todo 설정창의 변경 목록 선택 시 변경 창의 내용 변경 =>  그래픽 프리팹과 사운드 프리팹 등을 변환 할 수 있는 방법 
    //Todo 사운드 바 슬라이더 , 실제 해상도 변경 => mainsoundSlider , voiceSoundSlider, BackSoundSlider /// DropDown x 3 /// Button 1
    [FormerlySerializedAs("_inventory")]
    [Header("script")] 
    [SerializeField] private Inventory inventory;
    [SerializeField] private Animator animator;

    [FormerlySerializedAs("ConfigObj")]
    [Header("Object")] 
    [SerializeField] private GameObject configObj;      // 설정창 메인 오브젝트 
    [SerializeField] private GameObject selectbar;      // 설정 선택바 
    [SerializeField] private Slider mainSlider;         // 전체 음량 
    [SerializeField] private Slider subSlider;          // 더빙 음량과 배경 음악. 전체 음량의 자식들로 설정 되어 있음.  
    [SerializeField] private Dropdown viewPortDd;       // 해상도 
    [SerializeField] private Dropdown cussor;           // 마우스 커서 모양
    [SerializeField] private Button closeBtn;           // 삭제 버튼 

    [SerializeField] private TMP_Text soundValue;       // 사운드 값 text  변경용 

    private bool _isClick = true; 
    //Todo 전체 음량 => 전체 음량의 슬라이더 조절 시 더빙, 배경 의 슬라이더 동시 조절 
    //Todo 음량 조절 시 보이스, 더빙 사운드 조절할 수 있는 사운드 매니저 클래스 제작 필요 

    void Start() // 나중에 셋인으로 모으기 
    {
        mainSlider = mainSlider.GetComponent<Slider>();
        subSlider = mainSlider.GetComponentInChildren<Slider>();
        viewPortDd = viewPortDd.GetComponent<Dropdown>();
        cussor = cussor.GetComponent<Dropdown>();
        closeBtn = closeBtn.GetComponent<Button>();
        
    }
    //Todo (First) x 버튼 누를 시 메인 설정 창 없애기 
    //Todo (Second) 선택바가 마우스 포지션 위치로 이동할 때 선택바의 색깔 약간 밝게 만들기 
    //Todo (Third) 인벤토리 cs 내부에 있는 선택바 이동 함수를 사용할 수는 없을까? 
    //Todo (Four) 슬라이더 조절 함수 
    
    //Todo 더빙, 배경의 현재 위치를 저장해서 전체 음량의 슬라이더 조절 시 함꼐 움직이도록 한다. 
    //Todo 해상도 변경 DropDown의 목록을 마우스로 클릭 시에 해상도를 변경 한다. => 해상도 변경 방법 탐색 필요. 
    //Todo 마우스 커서 모양 => 목록은 아직 부족하나, 목록의 스프라이트로 마우스 커서의 모양을 변경 필요
    
     //Todo 마우스 커서 모양은 목록 안에 있는 목록을 선택할 때 텍스트에 맞는 이미지가 마우스 커서의 모양이 되어야 한다. 
     //Todo 목록의 아이디, 내용을 받아야 할까? 

     private void MoveSelectbar()
     {
         if (selectbar.transform.position != Input.mousePosition || !selectbar.CompareTag("Config")) return;
         
         _isClick = true; 
         selectbar.transform.position = Input.mousePosition; //선택바의 위치를 마우스의 위치로 이동 
     }
     
     private void DeleteConfig(GameObject conObj)       // x 버튼 클릭 시 삭제 
     {
         if (!Input.GetMouseButtonDown(0) || !closeBtn.gameObject) return;
         
         Destroy(conObj);
         Debug.Log("설정 창 삭제");
     }

     private void SliderBar()
     {
         if (mainSlider == null) return; 
         
         mainSlider.minValue = 0; 
         mainSlider.maxValue = 1;
         
         if (!(mainSlider.value <= mainSlider.minValue) || !(mainSlider.value >= mainSlider.maxValue)) return;
         
         var SoundValue = mainSlider.value.ToString();
         soundValue.text = SoundValue;
         //Todo 사운드 매니저 제작 필요 
     }

    
  }
}
