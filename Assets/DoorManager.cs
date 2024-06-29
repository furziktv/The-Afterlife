using System;
using System.Collections;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] private DoorOpener[] _doorOpeners;
    [SerializeField] private int[] _doorLevelOpened;
    private PlayerHP _playerHp;

    private void Start()
    {
        _playerHp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHP>();
        StartCoroutine(DoorOpener());
    }

    

    private IEnumerator DoorOpener()
    {
        while (true)
        {
            for (int i = 0; i < _doorOpeners.Length; i++)
            {
                if (_playerHp.Level() >= _doorLevelOpened[i])
                {
                    _doorOpeners[i].DoorOpen();
                }
                else
                {
                    _doorOpeners[i].DoorClose();
                }
            }

            yield return new WaitForSeconds(5);
        }
    }
}
