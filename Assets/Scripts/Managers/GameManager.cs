using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    private WaitForSeconds wait = new WaitForSeconds(6f);

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.Show("IntroPopup");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaitForPlayVideo());
    }

    private IEnumerator WaitForPlayVideo()
    {
        yield return wait;

        UIManager.Instance.Hide("IntroPopup");
    }
}