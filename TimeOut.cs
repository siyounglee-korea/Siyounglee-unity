using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeOut : MonoBehaviour
{
    private int iminTime = 1;

    public Recipe recipe;
    public Recipe recipeClone;
    private List<Recipe> RecipeList = new List<Recipe>();

    public List<Recipe> GetRecipeList()
    {
        return RecipeList;
    }

    [SerializeField] Text TimerText;

    void Start()
    {
        TimerText = GetComponent<Text>();
    }

    void Update()
    {
        Show_TimerTextUI();
        Add_Recipe();
    }

    private void Add_Recipe()
    {
        fRecipeAddTime += Time.deltaTime;

        if (fRecipeAddTime >= RECIPETIME)
        {
            fRecipeAddTime = 0f;
            RecipeList.Add(recipeClone = Instantiate(recipe));
        }

        for (int i = 0; i < RecipeList.Count; i++)
        {
            if (i == 0)
                RecipeList[0].fAddRecipeX = RecipeList[i].myWidth;
            else
                RecipeList[i].fAddRecipeX = (i * RecipeList[i].myWidth) + ((i + 1) * (RecipeList[i].myWidth));
        }
    }

    private void Show_TimerTextUI()
    {
        if (SECTIME != 0)
        {
            SECTIME -= Time.deltaTime;
            if (SECTIME <= 0)
            {
                SECTIME = 60;
                if (iminTime > 0)
                    iminTime--;
                else
                    iminTime = 0;
            }
        }
        int sec = Mathf.FloorToInt(SECTIME);

        if (sec >= TIMERSEC)
            TimerText.text = "0" + iminTime.ToString() + ":" + sec.ToString();
        else
            TimerText.text = "0" + iminTime.ToString() + ":" + "0" + sec.ToString();
    }

    void LateUpdate()
    {
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(SCENETIME);
        Application.LoadLevel("NEXTSTAGE");
    }
}
