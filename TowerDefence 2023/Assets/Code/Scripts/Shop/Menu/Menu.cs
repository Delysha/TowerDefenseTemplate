using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [Header("references")]
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] Animator anim;

    private bool isMenuOpen;

    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        anim.SetBool("MenuOpen", isMenuOpen);
    }

    private void OnGUI()
    {
        currencyUI.text = LevelManager.main.Currency.ToString();
    }


}
