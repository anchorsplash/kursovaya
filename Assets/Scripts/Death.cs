using UnityEngine;
public class Death : MonoBehaviour
{
    public Vector3 respawnPosition = new Vector3(29f, 28f, -903f) ; // �������� ���������� ��� ��������

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") // �������� �� ��������������� � ����������
        {
            Invoke("Respawn", 0.1f); // �������� �������� �� �����
        }
    }

    private void Respawn()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = respawnPosition; // ����������� ��������� � �������� ����������
    }
}
