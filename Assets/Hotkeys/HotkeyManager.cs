using TMPro; 
using UnityEngine;
using UnityEngine.UI;

public class HotkeyManager : MonoBehaviour
{
    
    public TextMeshProUGUI skill1Text; // Texto para la habilidad 1
    public TextMeshProUGUI skill2Text; // Texto para la habilidad 2
    private string skill1Name = "Exura Hur";
    private string skill2Name = "Exura Frigo";
    
    private KeyCode skill1Hotkey = KeyCode.A;
    private KeyCode skill2Hotkey = KeyCode.S;

    void Update()
    {
        if (Input.GetKeyDown(skill1Hotkey))
        {
            ExecuteSkill(skill1Name);
        }

        if (Input.GetKeyDown(skill2Hotkey))
        {
            ExecuteSkill(skill2Name);
        }
    }

    public void SetSkill1Hotkey(KeyCode newKey, string skillName)
    {
        skill1Hotkey = newKey;
        skill1Name = skillName;
        skill1Text.text = $"{skillName} ({newKey.ToString()})";
    }

    public void SetSkill2Hotkey(KeyCode newKey, string skillName)
    {
        skill2Hotkey = newKey;
        skill2Name = skillName;
        skill2Text.text = $"{skillName} ({newKey.ToString()})";
    }

    // Simulación de la ejecución de una habilidad
    private void ExecuteSkill(string skillName)
    {
        Debug.Log($"{skillName} activado!");
        // Aquí puedes llamar a la función que activa la habilidad real
    }
}
