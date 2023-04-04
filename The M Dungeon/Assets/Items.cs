using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    private int Keys=0;
    //public Transform Player_Text;
    [SerializeField] private Text keysText; 

    // Start is called before the first frame update
    //void Start()
    //{
    //    //keysText = Player_Text.Find("Keys").GetComponent<TextMeshProUGUI>();
    //    //keysText.text = "Keys: " + Keys;
    //}

    // Update is called once per frame
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag ("Key"))
        {
            Destroy(collision.gameObject);
            Keys++;
            keysText.text = "KEYS:" + Keys;
        }
    }
}
