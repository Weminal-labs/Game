using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] lockHero;
    public GameObject pageMain, pageHero;
    public Button pInfo, pHero;
    public ChoseHero heroControll;
    // Start is called before the first frame update
    void Start()
    {
        StaticLobbySend.numHero = 0;
        for (int i = 0; i < lockHero.Length; i++)
        {
            lockHero[i].gameObject.SetActive(heroControll.GetLock()[i]);
        }
        pInfo.onClick.AddListener(setPageMain);
        pHero.onClick.AddListener(setPageHero);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setPageMain()
    {
        pageMain.SetActive(true);
        pageHero.SetActive(false);
    }
    public void setPageHero()
    {
        pageMain.SetActive(false);
        pageHero.SetActive(true);
    }
    public void upDateLock()
    {
        for (int i = 0; i < lockHero.Length; i++)
        {
            lockHero[i].gameObject.SetActive(heroControll.GetLock()[i]);
        }
    }
    public void mapGoblin()
    {
        StaticLobbySend.numMap = 0;
        SceneManager.LoadScene(2);
    }
    public void mapSkeleton()
    {
        StaticLobbySend.numMap = 1;
        SceneManager.LoadScene(2);
    }
    public void mapTNT()
    {
        StaticLobbySend.numMap = 2;
        SceneManager.LoadScene(2);
    }
    public void mapArmorOrc()
    {
        StaticLobbySend.numMap = 3;
        SceneManager.LoadScene(2);
    }
    public void mapEliteOrc()
    {
        StaticLobbySend.numMap = 4;
        SceneManager.LoadScene(2);
    }

}