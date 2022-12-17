using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using CASP.SoundManager;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private PlayerController _player;
    // [SerializeField] AudioSource _hungryMan;
    // [SerializeField] AudioSource _mainTheme;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }
    private void Start() {
        _player = FindObjectOfType<PlayerController>();
        if(_player == null)
            return;
        _player._speed = 0f;
        // _hungryMan.Play();
        // _mainTheme.Play();
        // SoundManager.Instance.Play("HungaryMan");

        // Time.timeScale = 0f;

       
    }

    // Update is called once per frame
    void Update()
    {   
            

        
    }

    public void LoadScene(string name)
        {
            StartCoroutine(LoadLevel(name));
        }

    IEnumerator LoadLevel(string name)
        {
            yield return SceneManager.LoadSceneAsync(name);
        }

}
