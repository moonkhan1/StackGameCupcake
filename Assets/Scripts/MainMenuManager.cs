using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] public List<Image> _imager; 
    private bool isLoading = true;
    void Start()
    {

        StartCoroutine(LoadingDots(1f));
        StartCoroutine(LoadGame(5.3f));
        
    }

    private void FixedUpdate() {
    }
    void Update()
    {
        
    }

    IEnumerator LoadingDots(float time)
    {
       while(true)
       { 
            foreach (var image in _imager)
            {
                if(isLoading)
                {
                image.enabled = true;
                yield return new WaitForSeconds(time);
                }
                

            }
            isLoading = true;
            _imager.ForEach(u => {
                u.enabled = false;
                });
       }

    }

    IEnumerator LoadGame(float time)
    {
        yield return new WaitForSeconds(time);
        GameManager.Instance.LoadScene("Game");
    }
}
