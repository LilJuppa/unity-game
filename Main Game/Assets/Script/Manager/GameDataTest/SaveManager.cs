using UnityEngine;
using System.IO;

public class SaveManager
{
    private string saveFileName = "saveData.json";
    private string saveFilePath;

    private PlayerStats playerStats;
    private GameSettings gameSettings;
    private Inventory inventory;

    public SaveManager()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, saveFileName);
    }

    public void SaveGame()
    {
        // Create instances of your data classes and populate them with the relevant data to be saved
        playerStats = new PlayerStats();
        gameSettings = new GameSettings();
        inventory = new Inventory();

        // TODO: Populate the playerStats, gameSettings, and inventory with actual data from your game

        // Convert the data objects to JSON strings
        string playerStatsJson = JsonUtility.ToJson(playerStats);
        string gameSettingsJson = JsonUtility.ToJson(gameSettings);
        string inventoryJson = JsonUtility.ToJson(inventory);

        // Create a JSON object to hold all the saved data
        SavedData savedData = new SavedData(playerStatsJson, gameSettingsJson, inventoryJson);

        // Convert the savedData object to a JSON string
        string savedDataJson = JsonUtility.ToJson(savedData);

        // Write the JSON string to a file
        File.WriteAllText(saveFilePath, savedDataJson);

        Debug.Log("Game saved.");
    }

    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            // Read the saved JSON string from the file
            string savedDataJson = File.ReadAllText(saveFilePath);

            // Convert the JSON string to a savedData object
            SavedData savedData = JsonUtility.FromJson<SavedData>(savedDataJson);

            // Convert the JSON strings from savedData back to data objects
            playerStats = JsonUtility.FromJson<PlayerStats>(savedData.playerStatsJson);
            gameSettings = JsonUtility.FromJson<GameSettings>(savedData.gameSettingsJson);
            inventory = JsonUtility.FromJson<Inventory>(savedData.inventoryJson);

            // TODO: Use the loaded data to restore the player's stats, game settings, and inventory in your game

            Debug.Log("Game loaded.");
        }
    }
}
