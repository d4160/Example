using UnityEngine;
using UnityEngine.UI;
using System;

public class ChatSystem : MonoBehaviour
{
    public GameObject messagePrefab;  // Prefab de un texto o panel de mensaje
    public Transform chatContent;     // El content del Scroll View donde se añaden los mensajes

    public void AddMessage(string characterName, string messageText)
    {
        // Crear una instancia del mensaje
        GameObject newMessage = Instantiate(messagePrefab, chatContent);
        
        // Formatear el mensaje: [NOMBRE] HH:MM Mensaje
        string timeStamp = DateTime.Now.ToString("HH:mm");
        string formattedMessage = $"[{characterName}] {timeStamp}: {messageText}";
        
        // Asignar el texto al prefab (asumiendo que tu prefab tiene un componente Text)
        Text messageComponent = newMessage.GetComponent<Text>();
        messageComponent.text = formattedMessage;
    }
}
