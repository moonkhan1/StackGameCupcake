using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using CASP.CameraManager;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    private float Horizontal;
    [SerializeField]private float VerticalSpeed;
    private Transform _transform;
    [SerializeField]public float _speed = 10f;
    [SerializeField] private float LerpSpeed = 10f;
    [SerializeField] private float OffSet = 2f;
    public bool isFinished = false;
    private DamageNumberEx _dme;


    void Start()
    {
        _transform = GetComponent<Transform>();
        CollectedCoffeeData.Instance.CoffeeList.Add(transform);
        // CameraManager.instance.OpenCamera("Hand", 0.3f, CameraEaseStates.EaseIn);
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal = Input.GetAxis("Horizontal");
        if(!isFinished)
        {
        float movement = (_speed * Input.GetAxis("Horizontal")) * Time.deltaTime;
            _transform.Translate(-1 * movement,(Time.deltaTime *-1) * _speed, 0);
            _transform.localPosition = new Vector3((Mathf.Clamp(transform.localPosition.x, 5.78f, 12.25f)),transform.localPosition.y, transform.localPosition.z);
        }
        // _transform.position += new Vector3(Horizontal, 0, VerticalSpeed) * _speed * Time.deltaTime;
        if(CollectedCoffeeData.Instance.CoffeeList.Count > 1)
            CoffeeFollow();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Collactable"))
        {
           
            CollectedCoffeeData.Instance.CoffeeList.Add(other.transform);
            other.tag = "Collected";
            CollectedCoffeeData.Instance.finalCountList.Add(other.gameObject);
            other.gameObject.AddComponent<CollectedCoffee>();
             if(other.gameObject.GetComponent<Rigidbody>() == null)
             {
                other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
             }
            var seq = DOTween.Sequence();
            seq.Kill();
            seq = DOTween.Sequence();
            for (int i =  CollectedCoffeeData.Instance.CoffeeList.Count - 1; i > 0; i--)
            {
                seq.Join(CollectedCoffeeData.Instance.CoffeeList[i].DOScale(new Vector3(83, 80.5f, 32), 0.2f));
                seq.AppendInterval(0.05f);
                seq.Join(CollectedCoffeeData.Instance.CoffeeList[i].DOScale(new Vector3(70.9f, 68.5f, 23.5f), 0.2f));
            }
        }
        

        
    }

    public void CoffeeFollow()
    {
        for (int i = 1; i < CollectedCoffeeData.Instance.CoffeeList.Count; i++)
        {
        Vector3 PrevPos = CollectedCoffeeData.Instance.CoffeeList[i-1].position + Vector3.forward*OffSet;
        Vector3 CurrentPos = CollectedCoffeeData.Instance.CoffeeList[i].transform.position;
        CollectedCoffeeData.Instance.CoffeeList[i].transform.position = Vector3.Lerp(CurrentPos, PrevPos, LerpSpeed * Time.deltaTime);
            
        }
    }
}
