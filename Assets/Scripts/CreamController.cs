using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CASP.SoundManager;

using DG.Tweening;

public class CreamController : MonoBehaviour
{
    public static CreamController Instance;
    [SerializeField] public LayerMask _layer;
    [SerializeField] public GameObject _WhiteCream;
    [SerializeField] public GameObject _Chocolate;
    [SerializeField]Transform _fireTransformWCream;
    [SerializeField]Transform _fireTransformChocolate;

    private Sequence _seq;
    private float countCream = 0;
    private float countChoc = 0;
    private void Start() {
    }

    private void FixedUpdate() {
        
    countCream += Time.fixedDeltaTime;
    countChoc += Time.fixedDeltaTime;
    AddIngredient();
    
    }


    public void AddIngredient()
    {
        if (Physics.Raycast(_fireTransformWCream.position, _fireTransformWCream.TransformDirection(Vector3.back), out RaycastHit hit1, 10f, _layer))
        {
            Debug.DrawRay(_fireTransformWCream.position, _fireTransformWCream.TransformDirection(Vector3.back) * hit1.distance, Color.red);
             if (hit1.collider.tag == "Collected" && !hit1.transform.GetChild(1).GetComponent<Renderer>().enabled && hit1.transform.GetChild(3).GetComponent<Renderer>().enabled)
             {
                
                hit1.transform.GetChild(1).GetComponent<Renderer>().enabled = true;
                DamageNumberEx.Instance.ShowNumber(3);
                // SoundManager.Instance.Play("Krema");
                GameObject go = Instantiate(_WhiteCream, _fireTransformWCream.position, Quaternion.Euler(-90,0,0));
                go.transform.DOMoveY((_WhiteCream.transform.position.y), 0.3f)
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
                Debug.Log("hitted");
                
                
             }
            
        }
        else
        {
            Debug.DrawRay(_fireTransformWCream.position, _fireTransformWCream.TransformDirection(Vector3.back) * 1000, Color.blue);
            Debug.Log("Did not Hit");
        }

        if (Physics.Raycast(_fireTransformChocolate.position, _fireTransformChocolate.TransformDirection(Vector3.back), out RaycastHit hit2, 10f, _layer))
        {
            Debug.DrawRay(_fireTransformChocolate.position, _fireTransformChocolate.TransformDirection(Vector3.back) * hit2.distance, Color.red);
             if (hit2.collider.tag == "Collected" && !hit2.transform.GetChild(5).GetComponent<Renderer>().enabled && hit2.transform.GetChild(1).GetComponent<Renderer>().enabled)
             {
                
                hit2.transform.GetChild(5).GetComponent<Renderer>().enabled = true;
                DamageNumberEx.Instance.ShowNumber(3);
                GameObject go = Instantiate(_Chocolate, _fireTransformChocolate.position, Quaternion.Euler(-90,0,0));
                go.transform.DOMoveY((_Chocolate.transform.position.y), 0.3f)
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
                Debug.Log("hitted");
                
                
             }
            
        }
        else
        {
            Debug.DrawRay(_fireTransformChocolate.position, _fireTransformChocolate.TransformDirection(Vector3.back) * 1000, Color.blue);
            Debug.Log("Did not Hit");
        }
    }


}
