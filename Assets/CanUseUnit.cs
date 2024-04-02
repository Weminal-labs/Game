using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanUseUnit : MonoBehaviour
{
    [SerializeField]
    private GameObject DataMob;
    private GameObject placeHolder;
    [SerializeField]
    private RuntimeAnimatorController[] animMob;
    private List<MobStats> mobstas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadMobCanUse()
    {
        mobstas = DataMob.GetComponent<ManageMobData>().getListMob();
        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(40, mobstas.Count * 50);
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        int count = transform.childCount; 
        if(count > 1)
        {
            for (int i = 0; i < count; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        GameObject pointer;
        foreach (MobStats mob in mobstas)
        {
            pointer = Instantiate(buttonTemplate, transform);
            pointer.gameObject.SetActive(false);
            if (!mob.isInBuilding())
            {
                pointer.gameObject.SetActive(true);
                pointer.GetComponent<Image>().enabled = true;
                pointer.GetComponent<Button>().enabled = true;
                pointer.transform.GetChild(0).GetChild(0).GetComponent<Slider>().maxValue = Int32.Parse(mob.getMaxExp().ToString());
                pointer.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = Int32.Parse(mob.getExp().ToString());
                pointer.transform.GetChild(0).GetChild(1).GetComponent<Image>().enabled = true;
                pointer.transform.GetChild(0).GetChild(2).GetComponent<Image>().enabled = true;
                pointer.transform.GetChild(1).GetComponent<Image>().enabled = true;
                pointer.transform.GetChild(2).GetComponent<Image>().enabled = true;
                pointer.transform.GetChild(3).GetComponent<Image>().enabled = true;
                pointer.transform.GetChild(4).GetComponent<Image>().enabled = true;
                pointer.transform.GetChild(6).GetComponent<Image>().enabled = true;
                pointer.transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>().enabled = true;
                pointer.transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>().SetText(mob.getLevel().ToString());
                pointer.transform.GetChild(0).GetChild(4).GetComponent<TextMeshProUGUI>().SetText(mob.getExp().ToString()+"/"+mob.getMaxExp().ToString());
                pointer.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().SetText(mob.getHealth().ToString()+"/"+mob.getMaxHealth().ToString());
                pointer.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().SetText(mob.getDamage().ToString());
                pointer.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().SetText(mob.getSpeed().ToString());
                pointer.transform.GetChild(5).GetComponent<TextMeshProUGUI>().SetText(mob.getName().ToString());
                pointer.transform.GetChild(5).GetComponent<TextMeshProUGUI>().enabled = true;
                pointer.transform.GetChild(6).GetComponent<Animator>().runtimeAnimatorController = animMob[mob.getMobType()] as RuntimeAnimatorController;
                pointer.transform.GetChild(6).GetComponent<Animator>().enabled = true;
                pointer.GetComponent<UnitChosen>().setParent(this.gameObject, mob);
            }
        }
    }
    public void setPlaceHolder(GameObject place)
    {
        this.placeHolder = place;
    }
    public GameObject getPlace()
    {
        return placeHolder;
    }
}
