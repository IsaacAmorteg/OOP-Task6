# OOP-Task6

Task 6
Write an abstract class Lightstring.  Expand it with simple and colored Lightstring classes.  As elements of the Lightstring, use the class Bulb and Colored Bulb.

A colored light bulb has a color that can be red, yellow, blue or green.  For a colored light bulb, it should be possible to set the color using the Color type, and get the color as a string.
For a colored Lightstring, when creating, set the color of the light bulb depending on the multiplicity of the serial number (1 - red, 2 - yellow, 3 - green, 4 - blue, 5 - red, etc.) The number of lights in the Lightstring is set by the user.
The state of the bulb (on - off) is calculated from its serial number in the garland and the current minute of time.  If the current minute is even, only the bulbs with an even number in the garland are lit.  If the current minute is odd, the odd-numbered lights are on.

For both lightstrings, create a method that returns the current state of the lights (on/off) and the color in the case of a colored one.

Print the current state of both lightstrings to the console by calling the implemented class methods
