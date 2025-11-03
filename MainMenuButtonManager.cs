using UnityEngine;

public class MainMenuButtonManager : MonoBehaviour
{
  
  [SerializeField] MainMenuManager.MainMenuBottons _buttonType;
    public void ButtonClicked()
    { 
        MainMenuManager._.MainMenuButtonClicked(_buttonType);
     }
}
