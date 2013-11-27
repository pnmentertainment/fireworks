using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
using Parse;

public class parsetest : MonoBehaviour {

	public static string user = "", email = "";
    private string password = "", rePass = "", message = ""; 

    private bool register = false;

    private void OnGUI()
    {
        if (message != "")
            GUILayout.Box(message);

        if (register)
        {
            GUILayout.Label("Username");
            user = GUILayout.TextField(user);
            GUILayout.Label("Email");
            email = GUILayout.TextField(email);
            GUILayout.Label("password");
            password = GUILayout.PasswordField(password, "*"[0]);
            GUILayout.Label("Re-password");
            rePass = GUILayout.PasswordField(rePass, "*"[0]);

            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Back"))
                register = false;

            if (GUILayout.Button("Register"))
            {
                message = "";

                if (user == "" || email == "" || password == "")
                    message += "Please enter all the fields \n";
                else
                {
                    if (password == rePass)
                    {
						var userCurrent = new ParseUser(){
							Username = user,
							Email = email,
							Password = password
						};
						Task signUpTask = userCurrent.SignUpAsync();
                    }
                    else
                        message += "Your Password does not match \n";
                }
            }

            GUILayout.EndHorizontal();
        }
        else
        {
            GUILayout.Label("User:");
            user = GUILayout.TextField(user);
            GUILayout.Label("Password:");
            password = GUILayout.PasswordField(password, "*"[0]);

            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Login")) //Login section
            {
                message = "";

                if (user == "" || password == "")
                    message += "Please enter all the fields \n";
                else
                {
					ParseUser.LogInAsync(user, password).ContinueWith(t =>
					{
						if (t.IsFaulted || t.IsCanceled)
						{
							message += t.Exception;
						}
						else
						{
							message = "Login was successful \n";
							LoginPreferenceSet ();
							//userLoggedIn = true;
						}
					})
              ;
				//	PlayerPrefs.SetInt("UserLoggedIn", 1);
					
            }
			}

            if (GUILayout.Button("Register"))
                register = true;

            GUILayout.EndHorizontal();
        }
    }

	void LoginPreferenceSet () {
				PlayerPrefs.SetInt("UserLoggedIn", 1);
				Debug.Log("Logged in preference set");
	}
	// Use this for initialization
	//void Start () {
	

		
//	ParseObject testObject = new ParseObject("TestObject");
	//testObject["foo"] = "bar";
//	testObject.SaveAsync();
//	}
	
	// Update is called once per frame
//	void Update () {
	//	if (userLoggedIn == true)
	//	{
//			PlayerPrefs.SetInt("UserLoggedIn", 1);
//			Debug.Log("Logged in preference set");
//		}
			
	
//	}
}