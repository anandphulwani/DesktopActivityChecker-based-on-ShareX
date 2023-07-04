# DesktopActivityChecker

DesktopActivityChecker is a Windows desktop application that allows you to monitor specific sections of your screen for changes based on user-defined conditions and receive notifications when changes occur.The application is built on the ShareX screen capture utility and extends its functionality to provide a more comprehensive desktop activity monitoring solution.

## Basic description of features

- Monitor specific regions/sections of your screen for changes.
- Set the frequency at which the application checks for changes.
- Configure the type of comparison to be made between the current and previous state of the region.
- Receive notifications when changes occur on the same machine as well as mobile application as a push notification.
- Send a POST request to a specified URL when the specified condition is met.
- User-friendly interface

## Advanced description of features

- **Region Selection**: Users can select specific regions on their desktop to monitor.
- **Activity Analysis**: The application analyzes based on user-defined conditions.
- **Customizable Monitoring Conditions**: Users can define their own conditions for what constitutes an activity. These conditions can be based on various parameters such as comparison value, repeat time, and more.
- **Post Request URL**: Users can specify a URL to which a POST request will be sent when the condition is met.
- **Post Message**: Users can specify a message to be sent in the POST request when the condition is met.

## MainForm Controls

The MainForm contains a TabControl with two TabPages: `tabCreateEditEntry` and `tabEntriesTable`.

### tabCreateEditEntry

This tab is designed for creating or editing an entry. The components are listed in their tab order:

1. **Entry Name**: Specify the name of the entry for easy identification.
2. **Region Picker**: Click to select a region on the screen using a graphical interface, this will automatically fill the X Coordinate, Y Coordinate, Width and Height automatically.
3. **X Coordinate**: Define the X-coordinate manually for the top-left corner of the region to be monitored.
4. **Y Coordinate**: Define the Y-coordinate manually for the top-left corner of the region to be monitored.
5. **Width**: Set the width manually of the region to be monitored.
6. **Height**: Set the height manually of the region to be monitored.
7. **Repeat Time**: Determine the frequency (in seconds) at which the application checks the specified region for changes.
8. **Comparison Option**: Choose the type of comparison to be made between the current and previous state of the region. Options include:
   - `Match from Initial Capture`: This option compares the current state of the region with the initial capture from initial monitoring interval when the monitoring started.
   - `Match from Last Capture`: This option compares the current state of the region with the last capture from last monitoring interval.
   - `OCR compare`: This option uses Optical Character Recognition (OCR) to compare the current state of the region with the specified value. Additional fields for OCR Regex, OCR Regex Group, and Scale Factor are revealed. The Scale Factor is set to 4 by default.
   - `Check pixel color present`: This option checks if the specified color is present in the current state of the region. Additional fields for comparison value and color matches are revealed.
   - `Check same color background`: This option checks if the entire region is of the same color.
9. **Wait For**: Choose the condition that must be met for the application to notify. The options depend on the selected Comparison Option:
   - `Match from Initial Capture` or `Match from Last Capture`: Options include "Equality" and "Non Equality".
   - `OCR compare`: Options include "Numeric.==", "Numeric.!=", "Numeric.>", "Numeric.>=", "Numeric.<", "Numeric.<=", "String.Equality", and "String.Non Equality".
   - `Check pixel color present` or `Check same color background`: Options include "Present" and "Not Present".
10. **Comparison Value / Colors To Compare**: Specify the value to be compared with the **'Wait For'** operator in case of **'OCR Compare'** and **'Check pixel color present'** option.
11. **OCR Regex**: Provide a regular expression for Optical Character Recognition (OCR) to make sure the text is read correctly.
12. **OCR Regex Group**: Specify the group within the OCR Regex to be used for comparison.
13. **Scale Factor**: Adjust the scale factor for the region capture, useful when dealing with high DPI displays. Usually increase this number for better readibility, for e.g. 8,10,12 works better.
14. **Color Matches**: Choose the color comparison method if the region contains images. Options include:
   - `All`: Triggers when all colors are matched in the region.
   - `Any`: Triggers when any colors are matched in the region.
15. **Sleep Between Captures**: Set the delay (in milliseconds) between successive captures within a single monitoring interval.
16. **Capture Per Interval**: Determine the number of captures to be made within a single monitoring interval.
17. **Match Captures**: Choose the capture comparison method. Options include:
   - `All`: Triggers when all captures in the region match the specified condition.
   - `Any`: Triggers when any capture in the region matches the specified condition.
18. **POST Request URL**: Provide the URL to which a POST request will be sent when the specified condition is met.
19. **POST Message**: Specify the message to be sent as a POST request when the specified condition is met.
20. **Enabled Checkbox**: Check to enable the entry. Uncheck to disable it.
21. **Create / Update**: Click to create or update a new entry with the specified parameters.
22. **Reset**: Click to reset all fields to their default values.

Each of these components contributes to the configuration of an entry. The application uses these parameters to monitor the specified region and perform the specified actions.

### tabEntriesTable

This tab contains a DataGridView for displaying and managing action of entries, like enable/disable checkbox, edit icon, delete icon.

## Screenshots
![Entries01 - Match from Initial Capture](https://raw.githubusercontent.com/anandphulwani/DesktopActivityChecker-based-on-ShareX/master/DesktopActivityChecker/screenshots/Entries01.png "Entries01 - Match from Initial Capture")
![Entries02 - OCR Compare](https://raw.githubusercontent.com/anandphulwani/DesktopActivityChecker-based-on-ShareX/master/DesktopActivityChecker/screenshots/Entries02.png "Entries02 - OCR Compare")
- - - -
![Entries03 - Check pixel color present](https://raw.githubusercontent.com/anandphulwani/DesktopActivityChecker-based-on-ShareX/master/DesktopActivityChecker/screenshots/Entries03.png "Entries03 - Check pixel color present")
- - - -
![EntriesTable](https://raw.githubusercontent.com/anandphulwani/DesktopActivityChecker-based-on-ShareX/master/DesktopActivityChecker/screenshots/EntriesTable.png "EntriesTable")
- - - -
![ScreenCapture01 - Start Selection](https://raw.githubusercontent.com/anandphulwani/DesktopActivityChecker-based-on-ShareX/master/DesktopActivityChecker/screenshots/ScreenCapture01.png "ScreenCapture01 - Start Selection")
- - - -
![ScreenCapture02 - While Selection](https://raw.githubusercontent.com/anandphulwani/DesktopActivityChecker-based-on-ShareX/master/DesktopActivityChecker/screenshots/ScreenCapture02.png "ScreenCapture02 - While Selection")


## Demo
![Demo - While Capturing](https://raw.githubusercontent.com/anandphulwani/DesktopActivityChecker-based-on-ShareX/master/DesktopActivityChecker/screenshots/demo.gif "Demo - While Capturing")


## Releases
- Download the latest release from. the release section, and you are ready to use.

## Getting Started
To get started with DesktopActivityChecker, clone the repository and open `DesktopActivityChecker.csproj` in your preferred .NET development environment.

## How to Use
1. Clone the repository.
2. Open the solution in Visual Studio.
3. Build and run the application.
4. Use the `tabCreateEditEntry` tab to create and edit entries.
5. Use the `tabEntriesTable` tab to view and manage entries.

## Contributing
Contributions to DesktopActivityChecker are welcome!

## License
DesktopActivityChecker is licensed under the GPL-3.0 license. See the [LICENSE](LICENSE.txt) file for details.
