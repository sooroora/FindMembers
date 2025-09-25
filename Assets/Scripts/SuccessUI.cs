using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessUI : MonoBehaviour
{
    int currentMember = 0;      //화면에 보이는 멤버(0~4)
    public int currentImageIndex = 0;       //화면에 보이는 이미지 인덱스(0~2)

    public Text nameTxt;

    public Image frontImg;
    public Image prevImg;
    public Image nextImg;  //각 이미지에 연결할 수 있도록 불러옴

    string[] memberNames = { "전수라", "양채윤", "황준영", "정재우", "박상현" };
    private Sprite[] memberImages;      //전체 스프라이트를 저장할 배열
    private int[][] imageIndex = new int[][]
    {
        new int[]{0,1,2},
        new int[]{3,4,5},
        new int[]{6,7,8},
        new int[]{9,10,11},
        new int[]{12,13,14}
    };          //0~4에 각각 이미지 3개씩 할당

    private void Awake()
    {
        LoadSprites();      //모든 스프라이트 불러오기
    }
    void Start()
    {
        UpdateImage();      //현재 멤버 이미지 표시
        UpdateButtonImages();       //이전, 다음 멤버 이미지 업데이트
        frontImg.GetComponent<Button>().onClick.AddListener(ChangeImage);
        prevImg.GetComponent<Button>().onClick.AddListener(PrevMember);
        nextImg.GetComponent<Button>().onClick.AddListener(NextMember);
    }
    void Update()
    {
        nameTxt.text = memberNames[currentMember];
    }
    void LoadSprites()
    {
        memberImages = new Sprite[15];
        for (int i = 0; i < 15; i++)
        {
            memberImages[i] = Resources.Load<Sprite>("Sprites/member_" + i.ToString("D2"));
        }
    }
    void ChangeImage()
    {
        currentImageIndex++;
        if (currentImageIndex >= imageIndex[currentMember].Length)
            currentImageIndex = 0;      //마지막 이미지 넘어가면 다시 0으로

        UpdateImage();
    }

    void NextMember()
    {
        currentMember++;
        if (currentMember >= imageIndex.Length)
        { currentMember = 0; }

        currentImageIndex = 0;      //새 멤버 선택 시 다시 0부터
        UpdateImage();
        UpdateButtonImages();
    }
    void PrevMember()
    {
        currentMember--;
        if (currentMember < 0)
        { currentMember = imageIndex.Length - 1; }

        currentImageIndex = 0;
        UpdateImage();
        UpdateButtonImages();
    }
    void UpdateImage()
    {
        int imageID = imageIndex[currentMember][currentImageIndex];     //현재 멤버의 현재 이미지 인덱스
        Debug.Log(frontImg);
        Debug.Log(memberImages[imageID]);
        frontImg.sprite = memberImages[imageID];    //중앙 이미지에 스프라이트 적용
    }

    void UpdateButtonImages()
    {
        int prevMember = currentMember - 1;
        if (prevMember < 0) prevMember = imageIndex.Length - 1;     //0번에서 이전으로 돌아가려 할 경우 마지막 멤버로 돌아감
        prevImg.sprite = memberImages[imageIndex[prevMember][0]];   //이전 멤버 첫번째 이미지 표시

        int nextMember = (currentMember + 1) % imageIndex.Length;   //(현재 인덱스+1) / 5의 나머지 = 다음 멤버
        nextImg.sprite = memberImages[imageIndex[nextMember][0]];   //다음 멤버 첫번째 이미지 표시
    }

    public void SetMember(int memberIndex) //MemberUI에서 특정 멤버 지정 시 사용
    {
        currentMember = memberIndex;    //멤버 번호 지정
        currentImageIndex = 0;          //이미지 인덱스 초기화
        UpdateImage();
        UpdateButtonImages();   
    }
}
