### Example 1: Create a windows update customizer
```powershell
New-AzImageBuilderTemplateCustomizerObject -WindowsUpdateCustomizer -Name 'WindUpdate' -Filter ("BrowseOnly", "IsInstalled") -SearchCriterion "BrowseOnly=0 and IsInstalled=0" -UpdateLimit 100
```

```output
Name       Filter                    SearchCriterion                UpdateLimit
----       ------                    ---------------                -----------
WindUpdate {BrowseOnly, IsInstalled} BrowseOnly=0 and IsInstalled=0 100
```

This command creates a windows update customizer.

### Example 2: Create a file customizer
```powershell
New-AzImageBuilderTemplateCustomizerObject -FileCustomizer -Name 'filecus' -Destination 'c:\\buildArtifacts\\index.html' -SourceUri 'https://github.com/danielsollondon/azvmimagebuilder/blob/master/quickquickstarts/exampleArtifacts/buildArtifacts/index.html'
```

```output
Name    Destination                    Sha256Checksum SourceUri
----    -----------                    -------------- ---------
filecus c:\\buildArtifacts\\index.html                https://github.com/danielsollondon/azvmimagebuilder/blob/master/quickquickstarts/exampleArtifacts/buildArtifacts/index.html
```

This command creates a file customizer.

### Example 3: Create a powershell customizer
```powershell
New-AzImageBuilderTemplateCustomizerObject -PowerShellCustomizer -Name settingUpMgmtAgtPath -RunElevated $false -Inline "mkdir c:\\buildActions", "echo Azure-Image-Builder-Was-Here  > c:\\buildActions\\buildActionsOutput.txt"
```

```output
Name                 Inline                                                                                                  RunAsSystem  
----                 ------                                                                                                  -----------  
settingUpMgmtAgtPath {mkdir c:\\buildActions, echo Azure-Image-Builder-Was-Here  > c:\\buildActions\\buildActionsOutput.txt}
```

This command creates a powershell customizer.

### Example 4: Create a restart customizer
```powershell
New-AzImageBuilderTemplateCustomizerObject -RestartCustomizer -Name 'restcus' -RestartCommand 'shutdown /f /r /t 0 /c \"packer restart\"' -RestartCheckCommand 'powershell -command "& {Write-Output "restarted."}"' -RestartTimeout '10m'
```

```output
Name    RestartCheckCommand                                 RestartCommand                            RestartTimeout
----    -------------------                                 --------------                            --------------
restcus powershell -command "& {Write-Output "restarted."}" shutdown /f /r /t 0 /c \"packer restart\" 10m
```

This command creates a restart customizer.

### Example 5: Create a shell customizer
```powershell
New-AzImageBuilderTemplateCustomizerObject -ShellCustomizer -Name downloadBuildArtifacts -ScriptUri "https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh" 
```

```output
Name                   Inline ScriptUri
----                   ------ ---------                                                                                       
downloadBuildArtifacts        https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/cus…
```

This command creates a shell customizer.