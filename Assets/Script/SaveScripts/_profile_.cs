using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Profile{
    string profile_name = "Profile_1";
    int artifacts_collected = 0;
    int logs_collected = 0;
    bool selected_profile = false;


}

class Pickup{
    string pickup_name = "";
    int pickup_id = 0;

    static void PickUp_Item(){

    }
}
class Artifact{
    string artifact_name = "Artifact";
    int artifact_id = 1;
    bool log_attached = false;
}
class Log{
    int log_number = 1;
    string log_text = "*Log Text";
    int hidden_value = 0;
}

public class SaveSystem : MonoBehavior{
    
}