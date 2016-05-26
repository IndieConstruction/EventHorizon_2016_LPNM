using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameOverComponent : MonoBehaviour {

    bool isActive;
    public bool IsActive {

        get { return isActive; }
        set {
            //if (isActive != value){
                if (State == GameOverState.Lost){
                    TitleText.text = "You Lost!!";
                    NextLevelButton.gameObject.SetActive(false);
                    RestartLevleButton.gameObject.SetActive(true);
                }
                else
                {
                    TitleText.text = "YouWin!!";
                    NextLevelButton.gameObject.SetActive(true);
                    RestartLevleButton.gameObject.SetActive(false);
                }
                GetComponent<Animator>().SetBool("IsActive", isActive);
           // }
            isActive = value;
        }
    }
    public enum GameOverState{ Win,Lost}
    public GameOverState State;
    public Text TitleText;
    public Button NextLevelButton;
    public Button RestartLevleButton;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Logica
    public void SetWindowsVisible(bool _visible) {
        IsActive = _visible;

    }
}
