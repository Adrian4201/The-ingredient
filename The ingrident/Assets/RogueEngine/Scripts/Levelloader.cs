using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Levelloader : MonoBehaviour
{
    public Animator animator;
    public float Transtiontime = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            loadNextlevel();
        }
        
    }
    public void loadNextlevel()
    {
        StartCoroutine(Loadlevel(SceneManager.GetActiveScene().buildIndex + 2));
    }
    IEnumerator Loadlevel(int level)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(Transtiontime);

        SceneManager.LoadScene(level);
    }
}
