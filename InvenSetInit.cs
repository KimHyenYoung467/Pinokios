using System.Collections.Generic;
using Sprite.UGUI.UIscript.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Sprite.UGUI.UIscript
{ 
    public abstract class InvenSetInit
    {
        [SerializeField] private Animation _animation; 
        [SerializeField] private InventoryManager _inventoryManager; 

        private Inventory _inven; 
        private RectTransform _rect; // 인벤토리 상자  
        private List<GameObject> _objList = new List<GameObject>(); // 리스트 바로 초기화

        public RectTransform GetObjectInit() // rect 정보 반환
        {
            return _rect; 
        }
        
        public void SetObjectInit() // 오브젝트 생성
        {
            if (_rect == null)
            {
                Debug.LogWarning("RectTransform이 비어 있습니다.");
                return; 
            }

            var objectName = _rect.gameObject.name;
            Debug.Log($"오브젝트 이름: {objectName}");

            if (_rect.gameObject.CompareTag("Inventory") || 
                _rect.gameObject.CompareTag("Quest") || 
                _rect.gameObject.CompareTag("Config"))
            {
                if (!_objList.Contains(_rect.gameObject))
                {
                    _objList.Add(_rect.gameObject);
                    Debug.Log($"오브젝트 추가됨: {objectName}");
                }
            }
        }
        
        public Vector2 Scale(float width, float height) // 인벤토리 BG 상자 크기 조정
        {
            if (_rect == null) 
            {
                Debug.LogWarning("오브젝트가 비어 있습니다.");
                return Vector2.zero; // null 참조 방지
            }

            if (!_objList.Contains(_rect.gameObject)) // 리스트에 추가
            {
                _objList.Add(_rect.gameObject);
            }

            _rect.sizeDelta = new Vector2(width, height);
            return _rect.sizeDelta; 
        }
    }
}