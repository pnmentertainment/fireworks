#pragma strict

var debugObjects : GameObject[];

var debugObjectNames : String[];

 

var boxRect : Rect = Rect(20, 20, 250, 250);

var labelRect : Rect = Rect(20, 280, 50, 30);

var sliderRect : Rect = Rect(70, 280, 120, 15);

var enable : boolean = true;

var lengthVal : float;

var timeVal : float;

var speedVal : float;

var nameVal : String;



var wrapModeVal : WrapMode;

private var stateRef : AnimationState;

private var clipRef : AnimationClip;

 

private var debugText : String;

 

var myGUISkin : GUISkin;

 

function OnGUI () {

    if (enable) {

            GUI.skin = myGUISkin;



            debugText = "";

            

            for (var i : int = 0; i < debugObjects.length; i++) {

                if (debugObjectNames.length > i && debugObjectNames[i]) {

                    debugText += debugObjectNames[i] + ":\n";

                } else {

                    // Reinitialize text

                    debugText += "Object " + i + ":\n";

                }

                // Fetch animations

                for (stateRef in debugObjects[i].animation) {

                    if (debugObjects[i].animation.IsPlaying((stateRef as AnimationState).name)) {

                        // Construct string

                        debugText += GetTextDesc(stateRef) + "\n";

                    }

                }

            }

            

            

            GUI.Box(boxRect, debugText);

            GUI.Label(labelRect, "Timescale");

            Time.timeScale = GUI.HorizontalSlider(sliderRect, Time.timeScale, 0.0, 1.0);

    }

    

    

}

 

 

function GetTextDesc(st : AnimationState) {

    if (enable) {

        clipRef = st.clip;

        lengthVal = st.length;

        timeVal = st.time;

        nameVal = st.name;

        wrapModeVal = st.wrapMode;

        speedVal = st.speed;

        // Allocation

        return String.Format("{0}: {1} {2:0.00}/{3:0.00} {4}", nameVal, wrapModeVal, timeVal, lengthVal, speedVal); 

    }

}