## Note to Reader

This is a study guide for the "Back to Basics" series.  
This guide will cover the fundamental concepts and principles of C# programming, and its applications in Unity.

You may share this guide with others, but please do not claim it as your own work.  
If you have any questions or suggestions, feel free to reach out to me.  
**Signed, Andrie Detera, VP-AGD '25-'26.**

---

## Table of Contents

1. [Basics of Variables and Data Types](##basics-of-variables-and-data-types)
    - Variable Declaration and Initialization
    - Common Data Types (int, float, string, bool)
    - String Manipulation
        - Escape Sequences
        - String Interpolation
    - Type Conversion and Casting
2. [Control Structures](##control-structures)
    - Conditional Statements (if, else if, else, switch)
        - If, Else If, Else Statements
        - Switch Statement
    - Loops (for, while, do-while, foreach)
        - For Loop
        - While Loop
        - Do-While Loop
        - Foreach Loop
    - Break Statement
    - Continue Statement
3. [Arrays and Collections](##arrays-and-collections)
    - Arrays (Single-dimensional and Multi-dimensional)
        - Single-dimensional Arrays
        - Multi-dimensional Arrays
    - Lists and Dictionaries
        - Lists
        - Dictionaries
4. [Functions or Methods](##functions-or-methods)
    - Function Declaration and Definition
    - Parameters and Return Types
5. [Unity Methods](##unity-methods)
    - Start() and Update() Methods
    - FixedUpdate() Method
    - OnCollisionEnter() and OnTriggerEnter() Methods
    - OnEnable() and OnDisable() Methods
    - OnControllerColliderHit() Method
    - OnGUI() Method
6. [Input Action System](##input-action-system)
7. [Unity Transform Class](##unity-transform-class)
    - Position Manipulation
    - Rotation Manipulation
    - Scale Manipulation
8. [Unity GUI class](##unity-gui-class)
9. [Unity Physics Class](##unity-physics-class)
    - Rigidbody Component
    - Colliders
    - Cast Methods
10. [Quarternions and Euler Angles](##quarternions-and-euler-angles)

---

## Basics of Variables and Data Types

### 1.1 Variable Declaration and Initialization

In C# and other programming languages, a variable is a named storage location that holds a value of a specific data type.
To declare a variable, specify its data type followed by its name. 
You can also initialize a variable by assigning it a value at the time of declaration.

**Example:**

```csharp
int myInt;              // Declaration 
myInt = 10;             // Initialization 
float myFloat = 3.14f;  // Declaration and Initialization
```

---

### 1.2 Common Data Types

Here are some common data types in C#:

- `int`: Represents whole numbers (e.g., 1, -5, 100)
- `float`: Represents decimal numbers (e.g., 3.14f, -0.5, 0.0F)
- `string`: Represents a sequence of characters (e.g., "Hello, World!")
- `bool`: Represents a boolean value (`true` or `false`)
- `char`: Represents a single character (e.g., 'A', 'b', '1')
- `double`: Represents double-precision floating-point numbers (e.g., 3.14159, -0.0001)

---

### 1.3 String Manipulation

Strings are sequences of characters and can be manipulated using various methods.

**Common string operations include:**

- **Concatenation:** Combining two or more strings using the `+` operator.
- **Length:** Getting the length of a string using the `Length` property.
- **ToUpper and ToLower:** Converting a string to uppercase or lowercase using `ToUpper()` and `ToLower()` methods.
- **Split:** Splitting a string into an array of substrings using the `Split()` method.
- **Trim:** Removing leading and trailing whitespace using the `Trim()` method.

**Examples:**

```csharp
string fullName = "Leo" + " " + "Nabel";           // Result: "Leo Nabel" 
int nameLength = fullName.Length;                  // Result: 8 
string upperName = fullName.ToUpper();             // Result: "LEO NABEL" 
string[] nameParts = fullName.Split(' ');          // Result: ["Leo", "Nabel"] 
string trimmedName = "  Leo Nabel  ".Trim();       // Result: "Leo Nabel"
```

---

#### 1.3.1 Escape Sequences

Escape sequences are special characters that cannot be typed directly or have special meanings.

- `\n`: New line
- `\t`: Tab
- `\\`: Backslash
- `\"`: Double quote
- `\'`: Single quote

---

#### 1.3.2 String Interpolation

String interpolation allows you to create formatted strings in a more readable way.
Use the `$` symbol before a string literal and include expressions inside curly braces `{}`.

**Examples:**

```csharp
string fullName = "Leo Nabel";
string greeting = $"Hello, {fullName}!";            // Result: "Hello, Leo Nabel!" 
int age = 20;
string info = $"Name: {fullName}, Age: {age}";      // Result: "Name: Leo Nabel, Age: 20"
```

---

### 1.4 Type Conversion and Casting

Type conversion is the process of converting a value from one data type to another.

---

#### 1.4.1 Implicit Conversion

Occurs when a smaller data type is converted to a larger data type automatically.

**Example:**

```csharp
int myInt = 10; 
float myFloat = myInt; // Implicit conversion from int to float
```

---

#### 1.4.2 Explicit Conversion (Casting)

Required when converting a larger data type to a smaller data type.

**Example:**

```csharp

float myFloat = 3.14f; 
int myInt = (int) myFloat; // Explicit conversion from float to int (result: 3)
```

---

#### 1.4.3 Type Conversion During Computation

Type conversion also happens during computation between different data types.

**Example:**

```csharp
int myInt = 5; 
float myFloat = 2.5f; 
int intResult = (int) (myInt * myFloat);    // Result: 12 (float is converted to int upon assignment) 
float floatResult = myInt * myFloat;        // Result: 12.5 (int is converted to float during computation)
```

> The data type of the result is determined by the larger data type in the operation. 
> When assigning the result to a variable, it must match the variable's data type.


---


## Control Structures

Control structures are used to control the flow of execution in a program.  
They allow you to make decisions, repeat actions, and manage the program's behavior based on certain conditions.

---

### 2.1 Conditional Statements

Conditional statements allow you to execute different blocks of code based on certain conditions.  
The most common conditional statements are `if`, `else if`, `else`, and `switch`.

---

#### 2.1.1 If, Else If, Else Statements

The `if` statement evaluates a condition and executes a block of code if the condition is true.  
The `else if` statement allows you to check multiple conditions in sequence.  
The `else` statement executes a block of code if none of the previous conditions are true.

**Example:**

```csharp
int score = 85;

if (score >= 90) {
    Console.WriteLine("Grade: A");
} else if (score >= 80) {
    Console.WriteLine("Grade: B");
} else {
    Console.WriteLine("Grade: F");
}
// Output: "Grade: B"
```

---

#### 2.1.2 Switch Statement

The `switch` statement evaluates a variable and executes a block of code based on its value.  
It is often used as an alternative to multiple `if-else` statements when checking a single variable against multiple values.

**Example:**

```csharp
char grade = 'B';

switch (grade) {
    case 'A':
        Console.WriteLine("Excellent!");
        break;
    case 'B':
        Console.WriteLine("Well done!");
        break;
    default:
        Console.WriteLine("Invalid grade");
        break;
}
// Output: "Well done!"
```

---

### 2.2 Loops

Loops allow you to repeat a block of code multiple times based on certain conditions.  
The most common loops are `for`, `while`, `do-while`, and `foreach`.

---

#### 2.2.1 For Loop

The `for` loop is used to repeat a block of code a specific number of times.  
It consists of three parts: initialization, condition, and increment/decrement.

**Example:**

```csharp
for (int i = 0; i < 5; i++) {
    Console.WriteLine("Iteration: " + i);
}
// Output: Iteration: 0, Iteration: 1, Iteration: 2, Iteration: 3, Iteration: 4
```

---

#### 2.2.2 While Loop

The `while` loop repeats a block of code as long as a specified condition is true.

**Example:**

```csharp
int count = 0;

while (count < 5) {
    Console.WriteLine("Count: " + count);
    count++;
}
// Output: Count: 0, Count: 1, Count: 2, Count: 3, Count: 4
```

---

#### 2.2.3 Do-While Loop

The `do-while` loop is similar to the `while` loop, but it guarantees that the block of code will execute once before checking the condition.

**Example:**

```csharp
int count = 0;

do {
    Console.WriteLine("Count: " + count);
    count++;
} while (count < 5);
// Output: Count: 0, Count: 1, Count: 2, Count: 3, Count: 4
```

---

#### 2.2.4 Foreach Loop

The `foreach` loop is used to iterate over each element in a collection (like an array or list).

**Example:**

```csharp
string[] fruits = { "Apple", "Banana", "Cherry" };

foreach (string fruit in fruits) {
    Console.WriteLine("Fruit: " + fruit);
}
// Output: Fruit: Apple, Fruit: Banana, Fruit: Cherry
```

---

### 2.3 Break Statement

The `break` statement is used to exit a loop or `switch` statement prematurely.  
It can also be used to exit early within a function.

**Example:**

```csharp
for (int i = 0; i < 10; i++) {
    if (i == 5) {
        break; // Exit the loop when i is 5
    }
    Console.WriteLine("Iteration: " + i);
}
// Output: Iteration: 0, Iteration: 1, Iteration: 2, Iteration: 3, Iteration: 4
```

---

### 2.4 Continue Statement

The `continue` statement is used to skip the current iteration of a loop and move to the next iteration.

**Example:**

```csharp
for (int i = 0; i < 10; i++) {
    if (i % 2 == 0) {
        continue; // Skip even numbers
    }
    Console.WriteLine("Odd Number: " + i);
}
// Output: Odd Number: 1, Odd Number: 3, Odd Number: 5, Odd Number: 7, Odd Number: 9
```


---


## Arrays and Collections

Arrays and collections are used to store multiple values in a single variable.  
They allow you to group related data together and perform operations on them.  
Arrays have a fixed size, while collections can dynamically grow and shrink in size.  
Common collections include **Lists** and **Dictionaries**.

---

### 3.1 Arrays

Arrays are used to store a fixed number of values of the same data type.  
They can be single-dimensional or multi-dimensional.  
Arrays are zero-indexed, meaning the first element is at index 0.  
You can access array elements using their index.

**Example of array declaration, initialization, and access:**

```csharp
int[] numbers = new int[5];                       // Declaration and initialization of an array with 5 elements
numbers[0] = 10;                                  // Assigning value to the first element
Debug.Log(numbers[0]);                            // Accessing the first element (Output: 10)

string[] fruits = { "Apple", "Banana", "Cherry" }; // Declaration and initialization with values
Debug.Log(fruits[1]);                              // Accessing the second element (Output: Banana)

// Using loops to iterate through array elements
for (int i = 0; i < fruits.Length; i++) {
    Debug.Log(fruits[i]);                          // Output: Apple, Banana, Cherry
}

foreach (string fruit in fruits) {
    Debug.Log(fruit);                              // Output: Apple, Banana, Cherry
}
```

---

#### 3.1.1 Single-Dimensional Arrays

Single-dimensional arrays are the most common type of arrays.  
They store a list of values in a single row.

**Example:**

```csharp
int[] scores = new int[3];        // Declaration of a single-dimensional array
scores[0] = 90;                   // Assigning values
scores[1] = 85;
scores[2] = 88;
Debug.Log(scores[1]);             // Accessing the second element (Output: 85)

foreach (int score in scores) {
    Debug.Log(score);             // Output: 90, 85, 88
}
```

---

#### 3.1.2 Multi-Dimensional Arrays

Multi-dimensional arrays store data in a grid or table format.  
They can have two or more dimensions.

**Example:**

```csharp
int[,] matrix = new int[2, 3];    // Declaration of a 2D array (2 rows, 3 columns)
matrix[0, 0] = 1;                 // Assigning values
matrix[0, 1] = 2;
matrix[0, 2] = 3;
matrix[1, 0] = 4;
matrix[1, 1] = 5;
matrix[1, 2] = 6;
Debug.Log(matrix[1, 2]);          // Accessing the element at row 1, column 2 (Output: 6)

// Using loops
for (int i = 0; i < 2; i++) {
    for (int j = 0; j < 3; j++) {
        Debug.Log(matrix[i, j]);  // Output: 1, 2, 3, 4, 5, 6
    }
}

foreach (int value in matrix) {
    Debug.Log(value);             // Output: 1, 2, 3, 4, 5, 6
}
```

**Note:** C# also supports **jagged arrays**, which are arrays of arrays.

**Example:**

```csharp
int[][] jaggedArray = new int[2][];  // Declaration of a jagged array
jaggedArray[0] = new int[3];         // First row with 3 elements
jaggedArray[1] = new int[2];         // Second row with 2 elements

jaggedArray[0][0] = 1;               // Assigning values
jaggedArray[0][1] = 2;
jaggedArray[0][2] = 3;
jaggedArray[1][0] = 4;
jaggedArray[1][1] = 5;

Debug.Log(jaggedArray[1][1]);        // Accessing the second element of the second row (Output: 5)

// Using loops
for (int i = 0; i < jaggedArray.Length; i++) {
    for (int j = 0; j < jaggedArray[i].Length; j++) {
        Debug.Log(jaggedArray[i][j]); // Output: 1, 2, 3, 4, 5
    }
}

foreach (int[] row in jaggedArray) {
    foreach (int value in row) {
        Debug.Log(value);             // Output: 1, 2, 3, 4, 5
    }
}
```

---

### 3.2 Lists and Dictionaries

Lists and Dictionaries are part of the `System.Collections.Generic` namespace and provide more flexibility than arrays.  
Lists can dynamically grow and shrink in size, while Dictionaries store key-value pairs for efficient data retrieval.  

To use Lists and Dictionaries, include the following directive at the top of your script:

```csharp
using System.Collections.Generic;
```

---

#### 3.2.1 Lists

Lists are dynamic arrays that can grow and shrink in size.  
They provide various methods for adding, removing, and manipulating elements.

**Example of List declaration, initialization, and access:**

```csharp
List<string> colors = new List<string>();    // Declaration of a List
colors.Add("Red");                           // Adding elements to the List
colors.Add("Green");
colors.Add("Blue");

Debug.Log(colors[1]);                        // Accessing the second element (Output: Green)

// Using loops
foreach (string color in colors) {
    Debug.Log(color);                        // Output: Red, Green, Blue
}
```

**Common List methods include:**

```csharp
colors.Remove("Green");                                  // Removes the first occurrence of "Green"
colors.Insert(1, "Yellow");                              // Inserts "Yellow" at index 1
int count = colors.Count;                                // Gets the number of elements in the List
colors.Clear();                                          // Removes all elements from the List
bool containsRed = colors.Contains("Red");               // Checks if the List contains "Red"
colors.Sort();                                           // Sorts the List in ascending order
colors.Reverse();                                        // Reverses the order of elements in the List
colors.ToArray();                                        // Converts the List to an array
colors.IndexOf("Blue");                                  // Returns the index of "Blue"
colors.RemoveAt(0);                                      // Removes the element at index 0
colors.AddRange(new string[] { "Purple", "Orange" });    // Adds multiple elements
colors.InsertRange(2, new string[] { "Cyan", "Magenta" }); // Inserts multiple elements
```

---

#### 3.2.2 Dictionaries

Dictionaries store key-value pairs, allowing for efficient data retrieval based on keys.  
They provide various methods for adding, removing, and manipulating key-value pairs.

**Example of Dictionary declaration, initialization, and access:**

```csharp
Dictionary<string, int> ageDictionary = new Dictionary<string, int>(); // Declaration of a Dictionary
ageDictionary.Add("Leo", 30);       // Adding key-value pairs
ageDictionary.Add("Leor", 25);

Debug.Log(ageDictionary["Leo"]);    // Accessing the value associated with the key "Leo" (Output: 30)

// Using loops
foreach (KeyValuePair<string, int> entry in ageDictionary) {
    Debug.Log(entry.Key + ": " + entry.Value); // Output: Leo: 30, Leor: 25
}
```

**Common Dictionary methods include:**

```csharp
ageDictionary.Remove("Leor");          // Removes the key-value pair with key "Leor"
ageDictionary.ContainsKey("Leo");      // Checks if the Dictionary contains the key "Leo"
ageDictionary.Count;                   // Gets the number of key-value pairs
ageDictionary.Clear();                 // Removes all key-value pairs
ageDictionary.Keys;                    // Gets a collection of all keys
ageDictionary.Values;                  // Gets a collection of all values
```

---


---

## Functions or Methods

Methods (or functions) are blocks of code that perform a specific task.  
They help organize code, improve readability, and promote code reuse.  
Methods can take input parameters and return output values.  
To declare a method, you need to specify its return type, name, and parameters (if any).

---

### 4.1 Function Declaration and Definition

A **method declaration** defines the structure of a method (its name, parameters, and return type).  
A **method definition** contains the code that runs when the method is called.

**Example:**

```csharp
void Greet() {                         // Method declaration
    Debug.Log("Hello, World!");        // Method definition
}
```

You can call this method anywhere in your script by using its name:

```csharp
Greet();                               // Output: Hello, World!
```

---

### 4.2 Parameters and Return Types

Methods can take **parameters** to receive input values and use the `return` keyword to output a result.

**Example:**

```csharp
int Add(int a, int b) {                // Method with parameters and a return type
    return a + b;                      // Returns the sum of a and b
}

void Start() {
    Debug.Log(Add(5, 3));              // Output: 8
}
```

**Explanation:**
- `int` (before the method name) — defines the **return type**.
- `a` and `b` — are **parameters** (input values).
- `return a + b;` — sends back the result to wherever the method is called.

---

## Unity Methods

Unity provides **built-in methods** that are called automatically by the Unity engine at specific points in the game loop.  
These are also known as **event functions**.

---

### 5.1 Start() and Update() Methods

- **Start()** — called once when the script is first enabled. Commonly used for initialization.  
- **Update()** — called once per frame. Used for continuous checks or actions (e.g., input, movement).

**Example:**

```csharp
void Start() {
    Debug.Log("Game Started!");
}

void Update() {
    Debug.Log("Frame Updated!");
}
```

**Tip:**  
Use `Start()` for setup and `Update()` for continuous logic.

---

### 5.2 FixedUpdate() Method

**FixedUpdate()** runs at fixed intervals (default: every 0.02 seconds or 50 times per second).  
It’s ideal for **physics calculations** since it’s not tied to the frame rate.

**Example:**

```csharp
void FixedUpdate() {
    Debug.Log("Physics Updated!");
}
```

**Note:**  
- Use `FixedUpdate()` for physics-based motion.  
- Use `Update()` for non-physics updates.  
- Mixing them carelessly can cause inconsistent movement.

---

### 5.3 OnCollisionEnter() and OnTriggerEnter() Methods

These handle **collision and trigger events** in Unity’s physics system.

#### OnCollisionEnter()
Called when a GameObject with a Collider and Rigidbody collides with another Collider.

**Example:**
```csharp
void OnCollisionEnter(Collision collision) {
    Debug.Log("Collided with: " + collision.gameObject.name);
}
```

#### OnTriggerEnter()
Called when a **trigger collider** detects another Collider entering its area.

**Example:**
```csharp
void OnTriggerEnter(Collider other) {
    Debug.Log("Triggered by: " + other.gameObject.name);
}
```

**Requirements:**
- For **OnCollisionEnter()**: at least one object needs a **Rigidbody**.
- For **OnTriggerEnter()**: one collider must have **"Is Trigger"** enabled.

---

### 5.4 OnEnable() and OnDisable() Methods

These methods are called when a script or GameObject becomes **active** or **inactive**.

**Example:**

```csharp
void OnEnable() {
    Debug.Log("Script Enabled!");
}

void OnDisable() {
    Debug.Log("Script Disabled!");
}
```

**Use Case:**  
Good for setting up or cleaning up listeners, event subscriptions, or object states when enabling/disabling scripts.

---

### 5.5 OnControllerColliderHit() Method

Called when a **CharacterController** component collides with another Collider.

**Example:**

```csharp
void OnControllerColliderHit(ControllerColliderHit hit) {
    Debug.Log("CharacterController collided with: " + hit.gameObject.name);
}
```

**Note:**  
- Requires a **CharacterController** component.  
- Useful for character-based movement detection and response.

---

### 5.6 OnGUI() Method

Called for rendering and handling **GUI (Graphical User Interface)** events.

**Example:**

```csharp
void OnGUI() {
    if (GUI.Button(new Rect(10, 10, 100, 30), "Click Me")) {
        Debug.Log("Button Clicked!");
    }
}
```


---


## Input Action System

The **Input Action System** is a modern and flexible way to handle input in Unity.  
It allows you to define **input actions** and map them to multiple input devices such as keyboard, mouse, gamepad, or touch.

To use it, you need to:

1. Create an **Input Actions Asset** in Unity.  
2. Define your **actions** (e.g., Move, Jump, Attack).  
3. Bind them to desired controls (e.g., WASD, left stick, buttons).  
4. Reference and use them in your scripts.

**Note:**  
Ensure the Input Actions asset is properly set up with a "Move" action and other custom actions (like Jump or Attack) in the Unity Editor.

---

### Example: Basic Movement and Attack with the Input Action System

```csharp
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    [SerializeField] InputActionAsset inputActions;   // Reference to the Input Actions asset

    void Start() {
        // Subscribe to the Attack action
        inputActions.FindAction("Attack").performed += OnAttack;
    }

    void OnAttack(InputAction.CallbackContext context) {
        Debug.Log("Attack action performed!");
    }

    void OnEnable() {
        // Enable the Player action map
        inputActions.FindActionMap("Player").Enable();
    }

    void OnDisable() {
        // Disable the Player action map
        inputActions.FindActionMap("Player").Disable();
    }

    void Update() {
        // Read Move action value
        Vector2 moveInput = inputActions.FindAction("Move").ReadValue<Vector2>();
        transform.Translate(new Vector3(moveInput.x, 0, moveInput.y) * Time.deltaTime * 5f);
    }
}
```

**Explanation:**
- `InputActionAsset` — references the created input asset.
- `FindAction("Move")` — locates the defined “Move” action.
- `.ReadValue<Vector2>()` — reads movement input as a 2D vector.
- `OnAttack()` — runs when the "Attack" input is performed.
- `OnEnable()` / `OnDisable()` — manage when the action map is active.


---


## Unity Transform Class

The **Transform** class represents a GameObject’s **position**, **rotation**, and **scale** in 3D space.  
Every GameObject in Unity automatically has a Transform component, accessible via the `transform` property.

---

### 7.1 Position Manipulation

A GameObject’s position is represented by a **Vector3** (x, y, z).

You can:
- Get or set the position directly.
- Move an object relative to its current position using `Translate()`.

**Example 1: Getting and Setting Position**
```csharp
void Start() {
    Vector3 currentPosition = transform.position;      // Get current position
    transform.position = new Vector3(0, 5, 0);         // Set a new position
}
```

**Example 2: Moving an Object**
```csharp
void Update() {
    transform.Translate(Vector3.forward * Time.deltaTime * 5f);
}
```
This moves the object forward at **5 units per second**.

---

### 7.2 Rotation Manipulation

A GameObject’s rotation is represented by a **Quaternion**, which defines its 3D orientation.  
You can set rotation directly or rotate incrementally.

**Example 1: Setting Rotation**
```csharp
void Start() {
    Quaternion currentRotation = transform.rotation;   // Get current rotation
    transform.rotation = Quaternion.Euler(0, 90, 0);   // Rotate 90° around Y-axis
}
```

**Example 2: Rotating Continuously**
```csharp
void Update() {
    transform.Rotate(Vector3.up * Time.deltaTime * 45f);
}
```
This rotates the object **45 degrees per second** around the Y-axis.

---

### 7.3 Scale Manipulation

A GameObject’s scale is also a **Vector3**, controlling size along the X, Y, and Z axes.

**Example:**
```csharp
void Start() {
    Vector3 currentScale = transform.localScale;       // Get current scale
    transform.localScale = new Vector3(2, 2, 2);       // Double the object's size
}
```

**Tip:**  
Scaling affects how large an object appears but doesn’t change its physical position or rotation.


---


## Unity GUI Class

The **GUI class** in Unity is used for creating **graphical user interfaces (GUIs)** directly within your game window.  
It provides built-in methods for drawing interactive elements like buttons, labels, and sliders.  
GUI elements are typically placed inside the **`OnGUI()`** method of a `MonoBehaviour` script.

---

### GUI.Box
Creates a box with a specific position and size.

**Example:**
```csharp
void OnGUI() {
    GUI.Box(new Rect(10, 10, 100, 50), "Hello, World!");
}
```
This creates a box at position `(10, 10)` with a width of `100` and height of `50`.

---

### GUI.Button
Creates a clickable button.

**Example:**
```csharp
void OnGUI() {
    if (GUI.Button(new Rect(10, 70, 100, 30), "Click Me")) {
        Debug.Log("Button Clicked!");
    }
}
```
This creates a button at `(10, 70)` — when clicked, it logs *"Button Clicked!"* in the console.

---

### GUI.Label
Displays non-interactive text on the screen.

**Example:**
```csharp
void OnGUI() {
    GUI.Label(new Rect(10, 110, 200, 30), "This is a label.");
}
```
This shows a simple text label at `(10, 110)`.

---

### GUI.TextField
Creates a text field that accepts user input.

**Example:**
```csharp
string userInput = "";

void OnGUI() {
    userInput = GUI.TextField(new Rect(10, 150, 200, 30), userInput);
}
```
This adds a text box at `(10, 150)` where players can type text, stored in `userInput`.

---

### GUI.Toggle
Creates a toggle button (checkbox).

**Example:**
```csharp
bool isToggled = false;

void OnGUI() {
    isToggled = GUI.Toggle(new Rect(10, 190, 100, 30), isToggled, "Toggle Me");
}
```
This creates a toggle at `(10, 190)` that can be turned on/off, updating the `isToggled` variable.

---

### GUI.HorizontalSlider
Creates a horizontal slider for selecting a value within a range.

**Example:**
```csharp
float sliderValue = 0.5f;

void OnGUI() {
    sliderValue = GUI.HorizontalSlider(new Rect(10, 230, 200, 30), sliderValue, 0.0f, 1.0f);
}
```
This creates a horizontal slider at `(10, 230)` that lets you adjust `sliderValue` between `0.0` and `1.0`.

---

### GUI.VerticalSlider
Creates a vertical slider for selecting a value within a range.

**Example:**
```csharp
float verticalSliderValue = 0.5f;

void OnGUI() {
    verticalSliderValue = GUI.VerticalSlider(new Rect(220, 10, 30, 200), verticalSliderValue, 0.0f, 1.0f);
}
```
This creates a vertical slider at `(220, 10)` with a height of `200` that adjusts `verticalSliderValue`.

---

**Note:**  
While the **GUI class** is useful for quick or debug UI, Unity recommends using the **Canvas-based UI System (uGUI)** for modern interfaces, as it offers more flexibility, styling, and performance.


---


## Unity Physics Class

The **Physics** class in Unity provides methods and properties for handling physics-based interactions such as forces, gravity, and collisions.  
It allows you to simulate realistic physical behavior in your game.

---

### 9.1 Rigidbody Component

The **Rigidbody** component adds physics behavior to a GameObject, enabling it to move, fall, and collide under Unity’s physics engine.

**Common Rigidbody methods:**
- `Rigidbody.AddForce(Vector3 force)`: Applies a force that moves the Rigidbody in the direction of the force.  
- `Rigidbody.AddTorque(Vector3 torque)`: Applies torque, causing the Rigidbody to rotate.  
- `Rigidbody.AddRelativeForce(Vector3 force)`: Applies a force relative to the Rigidbody's local coordinate system.

**Common Rigidbody properties:**
- `Rigidbody.isKinematic`: Determines if the Rigidbody is not affected by physics.  
- `Rigidbody.useGravity`: Enables or disables gravity for the Rigidbody.

**Example:**

```csharp
public class PhysicsExample : MonoBehaviour
{
    public Rigidbody rb;

    void Start() {
        // Apply an upward force to the Rigidbody
        rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
    }
}
```

---

### 9.2 Colliders

**Colliders** define the physical shape of a GameObject for collision detection.  
They determine how objects detect and respond to collisions.

**Common collider types:**
- `BoxCollider`
- `SphereCollider`
- `CapsuleCollider`
- `MeshCollider`

Each collider can be configured to be **trigger-based** (for detecting overlaps) or **solid** (for physical collisions).

**Example:**

```csharp
void OnCollisionEnter(Collision collision) {
    Debug.Log("Collided with: " + collision.gameObject.name);
}

void OnTriggerEnter(Collider other) {
    Debug.Log("Triggered by: " + other.gameObject.name);
}
```

---

### 9.3 Cast Methods

**Cast methods** are used for raycasting and shape casting — ways to detect objects along a line or within a shape.

**Common Physics cast methods:**
- `Physics.Raycast`: Casts a ray to detect objects along a straight line.  
- `Physics.SphereCast`: Casts a sphere along a direction to detect wider hits.  
- `Physics.BoxCast`: Casts a box volume to detect multiple or wide hits.

**Example (Raycast):**

```csharp
void Update() {
    RaycastHit hit;

    // Casts a ray forward up to 100 units
    if (Physics.Raycast(transform.position, transform.forward, out hit, 100f)) {
        Debug.Log("Hit: " + hit.collider.gameObject.name);
    }
}
```

**Example (SphereCast):**

```csharp
void Update() {
    RaycastHit hit;

    if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit, 100f)) {
        Debug.Log("Hit: " + hit.collider.gameObject.name);
    }
}
```

**Example (BoxCast):**

```csharp
void Update() {
    RaycastHit hit;

    if (Physics.BoxCast(transform.position, new Vector3(1, 1, 1), transform.forward, out hit, Quaternion.identity, 100f)) {
        Debug.Log("Hit: " + hit.collider.gameObject.name);
    }
}
```

**Note:**  
Cast methods return a boolean value (`true` if something is hit).  
The `RaycastHit` structure stores hit details like:
- `hit.collider` → The collider hit  
- `hit.point` → The exact contact position  
- `hit.normal` → The surface direction of the hit  

---

## Quaternions and Euler Angles

**Quaternions** and **Euler angles** both represent rotations in 3D space.

- **Euler angles**: Use three angles (pitch, yaw, roll) around the X, Y, and Z axes.  
- **Quaternions**: Mathematical representation that avoids gimbal lock and allows smooth rotation interpolation.

---

### 10.1 Quaternions

Unity uses the **Quaternion** class to handle complex 3D rotations.

**Common Quaternion methods:**
- `Quaternion.Euler(float x, float y, float z)`: Converts Euler angles into a Quaternion.  
- `Quaternion.Slerp(Quaternion a, Quaternion b, float t)`: Smoothly interpolates between two rotations.  
- `Quaternion.LookRotation(Vector3 forward, Vector3 up)`: Creates a rotation facing a given direction.

**Example (Euler to Quaternion):**

```csharp
Quaternion rotation = Quaternion.Euler(0, 90, 0); 
transform.rotation = rotation; // Rotate 90° around Y-axis
```

**Example (Slerp):**

```csharp
Quaternion startRotation = Quaternion.Euler(0, 0, 0);
Quaternion endRotation = Quaternion.Euler(0, 90, 0);
transform.rotation = Quaternion.Slerp(startRotation, endRotation, 0.5f); // 50% rotation
```

**Example (LookRotation):**

```csharp
Vector3 forward = new Vector3(0, 0, 1);
Vector3 up = new Vector3(0, 1, 0);
Quaternion lookRotation = Quaternion.LookRotation(forward, up);
transform.rotation = lookRotation;
```

**Common Quaternion properties:**
- `Quaternion.identity` → No rotation (default).  
- `Quaternion.eulerAngles` → The Euler angles equivalent.  
- `Quaternion.normalized` → Returns a unit Quaternion.  
- `x`, `y`, `z`, `w` → Individual Quaternion components.

---

**Summary:**
- Use **Rigidbody** and **Colliders** to handle physics.  
- Use **Physics.Cast** methods to detect objects.  
- Use **Quaternions** for smooth, stable 3D rotations.  