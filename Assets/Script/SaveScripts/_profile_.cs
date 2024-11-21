using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Profile: MonoBehaviour
{
    //Fields of the profile class to be use in the object of which will be used in the save system
    //The profile contains all save data to be put in a psuedo CSV file 

    private string profile_name;
    private int num_artifacts_collected = 0;
    private int[] artifacts_collected = { };
    private int num_logs_collected = 0;
    private int[] logs_collected = { };
    private bool selected_profile = false;
    //Profile object constructor
    public Profile()
    {
        profile_name = "NewProfile";
        num_artifacts_collected = 0;
        artifacts_collected = artifacts_collected;
        num_logs_collected = 0;
        logs_collected = logs_collected;
        selected_profile = false;
    }
    //Getters and Setters for the profile object
    public string Profile_Name{
        get {return profile_name;}
        set {profile_name = profile_name;}
    }
    public int Num_Artifacts_Collected{
        get { return num_artifacts_collected; }
        set { num_artifacts_collected = num_artifacts_collected++; }
    }
    public int[] Artifacts_Collected
    {
        get { return artifacts_collected; }
        set { artifacts_collected[num_artifacts_collected] = 0; }
    }
    public int Num_Logs_Collected{
        get { return num_logs_collected;}
        set {num_logs_collected++;}
    }
    public int Num_Logs_Collected{
        get { return num_logs_collected;}
        set {num_logs_collected++;}
    }

}
//General PickUp class of which the artifacts and logs are derived from
public class Pickup: MonoBehaviour
{
    string pickup_name = "";
    int pickup_id = 0;

    static void PickUp_Item()
    {

    }
}
//Artifact class which holds the artifact id which are put in the profile object
public class Artifact: MonoBehaviour
{
    string artifact_name = "Artifact";
    public int artifact_id = 1;
    bool log_attached = false;

    public Artifact()
    {
        artifact_name = artifact_name;
        artifact_id = artifact_id;
        log_attached = log_attached;
    }

    public int Artifact_ID
    {
        get { return artifact_id; }
        set { artifact_id = artifact_id + 1; }
    }
}
//Log class which holds the log id which are put in the profile object

public class Log: MonoBehaviour
{
    int log_number = 1;
    string log_text = "*Log Text";
    int hidden_value = 0;
}

/*public class SaveSystem : MonoBehavior
{

}*/