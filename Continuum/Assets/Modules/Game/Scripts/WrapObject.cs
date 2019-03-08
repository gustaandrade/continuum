using System.Collections;
using UnityEngine;

public class WrapObject : MonoBehaviour
{
    private void Update()
    {
        ScreenWrap();
    }

    private void ScreenWrap()
    {
        var shipPosition = Camera.main.WorldToViewportPoint(transform.position);
        var newPosition = transform.position;

        if (shipPosition.x > 1)
            newPosition.x = -newPosition.x + GameVariables.Instance.PlayerScreenWrapOffset;
        else if (shipPosition.x < 0)
            newPosition.x = -newPosition.x - GameVariables.Instance.PlayerScreenWrapOffset;

        if (shipPosition.y > 1)
            newPosition.y = -newPosition.y + GameVariables.Instance.PlayerScreenWrapOffset;
        else if (shipPosition.y < 0)
            newPosition.y = -newPosition.y - GameVariables.Instance.PlayerScreenWrapOffset;

        transform.position = newPosition;
    }
}
