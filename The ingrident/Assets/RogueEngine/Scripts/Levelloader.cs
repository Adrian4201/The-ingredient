using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
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
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            loadNextlevel();
        }
        
    }
    public void loadNextlevel()
    {
        StartCoroutine(Loadlevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator Loadlevel(int level)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(Transtiontime);

        SceneManager.LoadScene(level);
    }
}
