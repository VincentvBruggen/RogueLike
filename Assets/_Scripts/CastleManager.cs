using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CastleManager : MonoBehaviour
{
    public UnityEvent CastleDeath;

    [Header("References")]
    [SerializeField] TextMeshProUGUI healthVisual;

    private Health healthScript;

    private void Start()
    {
        healthScript = GetComponent<Health>();
    }
    public void GotHurt()
    {
        healthVisual.text = healthScript.GetHpStatus().ToString();
    }

    public void Died()
    {
        CastleDeath.Invoke();
    }
}
