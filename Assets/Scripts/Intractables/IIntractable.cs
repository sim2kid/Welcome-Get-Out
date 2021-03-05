using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IIntractable
{
    void UpdateMouseState(ClickType clickType, Vector2 location);
    void OnLeave(ClickType clickType);
    void OnEnter(ClickType clickType);
    void OnClick();
    void OnUnclick();
    void OnFullClick();
}
