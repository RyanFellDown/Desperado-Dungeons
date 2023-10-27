using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; //Allows accesss to binary formatter for saving.

public static class SavingScript
{
    public static void PlayerSave(Playable_Character_Script player){
        BinaryFormatter formatter = new BinaryFormatter();

        //Creates a new path for the player data to be saved in (file name can be anything, .JSON here).
        string path = Application.persistentDataPath + "/player.JSON";
        FileStream stream = new FileStream(path, FileMode.Create);

        //accesses PlayerData and saves the data in that constructor.
        PlayerData data = new PlayerData(player);

        //Streams the data from data variable into the file (writes it down).
        formatter.Serialize(stream, data);

        //Closes the stream of data into the file (stops writing).
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.JSON";
        
        //If the file path exists, open and read the file.
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            //Changes from binary back to readable format.
            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            //Close the file before returning.
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file NOT FOUND in " + path);
            return null;
        }
    }

}
