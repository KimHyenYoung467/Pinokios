using System.Security.Cryptography.X509Certificates;
using Sprite.UGUI.UIscript.Item;
using Sprite.UGUI.UIscript.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;


// Todo (Clear) SelectBar 를 받아와서, SelectBar 의 현재 위치에서 마우스 포인터의 위치로 이동하여, (Clear) 

// Todo 클릭 시에 ImgBG(부분 Clear) 및 ItemStatus 에 설명창 띄우기 

// Todo Item의 Text 오브젝트 내의 내용을 아이템 아이디에 맞춰서 변경하고, 이미지 또한 변경이 필요하다.


//Todo Item의 셀렉트 바의 위치에 따라 선택된 설명 창의 이미지를 변경 하고, 설명 창의 설명 란 내용을 변경.

namespace Sprite.UGUI.UIscript
{
    public class Inventory : MonoBehaviour
    {
        [Header("Script")] 
        private InventoryManager _inventoryManager;
        private Animation _animation;
        [SerializeField] private ItemUnitInfo _itemUnit;
        [SerializeField] private InvenSetInit _setinven;
        
        [Header("Object")] 
        private RectTransform _rect;
        [SerializeField] private RectTransform selectBar; // SelectBar 오브젝트 
        private GameObject _itemTable; // 아이템 테이블 오브젝트 
        private GameObject _itemStatus; // 아이템 스테이터스 오브젝트 
        private TMP_Text _iStatusText; // Text_MeshPro 텍스트 상자 내용
        
        [Header("Sprite")]
        [SerializeField] private Image _itemthisImg;  // 아이템 이미지 변경용 
        
        void Start() // 초기화
        {
            _rect = _rect.gameObject.GetComponent<RectTransform>();
            selectBar = selectBar.gameObject.GetComponent<RectTransform>(); 
            _iStatusText = _iStatusText.GetComponent<TMP_Text>();
            _itemUnit = GetComponent<ItemUnitInfo>();
            ItemUnitInfo itemUnitInfo;
            
        }

        private string ItemDscription(string itemDescription)
        {
            _iStatusText.text = itemDescription;
            if (_rect.gameObject.CompareTag("Inventory"))
                _iStatusText.text = itemDescription;
            return _iStatusText.text;
        }

        //Todo 클릭 위치에 따라서 인벤토리 테이블을 선택하는 SelectBar 이동 
        public  Vector3 MoveSelectBar(RectTransform _selectBar, GameObject selectObj)
        {
            // 현재 선택바 가 어디에 위치해 있는 지 확인.
            // 클릭 시 선택바의 위치를 클릭한 위치로 이동. 
            // 필요 변수 : 선택바의 현재 위치를 담을 변수, 클릭한 위치를 담을 변수.

            //_selectBar.transform.SetParent(_itemTable.transform);

            var selPos = _selectBar.transform.position; // 선택바의 현재 위치 저장 
            selPos.z = 0f;
        
            if (Input.GetMouseButtonDown(0) && selectObj.GetComponentInChildren<GameObject>())
            {
                _selectBar.transform.position = Input.mousePosition; // 선태바의 위치를 마우스 포인터로 선택한 아이템 테이블 위치로 이동. 
                selPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, selPos.z);
            }

            if (_selectBar.transform.position != Input.mousePosition) return _selectBar.position; //Todo 현재 셀렉트 바의 위치 전달 
        
            //선택바와 마우스 포인터로 클릭한 위치가 같을 때, 선택시 선택바의 크기 줄였다가 크게 하는 선택 표현 하기 
            _selectBar.localScale -= Vector3.one; 
            _selectBar.localScale += Vector3.one;
            
            return _selectBar.position; 
        }
        
        //Todo 선택바가 선택한 위치에 있는 아이템의 이미지를 아이템 status 이미지 부분에 출력 
        //Todo 선택바가 현재 위치에서 이동할 시, 이동된 위치에 있는 아이템이 비어있으면 냅두고,
        //Todo 아이템이 있을 때 변경된 위치에 있는 아이템의 이미지로 변경.
      
        private void Imgprint(Image itemChangeImg, GameObject selectObj, ItemUnitInfo itemUnit)
        {
            MoveSelectBar(selectBar, selectObj);
            
            var thisImg = _itemthisImg;
                thisImg.sprite = _itemUnit.ItemImage.sprite;
            
            //Todo 선택바 위치가 현재 아이템이 있는 테이블 위치에 동일 할 때  
            // 그리고, 선택바의 위치가 바뀌면서 아이템의 아이디가 변경된 게 확인 되었을 때,
            // 현재 아이템의 아이디와 바뀐 아이템의 아이디를 변경 되었을 시, 이미지를 바꾼다.
            
            //Todo 아이템 아이디를 따로 받을 방법이 없나? 
            if (selectBar.transform.position.Equals(Input.mousePosition)) 
            {
                thisImg.sprite = _itemUnit.ItemImage.sprite;
                Debug.Log($"{thisImg}"); // 현재 이미지 출력 
            }
            else if (!selectBar.gameObject.transform.position.Equals(Input.mousePosition) || !itemUnit.Id.Equals(itemUnit.Id));
            {
                 // Todo 아이템의 아이디가 동일하지 않을 때, 아이템의 아이디에 따른 이미지로 변경
                 thisImg.sprite = itemChangeImg.sprite;
                 Debug.Log("현재 이미지 변경 ");
            }
        }
        
    }
} 


