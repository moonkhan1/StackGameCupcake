using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
public class FinalCakeController : MonoBehaviour
{
    [SerializeField] Image _cake;
    [SerializeField] TMP_Text _cakePercentage;
    [SerializeField] Image WinUIPanel;
    [SerializeField] public List<GameObject> _cupcakes;
    private int _collectedCoffee;
    private FinalController _finalRoad;

    void Awake()
    {
         _finalRoad = FindObjectOfType<FinalController>();
        _collectedCoffee = FindObjectOfType<CollectedCoffee>().CakeCount;
    }
    void Start()
    {
        // _finalRoad.GetComponent<FinalController>().OnFinish += CakeAnim;
        // _cake.fillAmount = 0;
    }

    // private void OnEnable()
    // {
    //     _finalRoad.GetComponent<FinalController>().OnFinish += CakeAnim;
    // }
    // private void OnDisable()
    // {
    //     if(_finalRoad !=null)
    //     _finalRoad.GetComponent<FinalController>().OnFinish -= CakeAnim;
    // }


    // Update is called once per frame
    // void CakeAnim()
    // {
        
    //     DOTween.To(() => (_cake.fillAmount), (x) => _cake.fillAmount = x, _cake.fillAmount += (((CollectedCoffeeData.Instance.finalCountList.Count * 100)/ _cupcakes.Count)*0.1f), 2f);
    //     DOTween.To(() => int.Parse(_cakePercentage.text), (x) => _cakePercentage.text = x.ToString(), ((CollectedCoffeeData.Instance.finalCountList.Count * 100)/  _cupcakes.Count), 2f);
    //     Debug.Log((CollectedCoffeeData.Instance.finalCountList.Count * 100)/  _cupcakes.Count);
        
    // }
}
