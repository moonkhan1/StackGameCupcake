using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SellController : MonoBehaviour
{
    public static DeviceController Instance;
    [SerializeField] public LayerMask _layer;
    [SerializeField]Transform _fireTransform;
    [SerializeField]Transform _moveTransform;
    private Transform _transform;

    private Sequence _seq;
    private float count = 0;
    // int index;

    private void Start() {
        _transform = GetComponent<Transform>();
    }

    private void FixedUpdate() {
        
    count += Time.fixedDeltaTime;
    AddIngredient();
    
    }


    public void AddIngredient()
    {
        if (Physics.Raycast(_fireTransform.position, _fireTransform.TransformDirection(Vector3.down), out RaycastHit hit, 10f, _layer))
        {
            Debug.DrawRay(_fireTransform.position, _fireTransform.TransformDirection(Vector3.down) * hit.distance, Color.red);
             if (hit.collider.tag == "Collected" && hit.transform.GetChild(3).GetComponent<Renderer>().enabled)
             {
                if(count > 0.3)
                {
                DamageNumberEx.Instance.ShowNumber(4);
                    CollectedCoffeeData.Instance.CoffeeList.Remove(hit.transform);
                    hit.transform.parent =_transform;
                    GameObject go = hit.transform.gameObject;
                    go.transform.DOMove(_moveTransform.position, 0.75f)
                    .OnComplete(()=>
                    {
                        Destroy(go);
                    });
                
                // _cakePrfb.DOMove((new Vector3(_cakePrfb.position.x, -2, _cakePrfb.position.z)), 0.2f).SetLoops(-1, LoopType.Yoyo);
                // .OnComplete(()=>{
                //     Destroy(_cakePrfb.gameObject);
                // });
                // _seq = DOTween.Sequence();
                // _seq.Join(_cakePrfb.DOMoveY((_fireTransform.position.y - 5), 0.7f));
                count = 0;
                Debug.Log("hitted");
                }
                
             }
            
        }
        else
        {
            Debug.DrawRay(_fireTransform.position, _fireTransform.TransformDirection(Vector3.down) * 1000, Color.blue);
            Debug.Log("Did not Hit");
        }
    }
}
