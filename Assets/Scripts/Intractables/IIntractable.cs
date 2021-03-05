using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IIntractable
{
    void UpdateMouseState(ClickType clickType);
    void OnLeave(ClickType clickType);
    void OnEnter(ClickType clickType);
    void OnClick();
    void OnUnclick();
}
