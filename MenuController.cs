using UnityEngine;
using System.Collections;

#if !UNITY_PS4
using UnityEngine.SceneManagement;
#endif

public class MenuController : MonoBehaviour
{

    public GameObject GameSelect;
    public GameObject MenuSelect;
	public GameObject OptionsSelect;
	public GameObject FadeManager;
	//public GameObject LevelTransition;

	private Animator GSanim;
    private Animator MSanim;
	private Animator OPanim;

	//public Vector3 ScreenMouse;


	private int MyRandom;
	private int SceneIndex;    

    public int waitTime = 0;

    // Initialize variables,UI panels and animators
    void Start()
    {
		SceneIndex = 0;


        MenuSelect.SetActive(true);
		OptionsSelect.SetActive(false);
        GSanim = GameSelect.GetComponent<Animator>();
		//GSanim.SetBool("GSmove", false);
		GSanim.enabled = true;
        MSanim = MenuSelect.GetComponent<Animator>();
		MSanim.SetBool("MSmoveLeft", false);
		MSanim.SetBool("MSmoveDown", false);
		//Added a comment
		MSanim.enabled = true;        
		OPanim = OptionsSelect.GetComponent<Animator>();
	//	OPanim.SetBool("OPmove", false);
		OPanim.enabled = false;
    }

	// Activate the GameSelectButtons animation and transition all buttons left
    public void OnGameSelectButtonPress()
    {       
        GameSelect.SetActive(true);
        GSanim.enabled = true;
		GSanim.SetBool("Cat2",true);
        MSanim.enabled = true;
        MSanim.SetBool("MSmoveLeft",true);     
		//Explode();

    }
    public void OnHighScoreButtonPress()
    {

    }
    public void OnOptionsButtonPress()
    {
		OptionsSelect.SetActive(true);
		OPanim.enabled = true;
		OPanim.SetBool("OPmove",true);
		MSanim.enabled = true;
		MSanim.SetBool("MSmoveDown",true); 
    }




    public void OnExitButtonPress()
    {
        Application.Quit();
    }
    public void OnTelevisionButtonPress()
    {

		SceneIndex = 1;
        StartCoroutine("StartGameEvent");
    }

    public void OnVideoGameButtonPress()
    {
		SceneIndex = 2;
		StartCoroutine("StartGameEvent");

    }
    public void OnMoviesButtonPress()
    {
		SceneIndex = 3;
		StartCoroutine("StartGameEvent");

    }

    public void OnRandomButtonPress()
    {
		MyRandom = Random.Range ((int)0, (int)3);
		if (MyRandom == 0) 
		{
			SceneIndex = 1;
		}
		else if (MyRandom == 1) 
		{
			SceneIndex = 2;
		}
		else
		{
			SceneIndex = 3;
		}
		StartCoroutine("StartGameEvent");
    }
    public void OnGSBackButtonPress()
    {
		MSanim.SetBool("MSmoveLeft",false);
		GSanim.SetBool("GSmove",false);
		//Explode ();
    }

	public void OnOPBackButtonPress()
	{
		MSanim.SetBool("MSmoveDown",false);
		OPanim.SetBool("OPmove",false);
		//Explode ();
	}

    IEnumerator StartGameEvent()
    {
		//Explode();
        yield return new WaitForSeconds(1);
        #if !UNITY_PS4
        FadeManager.GetComponent<Fading>().BeginFade(1);
        #endif
        yield return new WaitForSeconds(1);
		if (SceneIndex == 1) 
		{
			#if UNITY_PS4
			Application.LoadLevel("Television_Scene");
        #endif
        #if !UNITY_PS4
        	SceneManager.LoadScene("Television_Scene");
        #endif
        }
        else if (SceneIndex == 2) 
		{
			#if UNITY_PS4
			Application.LoadLevel("VidGame_Scene");
        #endif
        #if !UNITY_PS4
        	SceneManager.LoadScene("VidGame_Scene");
        #endif
        }
        else
		{
			#if UNITY_PS4
			Application.LoadLevel("Movie_Scene");
        #endif
        #if !UNITY_PS4
        	SceneManager.LoadScene("Movie_Scene");
        #endif
        }
    }

	// Button press effect test function

	private void Explode()
	{
		//LevelTransition.SetActive(true);
		//ScreenMouse = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x,Input.mousePosition.y,0));
		//Instantiate(LevelTransition, ScreenMouse, Quaternion.identity);
		//LevelTransition.SetActive (false);
	}
}
