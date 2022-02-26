using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalUi : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void OnButtonDown()
    {
        animator.SetBool("ButtonPlayDown", true);
    }

    public void OnButtonUp()
    {

        StartCoroutine("Waiter");
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        animator.SetBool("ButtonPlayDown", false);
        SceneManager.LoadScene("GameScene");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
