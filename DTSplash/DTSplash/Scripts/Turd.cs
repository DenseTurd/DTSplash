using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Turd : MonoBehaviour
{
    public List<GameObject> cubes;
    public AudioSource fogHorn;
    float hornStartDelay;
    bool splash;
    bool startedSplash;
    bool splashed;

    float splashDelay = 0.7f;
    float loadNextSceneDelay = 1.2f;

    void Start()
    {
        foreach (var cube in cubes)
            cube.GetComponent<Cube>().Reset();
    }
    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

        splashDelay-= Time.deltaTime;
        if (!startedSplash)
            if (splashDelay <= 0) 
            { 
                Splash();
                startedSplash = true;
            }

        if (hornStartDelay > 0)
            hornStartDelay -= Time.deltaTime;

        if (splash)
            if (hornStartDelay <= 0)
            {
                StartCoroutine(JuicyCubes());
                splash = false;
            }

        if (splashed)
        {
            loadNextSceneDelay -= Time.deltaTime;
            if (loadNextSceneDelay <= 0) SceneManager.LoadScene(1);
        }
    }

    void Splash()
    {
        fogHorn.Play();
        hornStartDelay = 0.8f;
        splash = true;
    }

    public IEnumerator JuicyCubes()
    {
        Debug.Log("TurdCoroutine");
        for (int i = 0; i < cubes.Count; i++)
        {
            cubes[i].GetComponent<Cube>().go = true;
            yield return new WaitForSeconds(0.013f);
        }

        Debug.Log("Stopping all coroutines");
        StopAllCoroutines();
        splashed = true;

        yield return new WaitForSeconds(0.05f);
    }
}
