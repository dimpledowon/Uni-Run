using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject[] obstacles; // ��ֹ� ������Ʈ��
    private bool coinget = false; // �÷��̾� ĳ���Ͱ� ��Ҿ��°�

    // ������Ʈ�� Ȱ��ȭ�ɶ� ���� �Ź� ����Ǵ� �޼���
    private void OnEnable()
    {
        // ���� ���¸� ����
        coinget = false;

        // ��ֹ��� ���� ��ŭ ����
        for (int i = 0; i < obstacles.Length; i++)
        {
            // ���� ������ ������ 1/2�� Ȯ���� Ȱ��ȭ
            if (Random.Range(0, 1) == 0)
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹�� ������ �±װ� Player && ������ �÷��̾� ĳ���Ͱ� ���� �ʾҴٸ�
        if (collision.collider.tag == "Player" && !coinget)
        {
            // ������ �߰��ϰ�, ���� ���¸� ������ ����
            coinget = true;
            GameManager.instance.AddScore(5);

            Destroy(gameObject);
        }
    }
}