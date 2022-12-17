using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HandScript : MonoBehaviour
{
    [SerializeField] Transform _takeTransform;
    [SerializeField] Transform _parentTransform;
    // [SerializeField] Transform _moveTransform;
    [SerializeField] GameObject _cakeOnHand;
    private Animator _anim;
    private bool didTake = false;

    private Sequence _seq;

    private void Start() {
        
        _anim = GetComponentInParent<Animator>();
        // _takeTransform  = GetComponent<Transform>().GetChild(0);
        // _parentTransform = GetComponentInParent<Transform>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Collected"))
        {
            if(!didTake)
            {
                _seq = DOTween.Sequence();
                CollectedCoffeeData.Instance.CoffeeList.Remove(other.transform);
               GameObject go =  other.transform.gameObject;
                _seq.Join(go.transform.DOMove(_takeTransform.position, 0.7f)).OnComplete(()=>{
               go.transform.parent = _takeTransform;
               go.transform.position =  _takeTransform.position;
            //    Destroy(go);
                // Destroy(go.gameObject);
                // _cakeOnHand.SetActive(true);
                // _seq.Join(_parentTransform.DOMove(_moveTransform.position, 2.5f));
                });
                
                
                Debug.Log(_parentTransform.name);
                
                _anim.SetTrigger("didTake");
            }
        didTake = true;
        }
    }
}
