using UnityEngine;
using UnityEngine.UI;

public class HotkeyInput : MonoBehaviour
{
    public InputField skillInputField; // Campo de entrada para el nombre del hechizo
    private HotkeyManager hotkeyManager;
    private string actionType; // Para identificar si es Skill1 o Skill2

    private KeyCode selectedKey;

    void Start()
    {
        hotkeyManager = FindObjectOfType<HotkeyManager>();
        skillInputField.onEndEdit.AddListener(OnEndEdit);
    }

    void Update()
    {
        // Detectar cualquier tecla mientras el InputField está enfocado
        if (Input.anyKeyDown && skillInputField.isFocused)
        {
            foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    selectedKey = key; // Guardamos la tecla seleccionada
                    skillInputField.text += $" ({key.ToString()})";
                    break;
                }
            }
        }
    }

    // Método que se llama al finalizar la edición del InputField
    private void OnEndEdit(string input)
    {
        if (!string.IsNullOrEmpty(input))
        {
            // Asignamos la habilidad al Hotkey Manager dependiendo del tipo
            if (actionType == "Skill1")
                hotkeyManager.SetSkill1Hotkey(selectedKey, input);
            else if (actionType == "Skill2")
                hotkeyManager.SetSkill2Hotkey(selectedKey, input);
        }
    }

    // Método para identificar si es Skill1 o Skill2
    public void SetActionType(string type)
    {
        actionType = type;
    }
}
