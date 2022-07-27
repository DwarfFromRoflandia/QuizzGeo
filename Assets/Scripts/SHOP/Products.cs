using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Products : MonoBehaviour
{

    public Button _BuyTheUsualHint;
    public Button _BuyTheFiftyFiftyHint;


    [SerializeField] private TextMeshProUGUI quantityTheUsualHintText;
    [SerializeField] private TextMeshProUGUI multiplierTheUsualHintText;
    private int quantityTheUsualHint;
    
    [SerializeField] private TextMeshProUGUI quantityTheFiftyFiftyHintText;
    [SerializeField] private TextMeshProUGUI multiplierTheFiftyFiftyHintText;
    private int quantityTheFiftyFiftyHint;


    [SerializeField] private HeartsVersionTwo _hearts;
    [SerializeField] private TimerHearts _timerHearts;

    [SerializeField] private PageSwaperShop pageSwaperShop;

    [SerializeField] private Animator animationTheUsualHint;
    [SerializeField] private Animator animationTheFiftyFiftyHint;
    [SerializeField] private Animator animationHearts;

    [SerializeField] private ShopOpenAndExit shopOpenAndExit;

    [SerializeField] private Animator quantityAnimationTheUsualHint;
    [SerializeField] private Animator quantityAnimationTheFiftyFiftyHint;

    [SerializeField] private CountGem _countGem;//œŒ—ÃŒ“–≈“‹ ¬»ƒ≈Œ ” —»ÃœÀ  Œƒ¿ œ–Œ —¬Œ…—“¬¿ GET » SET » œŒÕﬂ“‹,  ¿  œŒÀ”◊»“‹ ƒŒ—“”œ   «Õ¿◊≈Õ»ﬁ œ≈–≈Ã≈ÕÕŒ… quantityGem ¬ — –»œ“≈ CountGem, ¿ “¿ ∆≈ Œ“–≈‘¿ “Œ–»“‹ — –»œ“ PurchaseIsNotAvailable
    private PurchaseIsNotAvailable _purchaseIsNotAvailable;


    private const float  timeOnOffNumber = 1f; //¬–≈Ãﬂ –¿¡Œ“€  Œ–”“»Õ€ «¿¬»—»“ Œ“ ¬–≈Ã≈Õ» ¿Õ»Ã¿÷»» “Œ¬¿–Œ¬

    private bool coroutineBuyTheUsualHint = false;
    private bool coroutineBuyFiftyFiftyHint = false;
    
    public bool PropCoroutineBuyTheUsualHint { get { return coroutineBuyTheUsualHint; } set { coroutineBuyTheUsualHint = value; } }
    public bool PropCoroutineBuyFiftyFiftyHint { get { return coroutineBuyFiftyFiftyHint; } set { coroutineBuyFiftyFiftyHint = value; } }

    private bool isHeartsRecovered = false;
    public bool IsheartsRecovered { get { return isHeartsRecovered; } set { isHeartsRecovered = value; } }

    private void Start()
    {
        quantityTheUsualHint = 0;
        quantityTheFiftyFiftyHint = 0;

        SetDisabledTheUsualHintText();
        SetDisabledTheFiftyFiftyHintText();

        _purchaseIsNotAvailable = GetComponent<PurchaseIsNotAvailable>();

        quantityTheUsualHint = TransferTheUsualHint.transferQuantityTheUsualHint;
        quantityTheFiftyFiftyHint = TransferTheFiftyFiftyHint.transferQuantityTheFiftyFiftyHint;
    }
    private void Update()
    {
        IsCoroutineBuyTheUsualHint();
        IsCoroutineBuyFiftyFiftyHint();
        RestoringHearts();
        
        AnimationOfTheFirstProduct();
        AnimationOfTheFiftyFiftyHint();
        AnimationHearts();
    }

    
    public void ByeTheUsualHint()
    {
        Debug.Log("Bye The Usual Hint");
        SetQuantityTheUsualHint();

        StartCoroutine(CoroutineBuyTheUsualHint());
        quantityAnimationTheUsualHint.SetTrigger("ClickBTN");

        _countGem.QuantityGem -= PurchaseIsNotAvailable.PriseTheUsualHint;
    }

   public void ByeTheFiftyFiftyHint()
   {
        Debug.Log("Bye The Fifty-Fifty Hint");
        SetQuantityTheFiftyFiftyHint();

        StartCoroutine(CoroutineTheFiftyFiftyHint());
        quantityAnimationTheFiftyFiftyHint.SetTrigger("BuyTheFiftyFiftyHint");

        _countGem.QuantityGem -= PurchaseIsNotAvailable.PriseTheFiftyFiftyHint;
   }

    public void ByeHealth()
    {
        isHeartsRecovered = true;

        _timerHearts.StopTimer();
        
        Debug.Log("Bye Health");

        _countGem.QuantityGem -= PurchaseIsNotAvailable.PriseHealth;

        _hearts.HeartOneFull.fillAmount = 1;
        _hearts.HeartTwoFull.fillAmount = 1;
        _hearts.HeartThreeFull.fillAmount = 1;

    }

    private void RestoringHearts()
    {
        if (isHeartsRecovered)
        {
            _hearts.QuantityHearts = 3;
            _hearts.IsFullHearts = true;
            _hearts.IsTwoHearts = false;
            _hearts.IsOneHearts = false;
            _hearts.NoHearts = false;
        }

    }

    private void SetQuantityTheUsualHint()
    {
        quantityTheUsualHint++;
        quantityTheUsualHintText.text = quantityTheUsualHint.ToString();
        Debug.Log(" ÓÎË˜ÂÒÚ‚Ó Ó·˚˜Ì˚ı ÔÓ‰ÒÍ‡ÁÓÍ: " + quantityTheUsualHint);

    }

    private void SetQuantityTheFiftyFiftyHint()
    {
        quantityTheFiftyFiftyHint++;
        quantityTheFiftyFiftyHintText.text = quantityTheFiftyFiftyHint.ToString();
        Debug.Log(" ÓÎË˜ÂÒÚ‚Ó ÔÓ‰ÒÍ‡ÁÓÍ 50/50: " + quantityTheFiftyFiftyHint);
        
    }



    IEnumerator CoroutineBuyTheUsualHint()
    {     
        Debug.Log("Õ‡˜‡ÎÓ ÍÓÛÚËÌ˚ TheUsualHint");
        coroutineBuyTheUsualHint = true;

        SetEnabledTheUsualHintText();

        yield return new WaitForSeconds(timeOnOffNumber);

        SetDisabledTheUsualHintText();

        coroutineBuyTheUsualHint = false;
    }

    IEnumerator CoroutineTheFiftyFiftyHint()
    {
        Debug.Log("Õ‡˜‡ÎÓ ÍÓÛÚËÌ˚ TheFiftyFiftyHint");
        coroutineBuyFiftyFiftyHint = true;

        SetEnabledTheFiftyFiftyHintText();

        yield return new WaitForSeconds(timeOnOffNumber);

        SetDisabledTheFiftyFiftyHintText();

        coroutineBuyFiftyFiftyHint = false;
    }

    private void IsCoroutineBuyTheUsualHint()
    {
        if (coroutineBuyTheUsualHint)
            _BuyTheUsualHint.enabled = false;
    }

    private void IsCoroutineBuyFiftyFiftyHint()
    {
        if (coroutineBuyFiftyFiftyHint)
             _BuyTheFiftyFiftyHint.enabled = false;    
    }

    private void AnimationOfTheFirstProduct()
    {
        if (pageSwaperShop.CurrentPage == 1)
            animationTheUsualHint.SetBool("AnimationTheUsualHint", true);
        else if (shopOpenAndExit.IsShopClosed == true)
            animationTheUsualHint.SetBool("AnimationTheUsualHint", false);

    }

    private void AnimationOfTheFiftyFiftyHint()
    {
        if (pageSwaperShop.CurrentPage == 2)
            animationTheFiftyFiftyHint.SetBool("AnimationTheFiftyFiftyHint", true);
        else if (shopOpenAndExit.IsShopClosed == true)
            animationTheFiftyFiftyHint.SetBool("AnimationTheFiftyFiftyHint", false);

    }

    private void AnimationHearts()
    {
        if (pageSwaperShop.CurrentPage == 3)
            animationHearts.SetBool("AnimationHearts", true);
        else if (shopOpenAndExit.IsShopClosed == true)
            animationHearts.SetBool("AnimationHearts", false);
    }
    private void SetDisabledTheUsualHintText()
    {
        quantityTheUsualHintText.gameObject.SetActive(false);
        multiplierTheUsualHintText.gameObject.SetActive(false);
    }

    private void SetDisabledTheFiftyFiftyHintText()
    {
        quantityTheFiftyFiftyHintText.gameObject.SetActive(false);
        multiplierTheFiftyFiftyHintText.gameObject.SetActive(false);
    }

    private void SetEnabledTheUsualHintText()
    {
        quantityTheUsualHintText.gameObject.SetActive(true);
        multiplierTheUsualHintText.gameObject.SetActive(true);
    }

    private void SetEnabledTheFiftyFiftyHintText()
    {
        quantityTheFiftyFiftyHintText.gameObject.SetActive(true);
        multiplierTheFiftyFiftyHintText.gameObject.SetActive(true);
    }


    private void OnEnable()
    {
        if (TransferTheUsualHint.transferQuantityTheUsualHint != 0)
        {
            quantityTheUsualHint = TransferTheUsualHint.transferQuantityTheUsualHint;
        }
        if (TransferTheFiftyFiftyHint.transferQuantityTheFiftyFiftyHint != 0)
        {
            quantityTheFiftyFiftyHint = TransferTheFiftyFiftyHint.transferQuantityTheFiftyFiftyHint;
        }
    }

    private void OnDestroy()
    {
        TransferTheUsualHint.transferQuantityTheUsualHint = quantityTheUsualHint;
        TransferTheFiftyFiftyHint.transferQuantityTheFiftyFiftyHint = quantityTheFiftyFiftyHint;
    }




}
