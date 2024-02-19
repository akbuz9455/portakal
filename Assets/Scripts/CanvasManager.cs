using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    public TextMeshProUGUI kullaniciAdi;
    public TMP_InputField sifre;

    public TextMeshProUGUI kayitKullaniciAdi;
    public TMP_InputField kayitSifre;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }
    public string RemoveInvisibleCharacters(string input)
    {
        // Unicode görünmez karakterleri ve kontrol karakterlerini tanýmlayan bir Regex deseni
        var regex = new Regex(@"[\p{Cf}\p{Cc}]");

        // Görünmez karakterleri kaldýr
        var cleanedInput = regex.Replace(input, string.Empty);

        return cleanedInput;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
