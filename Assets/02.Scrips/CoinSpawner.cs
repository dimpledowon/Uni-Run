using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ �����ϰ� �ֱ������� ���ġ�ϴ� ��ũ��Ʈ
public class CoinSpawner : MonoBehaviour
{
    public GameObject CoinPrefab; // ������ ������ ���� ������
    public int count = 5; // ������ ���� ��

    public float timeBetSpawnMin = 0.5f; // ���� ��ġ������ �ð� ���� �ּڰ�
    public float timeBetSpawnMax = 1f; // ���� ��ġ������ �ð� ���� �ִ�
    private float timeBetSpawn; // ���� ��ġ������ �ð� ����

    public float yMin = 3f; // ��ġ�� ��ġ�� �ּ� y��
    public float yMax = 8f; // ��ġ�� ��ġ�� �ִ� y��
    private float xPos = 20f; // ��ġ�� ��ġ�� x��

    private GameObject[] coins; // �̸� ������ ���ε�
    private int currentIndex = 0; // ����� ���� ������ ����

    // �ʹݿ� ������ ������ ȭ�� �ۿ� ���ܵ� ��ġ
    private Vector2 poolPosition = new Vector2(0, -25);
    private float lastSpawnTime; // ������ ��ġ ����
    void Start()
    {
        // count��ŭ�� ������ ������ ���ο� ���� �迭 ����
        coins = new GameObject[count];

        // count��ŭ �����ϸ鼭 ���� ����
        for (int i = 0; i < count; i++)
        {
            // CoinPrefab�� �������� �� ������ poolPosition ��ġ�� ���� ����
            // ������ ������ coins �迭�� �Ҵ�
            coins[i] = Instantiate(CoinPrefab, poolPosition, Quaternion.identity);
        }

        // ������ ��ġ ���� �ʱ�ȭ
        lastSpawnTime = 0f;
        // ������ ��ġ������ �ð� ������ 0 ���� �ʱ�ȭ
        timeBetSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // ���ӿ��� ���¿����� �������� ����
        if (GameManager.instance.isGameover)
        {
            return;
        }

        // ������ ��ġ �������� timeBetSpawn �̻� �ð��� �귶�ٸ�
        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            // ��ϵ� ������ ��ġ ������ ���� �������� ����
            lastSpawnTime = Time.time;

            // ���� ��ġ������ �ð� ������ timeBetSpawnMin, timeBetSpawnMax ���̿��� ���� ����
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            // ��ġ�� ��ġ�� ���̸� yMin�� yMax ���̿��� ���� ����
            float yPos = Random.Range(yMin, yMax);

            // ����� ���� ������ ���� ���� ������Ʈ�� ��Ȱ��ȭ�ϰ� ��� �ٽ� Ȱ��ȭ
            // �̶� ������ coin ������Ʈ�� OnEnable �޼��尡 �����
            coins[currentIndex].SetActive(false);
            coins[currentIndex].SetActive(true);

            // ���� ������ ������ ȭ�� �����ʿ� ���ġ
            coins[currentIndex].transform.position = new Vector2(xPos, yPos);
            // ���� �ѱ��
            currentIndex++;

            // ������ ������ �����ߴٸ� ������ ����
            if (currentIndex >= count)
            {
                currentIndex = 0;
            }
        }
    }
}
