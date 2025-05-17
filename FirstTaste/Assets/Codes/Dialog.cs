using UnityEngine;
using TMPro;
using System.Collections;
using UnityEditor.Tilemaps;

public class Dialog : MonoBehaviour
{
    public GameObject DialogPanel;
    public TextMeshProUGUI textcomponet;
    public string[] lines;
    public float textspeed;

    private int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        textcomponet.text = string.Empty;
        StartDialog();

    }

    // Update called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(textcomponet.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textcomponet.text = lines[index];
            }
        }
        
    }

   void StartDialog()
    {
        index = 0;
        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textcomponet.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textcomponet.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            DialogPanel.SetActive(false); // Close the dialog properly
        }
    }
}
