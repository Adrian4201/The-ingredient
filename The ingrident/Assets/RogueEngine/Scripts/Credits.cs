using RogueEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Credits : MonoBehaviour
{
    [SerializeField] private GameObject textHolder;

    private bool isMoving = false;
    private float duration = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if(KeyInput.IsKeyPress(Key.RightArrow))
        {
            MoveToSecond();
        }
        else if (KeyInput.IsKeyPress(Key.LeftArrow))
        {
            MoveToFirst();
        }
    }

    public void MoveToSecond()
    {
        if(!isMoving && textHolder.transform.position.x > -1)
        {
            StartCoroutine(LerpPos(Vector3.left * 16));
        }
    }

    public void MoveToFirst()
    {
        if(!isMoving && textHolder.transform.position.x < -15)
        {
            StartCoroutine(LerpPos(Vector3.zero));
        }
    }

    public void OnClickMenu()
    {
        SceneNav.GoToMenu();
    }

    private IEnumerator LerpPos(Vector3 target)
    {
        isMoving = true;
        Vector3 startPos = textHolder.transform.position;
        float elapsedTime = 0;

        while(elapsedTime < duration)
        {
            textHolder.transform.position = Vector3.Lerp(startPos, target, elapsedTime / duration);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        textHolder.transform.position = target;
        isMoving = false;
    }
}