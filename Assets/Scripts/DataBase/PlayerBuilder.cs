using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBuilder : MonoBehaviour
{
    [SerializeField] private Renderer main_1, main_2, main_3, main_4, main_5, main_6, main_7, main_8, main_9, main_10;
    [SerializeField] private Renderer main_11, main_12, main_13, main_14, main_15, main_16, main_17, main_18, main_19, main_20, main_21;
    [SerializeField] private Renderer second_1, second_2;
    [SerializeField] private TMP_Text nicknameT;



    public void ChangeMainColor(Palette color)
    {
        main_1.material.color = color.GetColor();
        main_2.material.color = color.GetColor();
        main_3.material.color = color.GetColor();
        main_4.material.color = color.GetColor();
        main_5.material.color = color.GetColor();
        main_6.material.color = color.GetColor();
        main_7.material.color = color.GetColor();
        main_8.material.color = color.GetColor();
        main_9.material.color = color.GetColor();
        main_10.material.color = color.GetColor();
        main_11.material.color = color.GetColor();
        main_12.material.color = color.GetColor();
        main_13.material.color = color.GetColor();
        main_14.material.color = color.GetColor();
        main_15.material.color = color.GetColor();
        main_16.material.color = color.GetColor();
        main_17.material.color = color.GetColor();
        main_18.material.color = color.GetColor();
        main_19.material.color = color.GetColor();
        main_20.material.color = color.GetColor();
        main_21.material.color = color.GetColor();
        WebManager.userData.playerData.SetMainColor(JsonUtility.ToJson(color.GetColor()));
    }
    public void ChangeSecondColor(Palette color)
    {
        second_1.material.color = color.GetColor();
        second_2.material.color = color.GetColor();
        WebManager.userData.playerData.SetSecondColor(JsonUtility.ToJson(color.GetColor()));
    }
    public void ChangeNickName(TMP_Text newName)
    {
        nicknameT.text = newName.text;
        WebManager.userData.playerData.nickname = newName.text;
    }
}