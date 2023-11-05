using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private shooter[] shooters;

    private int SelectedShooter = 0;
    private void Awake()
    {
        main = this;
    }

    public shooter GetSelectedShooter()
    {
        return shooters[SelectedShooter];
    }

    public void SetSelectedShooter(int _selectedShooter)
    {
        SelectedShooter = _selectedShooter;
    }
}
