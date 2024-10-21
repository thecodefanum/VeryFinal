using TMPro;
using UnityEngine;

public class CoinRenderer : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    public int coinValue = 1;

    // Start is called before the first frame update
    private void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        textMeshPro.text = coinValue.ToString();
    }
}