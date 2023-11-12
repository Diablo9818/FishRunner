using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.WebUtility;

public class DeviceChecker : MonoBehaviour
{
    [SerializeField] private GameObject _moveButtons;
    [SerializeField] private PlayerInput _playerInput;
    private void Start()
    {
        if (Device.IsMobile)
        {
            _moveButtons.SetActive(true);
            _playerInput.enabled = false;
        }
        else
        {
            _moveButtons.SetActive(false);
            _playerInput.enabled = true;
        }
    }

}
