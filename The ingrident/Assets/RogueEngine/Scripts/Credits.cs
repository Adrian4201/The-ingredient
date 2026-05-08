using RogueEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Credits : MonoBehaviour
{
    [SerializeField] private GameObject textHolder;
    [SerializeField] private GameObject leftButton, rightButton;

    private bool isMoving = false;
    private float duration = 0.5f;

    private void Start()
    {
        leftButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(KeyInput.IsKeyPress(Key.RightArrow) && textHolder.transform.position.x > -1)
        {
            MoveToSecond();
        }
        else if (KeyInput.IsKeyPress(Key.LeftArrow) && textHolder.transform.position.x < -15)
        {
            MoveToFirst();
        }
    }

    public void MoveToSecond()
    {
        if(!isMoving)
        {
            StartCoroutine(LerpPos(Vector3.left * 16));
        }
    }

    public void MoveToFirst()
    {
        if(!isMoving)
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
        rightButton.SetActive(false);
        leftButton.SetActive(false);

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

        if (textHolder.transform.position.x == 0) rightButton.SetActive(true);
        if(textHolder.transform.position.x == -16) leftButton.SetActive(true);
    }
}