using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
using Parse;

public class NGUIParseTest : MonoBehaviour
{
	public UILabel user;
	public UILabel password;
	public UILabel emailReset;
	public UILabel usernameRegister;
	public UILabel emailRegister;
	public UILabel passwordRegister;
	public UILabel repassRegister;
	public UIPlayAnimation other; //to try and use UIPlayAnimation on other gameobject to play the animation
	
	public GameObject levelLock;
	public GameObject loginPanel;
	public GameObject registrationPanel;
	public GameObject pwrecoveryPanel;
	
	private bool bLogin=false;
	public static string message = "";
	
	static string staticUser;
	
	void Start()
	{
		if (PlayerPrefs.GetInt ("UserLoggedIn") == 1)
		{
		levelLock.SetActive (false);
		loginPanel.SetActive (false);
		registrationPanel.SetActive (false);
		pwrecoveryPanel.SetActive (false);	
		}
	}
	
	
	void Update()
	{
		if (bLogin)
		{
			LoginPreferenceSet ();
			bLogin=false;
		}
	}
	
	void LoginPreferenceSet()
	{
		PlayerPrefs.SetInt("UserLoggedIn", 1);
		levelLock.SetActive (false);
		loginPanel.SetActive (false);
		registrationPanel.SetActive (false);
		pwrecoveryPanel.SetActive (false);
		message = "Took lock off";
	//	loginPanel.animation.Stop ("loginpanelup");
	//	loginPanel.animation.Play ("loginsuccess");
	//	other.
		Debug.Log(loginPanel.animation.isPlaying);
	}
	
	void PasswordReset() // If the password reset button is clicked in the PW reset panel, it should call this to reset the PW with Parse.
	{
		Task requestPasswordTask = ParseUser.RequestPasswordResetAsync(emailReset.text);
		Debug.LogError ("Password reset called");
	}
	
	void Registration()
	{
		Debug.LogError("Registration has been called");
		 if (usernameRegister.text == "Your full name" || emailRegister.text == "Your email" || repassRegister.text == "Enter password again" || usernameRegister.text == "" || emailRegister.text == "" || passwordRegister.text == "" || repassRegister.text == "")
		{
			message = "Please enter all the fields";
			Debug.LogError ("" +message);
		}
            else
            {
                if (passwordRegister.text == repassRegister.text)
                {
					Debug.LogError("Passwords Matched");
					var userCurrent = new ParseUser(){
						Username = usernameRegister.text,
						Email = emailRegister.text,
						Password = passwordRegister.text
					};
//					Debug.LogError ("" +userCurrent);
					Task signUpTask = userCurrent.SignUpAsync();
					message = "Sign up successful. Check your email for verification!";
                }
                else
		{
                   message = "Your Password does not match";
            }
	}
	}
	
	void Authentication()
	{
//		print ("user"+user+"pass"+password);
//		staticUser = user.;
		ParseUser.LogInAsync(user.text, password.text).ContinueWith(t =>
		{
			if (t.IsFaulted || t.IsCanceled)
			{
				message = "error logging in \n";
				Debug.LogError(""+t.Exception);
			}
			else
			{
				bLogin=true;
//				PlayerPrefs.SetInt("UserLoggedIn", 1);
				print ("alrity");
			}
		})
		;
	}
	
	// Update is called once per frame

}
