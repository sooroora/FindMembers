using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessUI : MonoBehaviour
{
    int currentMember = 0;      //ȭ�鿡 ���̴� ���(0~4)
    public int currentImageIndex = 0;       //ȭ�鿡 ���̴� �̹��� �ε���(0~2)

    public Text nameTxt;

    public Image frontImg;
    public Image prevImg;
    public Image nextImg;  //�� �̹����� ������ �� �ֵ��� �ҷ���

    string[] memberNames = { "������", "��ä��", "Ȳ�ؿ�", "�����", "�ڻ���" };
    private Sprite[] memberImages;      //��ü ��������Ʈ�� ������ �迭
    private int[][] imageIndex = new int[][]
    {
        new int[]{0,1,2},
        new int[]{3,4,5},
        new int[]{6,7,8},
        new int[]{9,10,11},
        new int[]{12,13,14}
    };          //0~4�� ���� �̹��� 3���� �Ҵ�

    private void Awake()
    {
        LoadSprites();      //��� ��������Ʈ �ҷ�����
    }
    void Start()
    {
        UpdateImage();      //���� ��� �̹��� ǥ��
        UpdateButtonImages();       //����, ���� ��� �̹��� ������Ʈ
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
            currentImageIndex = 0;      //������ �̹��� �Ѿ�� �ٽ� 0����

        UpdateImage();
    }

    void NextMember()
    {
        currentMember++;
        if (currentMember >= imageIndex.Length)
        { currentMember = 0; }

        currentImageIndex = 0;      //�� ��� ���� �� �ٽ� 0����
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
        int imageID = imageIndex[currentMember][currentImageIndex];     //���� ����� ���� �̹��� �ε���
        Debug.Log(frontImg);
        Debug.Log(memberImages[imageID]);
        frontImg.sprite = memberImages[imageID];    //�߾� �̹����� ��������Ʈ ����
    }

    void UpdateButtonImages()
    {
        int prevMember = currentMember - 1;
        if (prevMember < 0) prevMember = imageIndex.Length - 1;     //0������ �������� ���ư��� �� ��� ������ ����� ���ư�
        prevImg.sprite = memberImages[imageIndex[prevMember][0]];   //���� ��� ù��° �̹��� ǥ��

        int nextMember = (currentMember + 1) % imageIndex.Length;   //(���� �ε���+1) / 5�� ������ = ���� ���
        nextImg.sprite = memberImages[imageIndex[nextMember][0]];   //���� ��� ù��° �̹��� ǥ��
    }

    public void SetMember(int memberIndex) //MemberUI���� Ư�� ��� ���� �� ���
    {
        currentMember = memberIndex;    //��� ��ȣ ����
        currentImageIndex = 0;          //�̹��� �ε��� �ʱ�ȭ
        UpdateImage();
        UpdateButtonImages();   
    }
}
