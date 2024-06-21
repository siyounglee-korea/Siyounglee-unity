using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recipe : MonoBehaviour
{
    RectTransform rcTrans;

    private GameObject player;
    public CoinPlus coinPlus;
    public CoinPlus coinPlusClone;

    [SerializeField] public Vector3 vUIPos;
    [SerializeField] public float fAddRecipeX = 0f;
    [SerializeField] public bool m_bIsDead = false;
    [SerializeField] public bool m_bIsClear = false;
    [SerializeField] public float myWidth = 0f;
    [SerializeField] public float myHeight = 0f;

    public FishRecipeIcon fishrecipeIcon;
    public FishRecipeIcon fishrecipeIconClone;

    private bool m_bIsCoin = false;
    private bool m_bIsAlreadyCoin = false;

    private void Awake()
    {
        vUIPos = new Vector3(Screen.width * RATIOX, Screen.height, 0f);
        this.GetComponent<RectTransform>().SetParent(GameObject.Find("Canvas").GetComponent<RectTransform>(), false);
    }

    void Start()
    {
        SetRecipePos();
        player = GameObject.FindWithTag("Player");

        fishrecipeIconClone = Instantiate(fishrecipeIcon, transform.position, Quaternion.identity);
        fishrecipeIconClone.gameObject.SetActive(false);
    }

    private void SetRecipePos()
    {
        rcTrans = GetComponent<RectTransform>();
        myWidth = transform.gameObject.GetComponent<RectTransform>().rect.width;
        myHeight = transform.gameObject.GetComponent<RectTransform>().rect.height;
        this.rcTrans.position = vUIPos;
    }

    void Update()
    {
        vUIPos.x = fAddRecipeX;
        fishrecipeIconClone.gameObject.SetActive(true);

        this.rcTrans.position = vUIPos;

        SetIconPos();
    }

    private void SetIconPos(float fPosX, float fPosY)
    {
        float IconX = vUIPos.x + myWidth * fPosX;
        float IconY = vUIPos.y - myHeight * fPosY;
       
        if (!fishrecipeIconClone.m_bIsDead)
        {
            fishrecipeIconClone.vUIPos.x = IconX;
            fishrecipeIconClone.vUIPos.y = IconY;
        }
    }

    void CoinUpdate(float fCoinPrice)
    {
        SetRecipePos();
        if(m_bIsDead && !m_bIsAlreadyCoin && m_bIsCoin)
        {
            player.GetComponent<Player>().SetPlusCoin(fCoinPrice);
            player.GetComponent<Player>().SetAddCoin(fCoinPrice);

            coinPlusClone = Instantiate(coinPlus);
            m_bIsAlreadyCoin = true;
        }
    }

    void LateUpdate()
    {
        StartCoroutine(DeadRecipe());

        if(m_bIsDead || m_bIsClear)
            Destroy(this.gameObject);
    }

    IEnumerator DeadRecipe()
    {
        if (!m_bIsDead)
        {
            yield return new WaitForSeconds(DESTROYTIME);
            if (!m_bIsCoin)
                m_bIsCoin = true;
                
            m_bIsDead = true;
        }       
    }
}
