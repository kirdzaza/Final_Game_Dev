# Main Menu Setup Guide

This guide will walk you through setting up a complete main menu system in Unity that meets all the grading criteria.

## Prerequisites

- Unity 2022.3 or later
- All scripts have been created in the `Assets/Scripts/` folder
- You have a "Challenge 1" scene in `Assets/Fly_Like_a_Bird/Challenge 1/`
- You have a MainMenu scene in `Assets/Scenes/`

## 🚀 **QUICK START - What You Need to Do Right Now:**

1. **Add "Challenge 1" to Build Settings** (CRITICAL STEP)
2. **Create the Main Menu UI** (Canvas, Buttons, etc.)
3. **Connect the MainMenuManager script** to your buttons
4. **Test the connection** between Main Menu and "Challenge 1"

## Step 1: Create the Main Menu Scene

1. **Create New Scene:**

   - Go to `File > New Scene`
   - Choose `3D` template
   - Save as `MainMenu` in `Assets/Scenes/`

2. **Set as Default Scene:**

   - Go to `File > Build Settings`
   - Add the MainMenu scene to the build
   - Drag it to the top to make it the first scene

3. **Set Up 3D Camera:**
   - Select the Main Camera
   - Position it at (0, 1, -10) to look at the UI
   - Set Field of View to 60
   - This will give you a good view of the UI elements

## Step 2: Create the UI Canvas

1. **Create Canvas:**

   - Right-click in Hierarchy
   - Go to `UI > Canvas`
   - Set Canvas Scaler to "Scale With Screen Size"
   - Reference Resolution: 1920x1080

2. **Create Background:**
   - Right-click on Canvas
   - Go to `UI > Image`
   - Name it "Background"
   - Set it to fill the entire screen
   - Add a background color or image

## Step 3: Create the Main Menu UI Elements

1. **Game Title:**

   - Right-click on Canvas
   - Go to `UI > Text - TextMeshPro`
   - Name it "GameTitle"
   - Set text to "YOUR COOL GAME TITLE"
   - Position at top center
   - Set font size to 72
   - Center align the text

2. **Button Container:**

   - Right-click on Canvas
   - Go to `UI > Panel`
   - Name it "ButtonContainer"
   - Position in center of screen
   - Remove the Image component (make it transparent)

3. **Create Buttons:**

   - Right-click on ButtonContainer
   - Go to `UI > Button - TextMeshPro`
   - Create 4 buttons with these names and text:
     - "DrivingGameButton" - Text: "Mad Driver"
     - "FlyingGameButton" - Text: "Fly Like a Bird"
     - "SumoGameButton" - Text: "I'm a Sumo and a Ball"
     - "ExitButton" - Text: "Exit"

4. **Style the Buttons:**

   - Select each button
   - Set width to 300, height to 60
   - Space them vertically with 20px gaps
   - Center align the text
   - Set font size to 24

5. **Creator Credit:**
   - Right-click on Canvas
   - Go to `UI > Text - TextMeshPro`
   - Name it "CreatorCredit"
   - Set text to "By [Your Name]"
   - Position at bottom right
   - Set font size to 16

## Step 4: Set Up the Main Menu Manager

1. **Create Empty GameObject:**

   - Right-click in Hierarchy
   - Create Empty GameObject
   - Name it "MainMenuManager"

2. **Add MainMenuManager Script:**

   - Select the MainMenuManager GameObject
   - Add Component > Scripts > MainMenuManager

3. **Configure the Script:**

   - Drag the button GameObjects to their respective fields
   - Set scene names:
     - Driving Game Scene: "DrivingGame"
     - Flying Game Scene: "Challenge 1" (your existing flying game)
     - Sumo Game Scene: "SumoGame"

4. **Add Audio (Optional):**
   - Add AudioSource component to MainMenuManager
   - Assign button click and background music audio clips

## Step 5: Set Up Game Scenes

### **IMPORTANT: Add Your Existing Flying Game to Build Settings**

1. **Add "Challenge 1" Scene to Build Settings:**

   - Go to `File > Build Settings`
   - Click `Add Open Scenes` if you have "Challenge 1" open
   - OR drag `Assets/Fly_Like_a_Bird/Challenge 1/Challenge 1.unity` into the Build Settings window
   - This is your existing flying game that will be loaded when clicking "Fly Like a Bird"

2. **Create Driving Game Scene (if needed):**

   - File > New Scene > 3D
   - Save as "DrivingGame" in Assets/Scenes/
   - Add to Build Settings
   - Create a simple car using 3D primitives (Cubes, Cylinders)
   - Add DrivingGameController script to an empty GameObject

3. **Create Sumo Game Scene (if needed):**
   - File > New Scene > 3D
   - Save as "SumoGame" in Assets/Scenes/
   - Add to Build Settings
   - Create a simple sumo character using 3D primitives (Spheres, Capsules)
   - Add SumoGameController script to an empty GameObject

### **Note:** You already have the flying game scene ("Challenge 1") - you just need to add it to Build Settings!

## Step 6: Set Up In-Game Menus

For each game scene, create a pause menu:

1. **Create Pause Menu UI:**

   - Create Canvas in each game scene
   - Create Panel named "PauseMenuPanel"
   - Add three buttons: Resume, Restart, Back to Main Menu
   - Initially hide the panel (uncheck in Inspector)

2. **Add Pause Menu Controller:**
   - Create empty GameObject named "PauseMenuManager"
   - Add PauseMenuController script
   - Assign UI references

## Step 7: Test the System

1. **Play the Main Menu Scene**
2. **Test each button:**

   - Driving Game button should load DrivingGame scene
   - Flying Game button should load FlyingGame scene
   - Sumo Game button should load SumoGame scene
   - Exit button should quit the application

3. **Test In-Game Menu:**
   - In any game scene, press ESC
   - Pause menu should appear
   - Test Resume, Restart, and Back to Main Menu buttons

## Grading Criteria Checklist

✅ **Main Menu Design** - Visual layout with title and buttons
✅ **In-Game Menu Design** - Pause menu with proper UI
✅ **Navigate to Driving Game** - Button loads DrivingGame scene
✅ **Navigate to Flying Game** - Button loads FlyingGame scene
✅ **Navigate to Sumo Game** - Button loads SumoGame scene
✅ **Exit Game** - Exit button quits application
✅ **Pause with ESC** - ESC key opens pause menu
✅ **Resume Game** - Resume button continues game
✅ **Restart Game** - Restart button reloads current scene
✅ **Back to Main Menu** - Returns to main menu

## Additional Tips

- Use consistent fonts and colors across all menus
- Add visual feedback for button interactions
- Consider adding sound effects and background music
- Test on different screen resolutions
- Add loading screens for better user experience

## Troubleshooting

- If scenes don't load, check that they're added to Build Settings
- If buttons don't work, verify the MainMenuManager script references
- If ESC doesn't pause, check the PauseMenuController is active
- If UI doesn't scale properly, adjust Canvas Scaler settings
