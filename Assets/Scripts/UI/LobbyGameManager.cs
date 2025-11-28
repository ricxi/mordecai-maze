using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyGameManager : MonoBehaviour
{
    public static LobbyGameManager Instance;
    public bool _isBellCancelled;
    public bool IsBellCancelled => _isBellCancelled;

    private void Awake()
    {
        if (!Instance) Instance = this;
        _isBellCancelled = false;
    }

    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }

    public void CancelBellSound()
    {
        _isBellCancelled = true;
    }

    public void ResetSounds()
    {
        _isBellCancelled = false;
    }

    public void ResetInstance()
    {
        ResetSounds();
    }
}
