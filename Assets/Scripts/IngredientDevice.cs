using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using CASP.SoundManager;
public class IngredientDevice : MonoBehaviour
{
    public static IngredientDevice Instance;
    [SerializeField] public LayerMask _layer;
    [SerializeField] public GameObject Cherry;
    [SerializeField] public GameObject Stick;
    [SerializeField] public GameObject Decoration;

    [SerializeField]Transform _fireTransformCherry;
    [SerializeField]Transform _fireTransformStick;
    [SerializeField]Transform _fireTransformDecoration;

    private Sequence _seq;
    private float countCherry = 0;
    private float countStick = 0;
    private float countDecor = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        countCherry += Time.fixedDeltaTime;
        countStick += Time.fixedDeltaTime;
        countDecor += Time.fixedDeltaTime;
        AddIngredient();
        
    }

     public void AddIngredient()
    {
        if (Physics.Raycast(_fireTransformCherry.position, _fireTransformCherry.TransformDirection(Vector3.down), out RaycastHit hit3, 10f, _layer))
        {
            Debug.DrawRay(_fireTransformCherry.position, _fireTransformCherry.TransformDirection(Vector3.down) * hit3.distance, Color.red);
             if (hit3.collider.tag == "Collected" && !hit3.transform.GetChild(2).GetComponent<Renderer>().enabled && hit3.transform.GetChild(1).GetComponent<Renderer>().enabled)
             {
                if(countCherry > 0.1)
                {
                
                hit3.transform.GetChild(2).GetComponent<Renderer>().enabled = true;
                DamageNumberEx.Instance.ShowNumber(2);
                SoundManager.Instance.Play("Qablasdirma");
                GameObject go = Instantiate(Cherry, _fireTransformCherry.position, Quaternion.Euler(-90,0,0));
                go.transform.DOMoveY((Cherry.transform.position.y), 0.15f)
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
                countCherry = 0;
                Debug.Log("hitted");
                
                }
             }
            
        }
        else
        {
            Debug.DrawRay(_fireTransformCherry.position, _fireTransformCherry.TransformDirection(Vector3.down) * 1000, Color.blue);
            Debug.Log("Did not Hit");
        }

        if (Physics.Raycast(_fireTransformStick.position, _fireTransformStick.TransformDirection(Vector3.down), out RaycastHit hit4, 10f, _layer))
        {
            Debug.DrawRay(_fireTransformStick.position, _fireTransformStick.TransformDirection(Vector3.down) * hit4.distance, Color.red);
             if (hit4.collider.tag == "Collected" && !hit4.transform.GetChild(4).GetComponent<Renderer>().enabled && hit4.transform.GetChild(1).GetComponent<Renderer>().enabled)
             {
                if(countStick > 0.1)
                {
                hit4.transform.GetChild(4).GetComponent<Renderer>().enabled = true;
                DamageNumberEx.Instance.ShowNumber(2);
                GameObject go = Instantiate(Stick, _fireTransformStick.position, Quaternion.Euler(-90,0,0));
                go.transform.DOMoveY((Stick.transform.position.y), 0.15f)
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
                countStick = 0;
                Debug.Log("hitted");
                
                }
             }
            
        }
        else
        {
            Debug.DrawRay(_fireTransformStick.position, _fireTransformStick.TransformDirection(Vector3.down) * 1000, Color.blue);
            Debug.Log("Did not Hit");
        }

        if (Physics.Raycast(_fireTransformDecoration.position, _fireTransformDecoration.TransformDirection(Vector3.down), out RaycastHit hit5, 10f, _layer))
        {
            Debug.DrawRay(_fireTransformDecoration.position, _fireTransformDecoration.TransformDirection(Vector3.down) * hit5.distance, Color.red);
             if (hit5.collider.tag == "Collected" && !hit5.transform.GetChild(0).GetComponent<Renderer>().enabled && hit5.transform.GetChild(1).GetComponent<Renderer>().enabled)
             {
                if(countDecor > 0.1)
                {
                hit5.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
                DamageNumberEx.Instance.ShowNumber(2);
                GameObject go = Instantiate(Decoration, _fireTransformDecoration.position, Quaternion.Euler(-90,0,0));
                go.transform.DOMoveY((Decoration.transform.position.y), 0.15f)
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
                countDecor = 0;
                Debug.Log("hitted");
                
                }
             }
            
        }
        else
        {
            Debug.DrawRay(_fireTransformDecoration.position, _fireTransformDecoration.TransformDirection(Vector3.down) * 1000, Color.blue);
            Debug.Log("Did not Hit");
        }


}
}
