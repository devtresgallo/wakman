using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsCounter : MonoBehaviour
{
    private float points;
    private TextMeshProUGUI ptsText;
    private GameObject winTextGO;

    [SerializeField] private TextMeshProUGUI winText;

    private void Start()
    {
        points = 0;
        ptsText = GetComponent<TextMeshProUGUI>();
        winTextGO = GameObject.Find("WinText");
        winText = winTextGO.GetComponent<TextMeshProUGUI>();
        winTextGO.SetActive(false);
        ptsText.text = "Puntos: " + points.ToString("0");
    }

    private void Update()
    {
        ptsText.text = "Puntos: " + points.ToString("0");
        if (points == 60)
        {
            winTextGO.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Collision()
    {
        points++;
    }
}
