using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Read_Function : MonoBehaviour
{
    [SerializeField] private InputField input;
    [SerializeField] private GameObject flag;
    [SerializeField] private GameObject error;
    [SerializeField] private GameObject message;
    [SerializeField] private Rigidbody2D kai;
    [SerializeField] private AudioSource sfx;
    [SerializeField] private AudioClip ding;
    [SerializeField] private AudioClip malfunc;
    private bool captured;

    private void Awake()
    {
        kai = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        captured = false;
    }

    public void SubmitFunction()
    {
        if (captured == false)
        {
            string func = input.text;

            if (Regex.IsMatch(func, "(p|P)rint\\(\"(h|H)ello,(\\s?)(w|W)orld(\\.|\\!)?\"\\)"))
            {
                error.SetActive(false);
                flag.SetActive(true);
                message.SetActive(true);
                sfx.PlayOneShot(ding, 0.5f);
                kai.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
                captured = true;
            }
            else
            {
                flag.SetActive(false);
                error.SetActive(true);
                sfx.PlayOneShot(malfunc, 0.5f);
                StartCoroutine(WaitXSecs(2));
            }
        }
    }

    IEnumerator WaitXSecs(int secs)
    {
        yield return new WaitForSeconds(secs);
        error.SetActive(false);
    }
}
