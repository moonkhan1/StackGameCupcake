using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using Cinemachine;
using CASP.CameraManager;
using CASP.SoundManager;

// using Cinemachine.Utility;

public class FinalController : MonoBehaviour
{
    private PlayerController _player;
    [SerializeField] public GameObject _finalMoney;
    [SerializeField] public CinemachineVirtualCamera _camera;

    [SerializeField] List<Transform> _jumpLocations;
    private CinemachineTransposer _transposer;

    public event System.Action OnFinish;

    
    private Sequence seq3;
    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _transposer = _camera.GetCinemachineComponent<CinemachineTransposer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Collected") || other.CompareTag("Player"))
        {
            seq3 = DOTween.Sequence();
            _player.GetComponent<PlayerController>().isFinished = true;
            for (int i =  CollectedCoffeeData.Instance.CoffeeList.Count - 1; i > 0; i--)
            {
                for (int j =  CollectedCoffeeData.Instance.CoffeeList.Count - 1; j > 0; j--)
            {
                seq3.Join(CollectedCoffeeData.Instance.CoffeeList[i].DOJump((_jumpLocations[j].position), 0.6f, 1, 0.35f))
                .OnComplete(()=>{
                    CollectedCoffeeData.Instance.CoffeeList.Remove(CollectedCoffeeData.Instance.CoffeeList[i]);
                });
            }
                // seq3.AppendInterval(0.05f);
            }
                    CameraManager.instance.OpenCamera("Money", 0.3f, CameraEaseStates.EaseInOut);
            // seq3.OnComplete(()=>{
            // seq3.Kill();
            // });
            // _camera.DOGoto(_finalMoney.transform.position.y, true);
            // _camera.m_LookAt = _finalMoney.transform;
            // _camera.m_Follow = _finalMoney.transform;
            // _transposer.m_XDamping=0;
            // _transposer.m_YDamping=0;
            // _transposer.m_FollowOffset.y = 10.83f;
            // _transposer.m_FollowOffset.x = 0.4f;
            // _transposer.m_FollowOffset.z = -16f;
            // _camera.transform.DOPunchRotation(new Vector3(45,45,45), 0.2f);
            
            // seq3.Join(_camera.transform.DOMove(new Vector3(9, 5f, 145.5f), 0.2f)).
            // Join(_camera.transform.DORotate(new Vector3(32.5f, 1f, -1.25f), 0.2f)).OnComplete(()=>{

            // });
            // _camera.transform

            _finalMoney.transform.DOMoveY((float)(_finalMoney.transform.position.y + (DamageNumberEx.Instance.TotalMoney * 0.05)), 2)
            .OnComplete(()=>{
                OnFinish?.Invoke();
                
            });
            

            // DamageNumberEx.Instance.TotalMoney;
        }
    }
}
