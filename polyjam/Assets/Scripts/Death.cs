using UnityEngine;
public class Death : MonoBehaviour
{
    public Vector3 respawnPosition = new Vector3(29f, 28f, -903f) ; // заданные координаты для респавна

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") // проверка на соприкосновение с персонажем
        {
            Invoke("Respawn", 0.1f); // задержка респавна на время
        }
    }

    private void Respawn()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = respawnPosition; // перемещение персонажа в заданные координаты
    }
}
