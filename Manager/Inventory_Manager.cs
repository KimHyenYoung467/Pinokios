using UnityEngine;

namespace Sprite.UGUI.UIscript.Manager
{
    public class InventoryManager : MonoBehaviour
    {
        
        [Header("Script")]
        [SerializeField] private InvenSetInit _setInven;
        [SerializeField] private Animation _animation; 
       
        [SerializeField] private GameObject setItemPrefab; // 아이템 프리팹 적용 

        [Header("Inventory")]
        [SerializeField] private RectTransform rect; // rectTransform의 오브젝트 가져오기 변화를 줄 오브젝트 (크기 변경, 색깔 변경 등등)  
        public RectTransform invenBGbox; // 인벤토리 BG 상자 끌어오기
        public GameObject invenTable; // 인벤토리 ItemTable 끌어오기 
        public GameObject invenTableChild; // 인벤토리 InvenTable 자식들 
        public GameObject selectBar; // 아이템 선택 바 

        [Header("Item")]
        public RectTransform itemImgBack;  // 아이템 이미지 백그라운드 
        public GameObject itemStatus; // 아이템 스테이터스 설명창 

        void Start()
        {
            rect = gameObject.GetComponent<RectTransform>(); 
            _animation = gameObject.GetComponent<Animation>();
            _setInven = gameObject.GetComponent<InvenSetInit>(); 
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
