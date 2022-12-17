using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using CASP.SoundManager;

public class CollectedCoffee : MonoBehaviour
{

    public bool IsCalculated = true;
    private int _count;
    private Sequence seq2;
    private string _tag;

    public int CakeCount => _count;

    private void Start() 
    {
    }
    private void Update()
    {
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collactable"))
        {
            
            DamageNumberEx.Instance.ShowNumber(2);
            SoundManager.Instance.Play("Toplama");
            other.tag = "Collected";
            CollectedCoffeeData.Instance.finalCountList.Add(other.gameObject);
            CollectedCoffeeData.Instance.CoffeeList.Add(other.transform);
            other.gameObject.AddComponent<CollectedCoffee>();
            // if(other.gameObject.TryGetComponent(out Rigidbody rb))
            // {
            //     rb.isKinematic = true;
            // }
            if(other.gameObject.GetComponent<Rigidbody>() == null)
             {
                other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
             }
            var seq = DOTween.Sequence();
            seq.Kill();
            seq = DOTween.Sequence();
            for (int i = CollectedCoffeeData.Instance.CoffeeList.Count - 1; i > 0; i--)
            {
                seq.Join(CollectedCoffeeData.Instance.CoffeeList[i].DOScale(new Vector3(83, 80.5f, 32), 0.2f));
                seq.AppendInterval(0.05f);
                seq.Join(CollectedCoffeeData.Instance.CoffeeList[i].DOScale(new Vector3(70.9f, 68.5f, 23.5f), 0.2f));
            }
        }

        if (other.CompareTag("Obstacles"))
        {
            other.transform.tag = "Touched";
             SoundManager.Instance.Play("Dagilma");
            foreach (var item in CollectedCoffeeData.Instance.CoffeeList.TakeLast(Random.Range(3, CollectedCoffeeData.Instance.CoffeeList.Count-1)))
            {
            DamageNumberEx.Instance.ShowNumberDecrease(5);
                seq2.Join(item.DOScale(new Vector3(83, 80.5f, 32), 0.4f));
                seq2.Append(item.DOLocalJump(new Vector3(item.localPosition.x + Random.Range(-2, 2),-3.3f, (item.localPosition.z + Random.Range(-5, 15))), 0.7f, 1, 0.35f));
                seq2.Join(item.DOScale(new Vector3(70.9f, 68.5f, 23.5f), 0.4f));
                
                CollectedCoffeeData.Instance.finalCountList.Remove(item.gameObject);
                CollectedCoffeeData.Instance.CoffeeList.Remove(item);
                StartCoroutine(WaitAndMakeCollactabel(item));
            }
        }

        // CheckOpenMesh(other);
        
        

    }

 


    IEnumerator WaitAndMakeCollactabel(Transform item)
    {
        
        yield return new WaitForSeconds(0.4f);
        item.tag = "Collactable";
        
    }

    // public void CheckOpenMesh(Collider _other)
    // {
    //     switch (_other.tag)
    //     {
    //         case "WhiteCream":
    //         this.transform.GetChild(1).GetComponent<Renderer>().enabled = true;
    //         break;
            
    //         default:
    //         break;
    //     }
        
    // }

    

 

}
