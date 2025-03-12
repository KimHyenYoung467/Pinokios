using System.Linq;
using UnityEngine;

//Todo 애니메이션 완성
//Todo 어떤 오브젝트인지 확인할 수 있는 메서드 작성

//Todo 클릭 횟수에 따라서 어떤 애니메이션을 동작 시킬 것인가. 
//Todo 클릭 횟수가 몇번인지 계산하는 메서드 작성 

//Todo 어떤 오브젝트 태그를 가지고 있는 지 검사 하고, 애니메이션 Play 메서드 작성 

namespace Sprite.UGUI.UIscript
{
    public abstract class Animation
    {
        private static readonly int ClickCount = Animator.StringToHash("ClickCount");
        private static readonly int TriggerClick = Animator.StringToHash("triggerClick");
        
        private ClickInputHandle _inputHandle;
        private GameObject _rect;
        private Animator _animator;

        private void Awake()
        {
            if (_rect != null)
            {
                _animator = _rect.GetComponent<Animator>();
            }
        }

        public void Initialize(GameObject target)
        {
            if (target == null) return;

            _rect = target;
            _animator = _rect.GetComponent<Animator>();
            _animator.SetTrigger(ClickCount + TriggerClick);
        }

        public void DetectClick()
        {
            if (_rect == null || _animator == null) return;

            if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                _animator.SetTrigger(ClickCount + 1); 
                _animator.SetTrigger(TriggerClick);

                Debug.Log($"클릭 횟수: {ClickCount}");
            }
        }

        public void ResetClick()
        {
            _animator.SetInteger(ClickCount, 0);
        }
    }
}
