using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using CASP.SoundManager;
public class PackagingDevice : MonoBehaviour
{
   public static PackagingDevice Instance;
    [SerializeField] public LayerMask _layer;
    [SerializeField] public GameObject _package;
    [SerializeField]Transform _fireTransformPackage;

    private float countPackage = 0;
    private Sequence _seq;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        countPackage += Time.fixedDeltaTime;
        AddIngredient();
    }

    public void AddIngredient()
    {
        if (Physics.Raycast(_fireTransformPackage.position, _fireTransformPackage.TransformDirection(Vector3.back), out RaycastHit hit5, 10f, _layer))
        {
            Debug.DrawRay(_fireTransformPackage.position, _fireTransformPackage.TransformDirection(Vector3.back) * hit5.distance, Color.red);
             if (hit5.collider.tag == "Collected" && !hit5.transform.GetChild(6).GetComponent<Renderer>().enabled && hit5.transform.GetChild(1).GetComponent<Renderer>().enabled)
             {
                    
                if(countPackage > 0.1)
                {

                hit5.transform.GetChild(6).GetComponent<Renderer>().enabled = true;
                DamageNumberEx.Instance.ShowNumber(3);
                SoundManager.Instance.Play("Qablasdirma");
                hit5.transform.GetChild(6).GetChild(0).GetComponent<Renderer>().enabled = true;
                GameObject go = Instantiate(_package, _fireTransformPackage.position, Quaternion.Euler(-90,0,0));
                go.transform.DOMoveY((_package.transform.position.y), 0.15f)
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
                countPackage = 0;
                Debug.Log("hitted");
                }
                
             }
            
        }
        else
        {
            Debug.DrawRay(_fireTransformPackage.position, _fireTransformPackage.TransformDirection(Vector3.back) * 1000, Color.blue);
            Debug.Log("Did not Hit");
        }
    }
}
