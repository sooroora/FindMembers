using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    // 카드 번호 (짝 맞추기 비교용)
    public int idx = 0;

    // 카드 앞/뒤 GameObject
    public GameObject front;
    public GameObject back;

    // 카드 애니메이션 담당
    public Animator anim;
    // 카드 앞면 이미지 (Sprite 변경)
    public SpriteRenderer frontImage;
    // 카드 클릭 버튼
    public Button button;

    // 게임 매니저 싱글톤 참조
    private GameManager gm;

    void Awake()
    {
        // 게임 시작 시 GameManager.Instance를 가져옴
        gm = GameManager.Instance;
    }

    // 카드가 활성화될 때(씬에 생성되거나 SetActive(true) 시)
    // 애니메이션을 잠시 끄고 버튼도 비활성화 (초기 세팅 중 클릭 방지)
    void OnEnable()
    {
        anim.enabled = false;
        button.interactable = false;
    }

    // 카드 번호에 따라 앞면 이미지를 설정
    public void Setting(int number)
    {
        idx = number; // 카드 번호 저장
        // Resources/Sprites 폴더에서 "member_01", "member_02" ... 형태로 이미지 불러오기
        frontImage.sprite = Resources.Load<Sprite>($"Sprites/member_{idx.ToString("D2")}");
    }

    // 카드가 클릭되었을 때 호출되는 함수 (버튼 이벤트로 연결)
    public void OpenCard()
    {
        // 이미 secondCard가 선택되어 있다면 더 이상 열 수 없음
        if (gm.secondCard != null) return;
        // 잠금 상태(카드 판정 중)일 때 열 수 없음
        if (gm.isLock) return;

        // 중복 클릭 방지를 위해 버튼 비활성화
        button.interactable = false;
        // 카드 뒤집는 효과음 실행
        AudioManager.Instance.PlayOneShot("CardFlip");
        // 뒤집히는 애니메이션 실행
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        // GameManager에 첫 번째 카드로 등록
        if (gm.firstCard == null)
        {
            gm.firstCard = this;
        }
        else
        {
            // 이미 첫 번째 카드가 있다면 두 번째 카드로 등록
            gm.secondCard = this;
            // 두 장의 카드가 모두 선택되었으므로 짝 맞추기 로직 실행
            gm.Matched();
        }
    }

    // 애니메이션 이벤트에서 호출됨
    // (카드가 뒤집힐 때 front 활성화, back 비활성화)
    private void AnimFlip()
    {
        front.SetActive(true);
        back.SetActive(false);
    }
    }*/

    // 카드를 제거하는 함수 (외부에서 호출 → 코루틴 실행)
    public void DestroyCard()
    {
        StartCoroutine(DestroyCardRoutine());
    }

    // 카드 제거 코루틴 (짝이 맞았을 때 실행)
    IEnumerator DestroyCardRoutine()
    {
        yield return new WaitForSeconds(0.7f); // 카드를 잠시 보여준 후 실행
        gm.UnLock();                           // 잠금 해제
        button.interactable = true;            // 버튼 다시 활성화 (다른 카드 선택 가능)
        Destroy(gameObject);                   // 카드 오브젝트 파괴
    }

    // 카드를 다시 닫는 함수 (외부에서 호출 → 코루틴 실행)
    public void ClosedCard()
    {
        StartCoroutine(ClosedCardRoutine());
    }

    // 카드 닫기 코루틴 (짝이 맞지 않았을 때 실행)
    IEnumerator ClosedCardRoutine()
    {
        yield return new WaitForSeconds(0.7f); // 카드를 잠시 보여준 후 실행
        if (gm.isPlay) // 게임이 진행 중일 때만 실행
        {
            gm.UnLock();                       // 잠금 해제
            button.interactable = true;        // 다시 선택 가능
            anim.SetBool("isOpen", false);     // 닫히는 애니메이션 실행
            front.SetActive(false);            // 앞면 비활성화
            back.SetActive(true);              // 뒷면 활성화
        }
    }

    // 카드 활성화 (게임 시작 시 모든 카드 준비용)
    public void ActivateCard()
    {
        anim.enabled = true;       // 애니메이션 켜기
        button.interactable = true; // 버튼 활성화
    }

    // 게임 패배 시 카드를 뒤집힌 상태로 유지
    public void FailOpenCard()
    {
        button.interactable = false;  // 선택 불가
        anim.SetBool("isOpen", true); // 열린 상태 유지
    }
}
