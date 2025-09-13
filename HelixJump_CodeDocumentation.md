# Helix Jump (Windows) -- Code Documentation



## 📌 1. `Ball.cs`

Handles the player-controlled ball behavior, including movement,
rotation, and interactions with platforms.

### **Variables**

-   `public Rigidbody rb;`\
    Reference to the Rigidbody component for physics-based movement.
-   `public float jumpForce;`\
    The upward force applied to the ball when bouncing.
-   `public GameObject SplashPrefab;`\
    Prefab for splash effect when the ball hits a platform.
-   `private GameManager gm;`\
    Reference to the `GameManager` instance for controlling level flow.
-   `public float rotateSpeed;`\
    Rotation speed of the ball.

### **Functions**

-   `void Start()`\
    Finds and stores the `GameManager` instance.
-   `void Update()`\
    Continuously rotates the ball around the Y-axis.
-   `private void OnCollisionEnter(Collision collision)`\
    Handles collision events:
    -   If the ball hits a **goal platform** (`Ice-Cream-Cone`), it
        calls `gm.NextLevel()`.
    -   If it hits a **deadly platform** (`stripes3`), it calls
        `gm.RestartGame()`.
    -   Otherwise, the ball bounces upward, and a **splash effect** is
        instantiated and parented to the hit platform.

------------------------------------------------------------------------

## 📌 2. `CamerController.cs`

Controls the camera to follow the ball smoothly.

### **Variables**

-   `public Transform ball;`\
    The ball transform to follow.
-   `private Vector3 offset;`\
    Initial offset between camera and ball.
-   `public float Lerpspeed;`\
    Speed of camera movement (interpolation factor).

### **Functions**

-   `void Start()`\
    Calculates and stores the initial offset between camera and ball.
-   `void Update()`\
    Updates the camera position using **linear interpolation (Lerp)**
    for smooth movement.

------------------------------------------------------------------------

## 📌 3. `GameManager.cs`

Handles overall game state, scene transitions, scoring, and pause menu
functionality.

### **Variables**

-   `private int score;`\
    Tracks the player's score.
-   `public Text scoreText;`\
    UI text element to display the score.
-   `public GameObject PauseMenu;`\
    Reference to the pause menu UI panel.

### **Functions**

-   `void Start()`\
    Initializes the score depending on the **scene index**:
    -   Scene 1 → Score = 0\
    -   Scene 2 → Score = 1000\
    -   Scene 3 → Score = 2000\
-   `void Update()`\
    Handles **input checks**:
    -   In **main menu (scene 0)**: pressing `Escape` quits the game.\
    -   In other scenes: pressing `Escape` toggles the pause menu.\
-   `public void IncreaseGameScore(int ringScore)`\
    Adds points to the score and updates the UI.
-   `public void StartGame()`\
    Loads **scene 1** (start of game).
-   `public void QuitGame()`\
    Exits the application.
-   `public void RestartGame()`\
    Reloads the current scene.
-   `public void ResetLevels()`\
    Resets to **scene 1**.
-   `public void NextLevel()`\
    Loads the next scene, or if the last level is reached, returns to
    **main menu (scene 0)**.
    -   Stops theme music if at final scene (level 3).
-   `public void MainMenu()`\
    Returns to **main menu**.
-   `public void OpenPanel()`\
    Activates the pause menu and pauses gameplay (sets
    `Time.timeScale = 0`).
-   `public void ClosePanel()`\
    Closes the pause menu and resumes gameplay.

------------------------------------------------------------------------

## 📌 4. `Ring.cs`

Controls the behavior of rings (platforms) in the game.

### **Variables**

-   `public Transform ball;`\
    Reference to the ball's transform.
-   `private GameManager gm;`\
    Reference to the `GameManager`.

### **Functions**

-   `void Start()`\
    Finds and stores the `GameManager` instance.
-   `void Update()`\
    Checks if the ring has moved **above the ball's Y position by 5
    units**:
    -   If true, destroys the ring and increases the score by **100
        points**.


------------------------------------------------------------------------


## 📌 5. `RotateMove2.cs`

### **Purpose**

This script controls the rotation of the helix structure based on the
player's mouse input.\
It allows the player to rotate the helix when clicking and dragging the
mouse.

### **Variables**

-   `public float rotatespeed`\
    The speed at which the helix rotates. Can be adjusted in the Unity
    Inspector.
-   `private float moveX`\
    Stores the mouse's horizontal movement value.

### **Functions**

-   `void Start()`\
    Unity lifecycle method, called before the first frame update.
    Currently unused.
-   `void Update()`\
    Called once per frame. It:
    1.  Captures the player's mouse horizontal input (`Mouse X`).
    2.  If the left mouse button is pressed, rotates the helix on the
        Z-axis based on the input and `rotatespeed`.

------------------------------------------------------------------------

## 📌 6. `ThemeSong.cs`

### **Purpose**

This script manages the game's background music and ensures it persists
across scenes.\
It uses a Singleton pattern to make sure only one `ThemeSong` instance
exists.

### **Variables**

-   `public static ThemeSong instance`\
    Singleton instance of the class.
-   `private AudioSource audioSource`\
    The audio component that plays, pauses, and stops the music.

### **Functions**

-   `void Awake()`\
    Ensures the singleton pattern by either keeping or destroying
    duplicates.\
    Sets up the `AudioSource` and makes the object persistent across
    scenes with `DontDestroyOnLoad`.
-   `public void PlayMusic()`\
    Starts the background music playback.
-   `public void PauseMusic()`\
    Pauses the background music.
-   `public void StopMusic()`\
    Stops the background music.

------------------------------------------------------------------------

## 📌 7. `TopSurfaceRotation.cs`

### **Purpose**

This script continuously rotates a surface (e.g., a platform or visual
element) at a constant speed.

### **Variables**

-   `public float rotateSpeed`\
    Determines how fast the surface rotates.

### **Functions**

-   `void Start()`\
    Unity lifecycle method, currently unused.
-   `void Update()`\
    Rotates the object around the Z-axis every frame by
    `rotateSpeed * Time.deltaTime`.

------------------------------------------------------------------------

## 📌 8. `VideoEnd.cs`

### **Purpose**

This script handles the behavior when an intro or cutscene video
finishes.\
After the video ends, it loads the first game scene and resumes
background music.

### **Variables**

-   `VideoPlayer video`\
    Reference to the Unity `VideoPlayer` component.

### **Functions**

-   `void Awake()`\
    Initializes the `VideoPlayer`, starts playback, and registers a
    callback for when the video ends.
-   `void CheckOver(VideoPlayer vp)`\
    Callback function triggered when the video finishes.\
    It:
    1.  Loads the first scene (`SceneManager.LoadScene(0)`).
    2.  Resumes background music by calling
        `ThemeSong.instance.PlayMusic()`.

------------------------------------------------------------------------
