using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using CASP.SoundManager;
public class DeviceController : MonoBehaviour
{
    public static DeviceController Instance;
    [SerializeField] public LayerMask _layer;
    [SerializeField] public GameObject _cakePrfb;
    [SerializeField]Transform _fireTransform;

    private Sequence _seq;
    private float count = 0;
    // int index;

    private void Start() {
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
             if (hit.collider.tag == "Collected" && !hit.transform.GetChild(3).GetComponent<Renderer>().enabled)
             {
                if(count > 0.1)
                {
                hit.transform.GetChild(3).GetComponent<Renderer>().enabled = true;
                DamageNumberEx.Instance.ShowNumber(2);
                SoundManager.Instance.Play("Firin");
                GameObject go = Instantiate(_cakePrfb, _fireTransform.position, Quaternion.Euler(-90,0,0));
                go.transform.DOMoveY((_cakePrfb.transform.position.y), 0.15f)
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

    // IEnumerator WaitAndPour()
    // {
    //     while(true)
    //     {
    //         yield return new WaitForSeconds(0.5f);
    //         Instantiate(_cakePrfb, _fireTransform.position, Quaternion.identity).DOMoveY((_cakePrfb.position.y), 0.2f);
    //     }
    // }
    
}
