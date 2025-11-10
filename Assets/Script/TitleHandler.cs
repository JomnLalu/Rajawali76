using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleHandler : MonoBehaviour
{
    public string gameScene;
    public GameObject loadingCurtain; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            loadingCurtain.transform.Translate(0f, 0f, 0f);
            transform.localScale = Vector3.Lerp(
                loadingCurtain.transform.localScale,
                new Vector3(15f, 15f, 15f),
                Time.deltaTime * 0.5f);
            SceneManager.LoadScene(gameScene);
        }
    }
}
