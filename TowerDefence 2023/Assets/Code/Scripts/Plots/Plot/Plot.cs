using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color HoverColor;

    private GameObject shooter;
    private Color startColor;


    private void Start()
    {
        startColor = sr.color;
    }
    private void OnMouseEnter()
    {
        sr.color = HoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if ( shooter != null) return;

        shooter shooterTobuild = BuildManager.main.GetSelectedShooter();

        if ( shooterTobuild.cost > LevelManager.main.Currency ) 
        {
            Debug.Log("you can't afford this tower");
            return;

        }

        LevelManager.main.SpendCurrency( shooterTobuild.cost );

        shooter shooterToBuild= BuildManager.main.GetSelectedShooter();
        shooter = Instantiate( shooterToBuild.prefab, transform.position,Quaternion.identity);
    }
}
