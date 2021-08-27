using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPilotSeat_Rider : MonoBehaviour
{
    public ButtonPilotSeat _bps;

    private void OnMouseDown()
    {
        if (_bps._SpaceShip.activeSelf == false)
            _bps.SpaceshipChangeover();
        else
            _bps.InteriorChangeover();
    }
}
