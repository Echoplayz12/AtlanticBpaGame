using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Profile{
    string profile_name = "Profile_1";
    int artifacts_collected = 0;
    int logs_collected = 0;
    bool selected_profile = false;
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

    /*static void Main(string[] args){
        Profile profile_1 = new Profile();
        Profile profile_2 = new Profile();
        Profile profile_3 = new Profile();

        
    }*/