using System.Collections;
using UnityEngine;

public class PlayCardFX : MonoBehaviour
{
    private bool move;
    private bool player;
    private Vector3 targetPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartMoving());
        targetPos = new Vector3(-14f, -4.5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (move && player)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.5f);
        }
    }

    private IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(3);
        move = true;
    }

    public void SetPlayer()
    {
        player = true;
    }
}
