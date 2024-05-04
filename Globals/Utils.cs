using Godot;
using System;
using System.Collections.Generic;
using System.Text.Json;

public partial class Utils : Node
{
	public const string SavePath = "res://savegame.bin";

	public static void SaveGame()
	{
		FileAccess SaveFile = FileAccess.Open(SavePath, FileAccess.ModeFlags.Write);
		Dictionary<string, int> data = new Dictionary<string, int>
        {
            { "PlayerHealth", Game.PlayerHealth },
            { "PlayerGold", Game.PlayerGold }
        };
		string jstring = JsonSerializer.Serialize(data);
		SaveFile.StoreString(jstring);
		SaveFile.Close();
	}

	public static void LoadGame(){
		if(!FileAccess.FileExists(SavePath)){
			Game.PlayerGold = 0;
			Game.PlayerHealth = 100;
			return;
		}
		FileAccess SaveFile = FileAccess.Open(SavePath, FileAccess.ModeFlags.Read);
		if(FileAccess.FileExists(SavePath)){
			string jstring = SaveFile.GetAsText();
			Dictionary<string, int> data = JsonSerializer.Deserialize<Dictionary<string, int>>(jstring);
			Game.PlayerHealth = data["PlayerHealth"];
			Game.PlayerGold = data["PlayerGold"];
		}
		SaveFile.Close();
	}

}
