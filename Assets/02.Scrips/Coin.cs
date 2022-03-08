using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject[] obstacles; // 장애물 오브젝트들
    private bool coinget = false; // 플레이어 캐릭터가 밟았었는가

    // 컴포넌트가 활성화될때 마다 매번 실행되는 메서드
    private void OnEnable()
    {
        // 밟힘 상태를 리셋
        coinget = false;

        // 장애물의 개수 만큼 루프
        for (int i = 0; i < obstacles.Length; i++)
        {
            // 현재 순번의 코인을 1/2의 확률로 활성화
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
        // 충돌한 상대방의 태그가 Player && 이전에 플레이어 캐릭터가 밟지 않았다면
        if (collision.collider.tag == "Player" && !coinget)
        {
            // 점수를 추가하고, 밟힘 상태를 참으로 변경
            coinget = true;
            GameManager.instance.AddScore(5);

            Destroy(gameObject);
        }
    }
}