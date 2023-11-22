using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PointsCounter pointsCounter;

    private NavMeshAgent agent;
    private int points;

    private GameObject deathTextGO;
    private TextMeshProUGUI deathText;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        points = 0;
        deathTextGO = GameObject.Find("DiedText");
        deathText = deathTextGO.GetComponent<TextMeshProUGUI>();
        deathTextGO.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(YouLose());
        }
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Points"))
        {
            pointsCounter.Collision();
            points++;

            if (points == 60)
            {
                StartCoroutine(EndGame());
            }
        }
    }

    IEnumerator YouLose()
    {
        deathTextGO.SetActive (true);
        this.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3);
        Time.timeScale = 0;
    }
}

