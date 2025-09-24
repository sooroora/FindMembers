using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int idx = 0;

    public GameObject front;
    public GameObject back;

    public Animator anim;
    public SpriteRenderer frontImage;
    public Button button;

    private GameManager gm;

    void Awake()
    {
        gm = GameManager.Instance;
    }

    void OnEnable()
    {
        anim.enabled = false;
        button.interactable = false;
    }

    public void Setting(int number)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"Sprites/member_{idx.ToString("D2")}");
    }

    public void OpenCard()
    {
        if (gm.secondCard != null) return;
        if (gm.isLock) return;

        button.interactable = false;
        AudioManager.Instance.CardFlip.Play();
        anim.SetBool("isOpen", true);

        if (gm.firstCard == null)
        {
            gm.firstCard = this;
        }
        else
        {
            gm.secondCard = this;
            gm.Matched();
        }
    }

    private void AnimFlip()
    {
        front.SetActive(true);
        back.SetActive(false);
    }

    public void DestroyCard()
    {
        StartCoroutine(DestroyCardRoutine());
    }

    IEnumerator DestroyCardRoutine()
    {
        yield return new WaitForSeconds(0.7f);
        gm.UnLock();
        button.interactable = true;
        Destroy(gameObject);
    }

    public void ClosedCard()
    {
        StartCoroutine(ClosedCardRoutine());
    }

    IEnumerator ClosedCardRoutine()
    {
        yield return new WaitForSeconds(0.7f);
        if (gm.isPlay)
        {
            gm.UnLock();
            button.interactable = true;
            anim.SetBool("isOpen", false);
            front.SetActive(false);
            back.SetActive(true);
        }
    }

    public void ActivateCard()
    {
        anim.enabled = true;
        button.interactable = true;
    }

    public void FailOpenCard()
    {
        button.interactable = false;
        anim.SetBool("isOpen", true);
    }
}
