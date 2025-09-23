using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessUI : MonoBehaviour
{
    int currentMember = 0;
    public int currentImageIndex = 0;

    public Text nameTxt;

    public Image frontImg;
    public Image prevImg;
    public Image nextImg;

    string[] memberNames = { "전수라", "양채윤", "황준영", "정재우", "박상현" };
    private Sprite[] memberImages;
    private int[][] imageIndex = new int[][]
    {
        new int[]{0,1,2},
        new int[]{3,4,5},
        new int[]{6,7,8},
        new int[]{9,10,11},
        new int[]{12,13,14}
    };

    void Start()
    {
        LoadSprites();
        UpdateImage();
        UpdateButtonImages();
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
            currentImageIndex = 0;

        UpdateImage();
    }

    void NextMember()
    {
        currentMember++;
        if (currentMember >= imageIndex.Length)
        { currentMember = 0; }

        currentImageIndex = 0;
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
        int imageID = imageIndex[currentMember][currentImageIndex];
        frontImg.sprite = memberImages[imageID];
    }

    void UpdateButtonImages()
    {
        int prevMember = currentMember - 1;
        if (prevMember < 0) prevMember = imageIndex.Length - 1;
        prevImg.GetComponent<Image>().sprite = memberImages[imageIndex[prevMember][0]];

        int nextMember = (currentMember + 1) % imageIndex.Length;
        nextImg.GetComponent<Image>().sprite = memberImages[imageIndex[nextMember][0]];
    }
}
