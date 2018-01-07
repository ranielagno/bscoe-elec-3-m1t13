using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    int level = 0;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;
    string password = "";
    string[,] passwords = { 
        { "Ammo", "Baton", "Bomb", "Knife", "Rifle" }, // 4-5 letters
        { "Brigade", "Cavalry", "Marshal", "Platoon", "Troops" }, // 6-7 letters
        { "Arkansas", "Colorado", "Illinois", "Missouri", "Oklahoma" } // 8 letters
    };

    // Use this for initialization
    void Start () {

        ShowMainMenu();
        
    }

    void ShowMainMenu() {

        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("M1T13");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the US Army Armory");
        Terminal.WriteLine("Press 2 for the US Pentagon");
        Terminal.WriteLine("Press 3 for the US State Capitol");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection:");

    }
	
    void OnUserInput(string input) {

        if (input == "menu") {
            ShowMainMenu();
        } else if (input == "Edward Snowden") {
            Terminal.WriteLine("Government is spying on us!");
        } else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        } else if (currentScreen == Screen.Password) {
            CheckPassword(input);
        }

    }

    private void RunMainMenu(string input) {

        if (input == "1") {
            level = 1;
            StartGame();
        } else if (input == "2") {
            level = 2;
            StartGame();
        } else if (input == "3") {
            level = 3;
            StartGame();
        } else {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    private void StartGame() {

        currentScreen = Screen.Password;
        int randInt = UnityEngine.Random.Range(0, 5);
        password = passwords[level - 1, randInt];

        Terminal.ClearScreen();
        Terminal.WriteLine("Level " + level + " : " + StringExtension.Anagram(password));
        Terminal.WriteLine("Enter password:");
     
    }

    private void CheckPassword(string input)
    {
        if (input == password) {

            currentScreen = Screen.Win;

            Terminal.ClearScreen();
            DrawFlag();

            if (level == 1) {
                Terminal.WriteLine("       Welcome to US Army Armory!");
            }
            else if (level == 2) {
                Terminal.WriteLine("        Welcome to the Pentagon!");
            }
            else {
                Terminal.WriteLine("   Welcome to " + password + " state capitol!");
            }

        } else {
            StartGame();
        }
  
    }

    private void DrawFlag() {

        Terminal.WriteLine("");
        Terminal.WriteLine("   * * * * * * * ====================");
        Terminal.WriteLine("    * * * * * *  ====================");
        Terminal.WriteLine("   * * * * * * * ====================");
        Terminal.WriteLine("    * * * * * *  ====================");
        Terminal.WriteLine("   * * * * * * * ====================");
        Terminal.WriteLine("   ==================================");
        Terminal.WriteLine("   ==================================");
        Terminal.WriteLine("   ==================================");
        Terminal.WriteLine("");

    }
}
