using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Debug = System.Diagnostics.Debug;
using Image = UnityEngine.UIElements.Image;

//Todo 아이템을 만들어서, 아이템을 정해진 ItemTable에 저장.


namespace Sprite.UGUI.UIscript.Item
{
    
    public class ItemUnitInfo
    {
        private TMP_Text _text;
        [SerializeField] private Image _itemImg; 
        
        public ItemUnitInfo(int id, string name, string text, Image itemImage)
        {
            Id = id;  // 아이템 아이디 
            Name = name; // 아이템 이름
            ItemImage = itemImage;
            Text = text; 
        }

        public int Id { get; }
        public string Name { get; }
        public string Text
        {
            get => _text.text;
            set => _text.text = value;
        }

        public Image ItemImage
        {
            get => _itemImg;  
            set => ItemImage.sprite = value.sprite;
        }
    }
    public class ItemUnit : MonoBehaviour
    {
            [Header("ItemSetting")]
            [SerializeField] private Inventory inven; 
            [SerializeField] private TMP_Text text;
            [SerializeField] private GameObject itemPrefab; // 아이템 
            [SerializeField] private GameObject invenTable;
            [SerializeField] private Button deleteBtn; // 삭제 버튼
            
            private bool isClick; 
    
            [Header("ObjList")]
            private readonly List<ItemUnitInfo> _itemlist = new List<ItemUnitInfo>();

            void Start()
            {
                deleteBtn = gameObject.AddComponent<Button>();
                
              /*  foreach (var item in _itemList.Select(unit => Instantiate(itemPrefab, invenTable.transform))
                             .Select(itemUnit => itemUnit.GetComponent<ItemUnitInfo>()).ToList())
                {
                    _itemList.Add(item);
                }*/
            }
                //Todo 아이템 삭제 함수 만들기 
             public void AddItem(int id, string itemname, string description, Image itemImg)
            {
                //Todo 아이템의 정보를 받아서 리스트에 추가 한다.  
                //Todo 아이템 아이디, 이름, 설명 을 받아서, 리스트에 한다. 
                
                _itemlist.Add(new ItemUnitInfo(id, itemname , description, itemImg));
            } 

            void RemoveItem(ItemUnitInfo item)
            {
                //Todo 삭제 버튼을 눌렀을 때 선택되어 있는 아이템을 삭제한다. 
                //Todo 삭제 버튼이 눌렸는 지 검사. 
                //Todo 삭제 버튼 눌렸을 때 삭제 , 눌리지 않으면 이어서 진행
                if (deleteBtn != null) return;
                deleteBtn = deleteBtn.gameObject.GetComponent<Button>();
                if (!Input.GetMouseButtonDown(0))
                {
                    isClick = false;
                    return; 
                }

                if (!Input.GetMouseButtonDown(0) || !gameObject.CompareTag(itemPrefab.gameObject.name)) return;
                
                isClick = true;
                _itemlist.Remove(item);
            }

    }
}
