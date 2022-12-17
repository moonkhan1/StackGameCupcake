using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DamageNumbersPro;
using DG.Tweening;
using TMPro;


public class DamageNumberEx : MonoBehaviour
{
    public static DamageNumberEx Instance;
    [SerializeField] public DamageNumber numberPrefab;
    [SerializeField] public DamageNumber numberPrefabDecrease;
    [SerializeField] public TMP_Text _money;
    private Transform _playerTranform;
    // private float _numberMultipl = 2.3f;
    private int _newnumberMultipl;
    public int _totalMoney = 0;

    public int TotalMoney => _totalMoney;
private void Awake() {
    if(Instance == null)
    {
        Instance = this;
    }

}

private void Start() {
         _playerTranform = FindObjectOfType<PlayerController>().transform;

}


    

    public void ShowNumber(int numberMultpl)
    {
        // for (int i = 1; i < CollectedCoffeeData.Instance.CoffeeList.Count; i++)
        // {
            int NewnumberMultipl = numberMultpl;
            _newnumberMultipl = NewnumberMultipl;
            _totalMoney += numberMultpl;

        // }
            DamageNumber damageNumber = numberPrefab.Spawn(_playerTranform.position, _newnumberMultipl);
            _money.text = System.Convert.ToInt32(_totalMoney).ToString();
    }

     public void ShowNumberDecrease(int numberMultpl)
    {
        // for (int i = 1; i < CollectedCoffeeData.Instance.CoffeeList.Count; i++)
        // {
            int NewnumberMultipl = numberMultpl;
            _newnumberMultipl = NewnumberMultipl;
            _totalMoney -= numberMultpl;

        // }
            DamageNumber damageNumber = numberPrefabDecrease.Spawn(_playerTranform.position, _newnumberMultipl);
            if(_totalMoney < 0)
                _totalMoney = 0;    
            else
                _money.text = System.Convert.ToInt32(_totalMoney).ToString();
                
    }

}
