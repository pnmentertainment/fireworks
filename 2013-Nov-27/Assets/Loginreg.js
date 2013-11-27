private var formUserName = ""; //this is the field where the player will put the name to login

private var formEmail = ""; //the field where the player will put in their email

private var formPassword = ""; //this is his password

var formText = ""; //this field is where the messages sent by PHP script will be in


var URL = "http://yoursite.com/check_scoresR.php"; //change for your URL

var hash = "hashcode"; //change your secret code, and remember to change into the PHP file too

 

private var textrect = Rect (10, 150, 500, 500); //just make a GUI object rectangle

 

function OnGUI() {

    GUI.Label( Rect (10, 10, 80, 20), "Your user name:" ); //text with your username
    
    GUI.Label( Rect (10, 20, 80, 20), "Your email:" );

    GUI.Label( Rect (10, 30, 80, 20), "Your pass:" );

 

    formUserName = GUI.TextField ( Rect (90, 10, 100, 20), formUserName ); //here you will insert the new value to variable formUserName

    formEmail = GUI.TextField ( Rect (90, 20, 100, 20), formEmail ); // as above for email
    
    formPassword = GUI.TextField ( Rect (90, 30, 100, 20), formPassword ); //same as above, but for password

 

    if ( GUI.Button ( Rect (10, 60, 100, 20) , "Register" ) ){ //just a button

        Register();

    }

    GUI.TextArea( textrect, formText );

}

 

function Register() {

	

    }

 

    formUserName = ""; //just clean our variables

    formPassword = "";

