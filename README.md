# Solution-specific VSSettings

Imports a custom `.vssettings` on solution load.

See the [change log](https://raw.githubusercontent.com/iron-software/SolutionSpecificVSSettings/master/CHANGELOG.md) for changes and road map.

## Features
* When Visual Studio opens a solution this extension will try to find a 
`.vssettings` file with a name similar to solution's name located in the same 
directory. For example if the solution being loaded is located in the file 
`C:\sources\repos\MyApp\MyApp.sln` the extension will look for a file in a path 
`C:\sources\repos\MyApp\MyApp.vssettings` and import it to your Visual Studio.

* The extension can also restore your settings from a file specified in its 
options under 
`Tools->Options->Environment->Solution-specific VSSettings->Default .vssettings file path` 
on solution close. **Note:** This will happen only if there was found and applied a solution 
specific `.vssettings` file on solution load.

* The extension will apply the file from a `Default .vssettings file path` option 
on solution open if `Look for and apply .vssettings file on solution load` 
option is set to `true`, but no custom `.vssettings` file were found and applied. 
If `Default .vssettings file path` option is not set - no changes will occur. 
this can be controlled by the `Apply default .vssettings if solution has no 
specific .vssettings` option

### Help
To find out how to create your custom `.vssettings` file, please, refer to 
[this](https://learn.microsoft.com/en-us/visualstudio/ide/reference/import-and-export-settings-command?view=vs-2022).

## License
[Apache 2.0](https://raw.githubusercontent.com/iron-software/SolutionSpecificVSSettings/master/LICENSE)