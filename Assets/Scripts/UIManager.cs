using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DamageNumbersPro;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using CASP.SoundManager;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Settings Panel")]
    [SerializeField] GameObject SettingsPanel;
    [SerializeField] GameObject SettingsUIPanel;
    [SerializeField] GameObject TapToPlay;
    [SerializeField] Image _settingButton;
    [SerializeField] Image _pauseButton;
    [SerializeField] Image _exitPauseButton;
    private PlayerController _player;

    [Header("Settings Panel")]
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject WinUIPanel;
    // [SerializeField] TMP_Text _feedByMoney;
    [SerializeField] TMP_Text _getMoney;
    [SerializeField] TMP_Text _money;

    [Header("Final Cofigurations")]
    private FinalController _finalRoad;

    [SerializeField] Image _cake;
    [SerializeField] TMP_Text _cakePercentage;
    // [SerializeField] MoneySO _data;
     [SerializeField] public List<GameObject> _cupcakes;

    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
        }
        _finalRoad = FindObjectOfType<FinalController>();
        


    }
    private void Update() {
        _money.text = DamageNumberEx.Instance.TotalMoney.ToString();
    }

    private void Start() {
        _pauseButton.enabled = false;
        _exitPauseButton.enabled = false;
        _player = FindObjectOfType<PlayerController>();
        TapToPlay.transform.DOScale(new Vector3(5.9f,1.5f), 1f).SetLoops(-1, LoopType.Yoyo);
        _finalRoad.GetComponent<FinalController>().OnFinish += OpenWinPanel;
    }
    private void OnEnable()
    {
        _finalRoad.GetComponent<FinalController>().OnFinish += OpenWinPanel;
    }
    private void OnDisable()
    {
        if(_finalRoad !=null)
        _finalRoad.GetComponent<FinalController>().OnFinish -= OpenWinPanel;
    }

    public void OpenSettingsPanel()
    {
        SettingsPanel.SetActive(true);
        SettingsUIPanel.SetActive(true);
        SettingsUIPanel.transform.localScale = Vector3.zero;
        Image panelImg = SettingsPanel.GetComponent<Image>();
        panelImg.color = new Color(0, 0, 0, 0);
        DOTween.To(() => panelImg.color, x => panelImg.color = x, new Color32(32, 32, 32, 180), 0.2f);
        SettingsUIPanel.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f);
        _settingButton.enabled = false;
    }
    public void CloseSettingsPanel()
    {

        // 
        Image panelImg = SettingsPanel.GetComponent<Image>();
        DOTween.To(() => panelImg.color, x => panelImg.color = x, new Color32(32, 32, 32, 0), 0.2f);
        SettingsUIPanel.transform.DOScale(0f, 0.2f).OnComplete(() =>
        {
            SettingsPanel.SetActive(false);
            SettingsUIPanel.SetActive(false);
        });
        _settingButton.enabled = true;
        
    }

    public void TapToPlayButton()
    {

        // Time.timeScale = 1f;
        _player._speed = 10f;
        _settingButton.enabled = false;
        _pauseButton.enabled = true;
        GameObject go = TapToPlay.gameObject;
        Destroy(go);
        
    }

    public void PauseButton()
    {

        // Time.timeScale = 1f;
        _player._speed = 0f;
        _pauseButton.enabled = false;
        _exitPauseButton.enabled = true;
        SettingsPanel.SetActive(true);
        SettingsUIPanel.SetActive(true);
        SettingsUIPanel.transform.localScale = Vector3.zero;
        Image panelImg = SettingsPanel.GetComponent<Image>();
        panelImg.color = new Color(0, 0, 0, 0);
        DOTween.To(() => panelImg.color, x => panelImg.color = x, new Color32(32, 32, 32, 180), 0.2f);
        SettingsUIPanel.transform.DOScale(new Vector3(0.35f, 0.27f, 0.3f), 0.2f);
        
    }

    public void ExitPauseButton()
    {

        // Time.timeScale = 1f;
        _player._speed = 10f;
        _pauseButton.enabled = true;
        _exitPauseButton.enabled = false;
        Image panelImg = SettingsPanel.GetComponent<Image>();
        DOTween.To(() => panelImg.color, x => panelImg.color = x, new Color32(32, 32, 32, 0), 0.2f);
        SettingsUIPanel.transform.DOScale(0f, 0.2f).OnComplete(() =>
        {
            SettingsPanel.SetActive(false);
            SettingsUIPanel.SetActive(false);
        });
        
    }

    public void OpenWinPanel()
    {
        WinPanel.SetActive(true);
        WinUIPanel.SetActive(true);
        WinUIPanel.transform.localScale = Vector3.zero;
        Image panelImg = WinPanel.GetComponent<Image>();
        panelImg.color = new Color(0, 0, 0, 0);
        DOTween.To(() => panelImg.color, x => panelImg.color = x, new Color32(32, 32, 32, 180), 0.2f);
        WinUIPanel.transform.DOScale(new Vector3(1.123f, 1.123f, 1.123f), 0.2f);
        // _feedByMoney.text = $"{DamageNumberEx.Instance.TotalMoney.ToString()} $";
        // _getMoney.text = (System.Convert.ToInt32(DamageNum.Instance.TotalMoney * 0.25f)).ToString();

        // DOTween.To(() => int.Parse(_feedByMoney.text), (x) => _feedByMoney.text = x.ToString(),System.Convert.ToInt32(_data.Money * 1f) + 0, 2f);
        DOTween.To(() => int.Parse(_getMoney.text), (x) => _getMoney.text = x.ToString(), System.Convert.ToInt32( DamageNumberEx.Instance._totalMoney* 0.2f) + 0, 2f);
        
        SoundManager.Instance.Play("Win");
        DOTween.To(() => (_cake.fillAmount), (x) => _cake.fillAmount = x, _cake.fillAmount + (((CollectedCoffeeData.Instance.finalCountList.Count * 100)/ _cupcakes.Count)*0.01f), 2f);
        DOTween.To(() => int.Parse(_cakePercentage.text), (x) => _cakePercentage.text = x.ToString(), ((CollectedCoffeeData.Instance.finalCountList.Count * 100)/  _cupcakes.Count), 2f);
        Debug.Log((CollectedCoffeeData.Instance.finalCountList.Count * 100)/  _cupcakes.Count);

    }

    public void CloseWinPanel()
    {

        // 
        Image panelImg = WinPanel.GetComponent<Image>();
        DOTween.To(() => panelImg.color, x => panelImg.color = x, new Color32(32, 32, 32, 0), 0.2f);
        WinUIPanel.transform.DOScale(0f, 0.2f).OnComplete(() =>
        {
            WinPanel.SetActive(false);
            WinUIPanel.SetActive(false);
        });

        // DOTween.To(() => int.Parse(_getMoney.text), (x) => _getMoney.text = x.ToString(), 0, 2f);
        DOTween.To(() => DamageNumberEx.Instance._totalMoney, (x) => DamageNumberEx.Instance._totalMoney = x, System.Convert.ToInt32(DamageNumberEx.Instance._totalMoney) + System.Convert.ToInt32(_getMoney.text), 2f);
        
    }

}
