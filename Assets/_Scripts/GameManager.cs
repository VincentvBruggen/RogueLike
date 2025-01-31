using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int moneyAmount = 5;
    public int drawCost = 5;

    public Transform startPoint;
    public List<Transform> l_Path;
    public Transform paths;

    public GameObject cardToPlace;

    [SerializeField]
    private TextMeshProUGUI moneyText;

    [SerializeField]
    private Button drawButton;

    [SerializeField]
    private GameObject enemy;

    private int enemiesThisWave = 0;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform t in paths)
        {
            l_Path.Add(t);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform t in paths)
        {
            if (!l_Path.Contains(t))
            {
                l_Path.Add(t);
            }
        }
        if (cardToPlace != null && Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

            GameObject placedCard = Instantiate(cardToPlace, mousePos, Quaternion.identity);
            placedCard.transform.position.Abs();

            if(cardToPlace.name == "Corner" || cardToPlace.name == "Straight")
            {
                placedCard.transform.SetParent(paths);
            }
            
            cardToPlace = null;
        }
        moneyText.text = moneyAmount.ToString();

        
        if(moneyAmount < drawCost)
        {
            drawButton.SetEnabled(false);
        }
        else { drawButton.SetEnabled(true); }
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < enemiesThisWave; i++)
        {
            Instantiate(enemy, startPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(2f / enemiesThisWave);
        }
    }

    public void AddEnemy()
    {
        moneyAmount += 1;
        enemiesThisWave += 1;
    }

    public void SpawnEnemies()
    {
        StartCoroutine(SpawnWave());
    }

    public void Lost()
    {

    }
}
