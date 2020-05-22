### Example 1: Create a windows update customizer
```powershell
PS C:\> New-AzImageBuilderCustomizerObject -WindowsUpdateCustomizer -Filter ("BrowseOnly", "IsInstalled") -SearchCriterion "BrowseOnly=0 and IsInstalled=0"  -UpdateLimit 100 -CustomizerName 'WindUpdate'

Name       Type          Filter                    SearchCriterion                UpdateLimit
----       ----          ------                    ---------------                -----------
WindUpdate WindowsUpdate {BrowseOnly, IsInstalled} BrowseOnly=0 and IsInstalled=0 100
```

This command creates a windows update customizer.

### Example 2: Create a file customizer
```powershell
PS C:\> New-AzImageBuilderCustomizerObject -FileCustomizer -CustomizerName 'filecus' -Sha256Checksum 'ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93' -Destination 'c:\\buildArtifacts\\index.html' -SourceUri 'https://github.com/danielsollondon/azvmimagebuilder/blob/master/quickquickstarts/exampleArtifacts/buildArtifacts/index.html'

Name    Type Destination                    Sha256Checksum                                                   SourceUri
----    ---- -----------                    --------------                                                   ---------
filecus File c:\\buildArtifacts\\index.html ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93 https://github.com/danielsollondon/azvmimagebuilder/blob/master/quickquickstarts/exampleArtifacts/buildArtifacts/index.html

```

This command creates a file customizer.

### Example 3: Create a powershell customizer
```powershell
PS C:\> $inline = @("mkdir c:\\buildActions", "echo Azure-Image-Builder-Was-Here  > c:\\buildActions\\buildActionsOutput.txt")
PS C:\> New-AzImageBuilderCustomizerObject -PowerShellCustomizer -CustomizerName settingUpMgmtAgtPath -RunElevated $false -Sha256Checksum ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93 -Inline $inline

Name                 Type       Inline                                                                                                  RunElevated ScriptUri Sha256Checksum                                      ValidExitC                                                                                                                                                                                                                                                                                                                                                                                                                                        e
----                 ----       ------                                                                                                  ----------- --------- --------------                                       --
settingUpMgmtAgtPath PowerShell {mkdir c:\\buildActions, echo Azure-Image-Builder-Was-Here  > c:\\buildActions\\buildActionsOutput.txt} False                 ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93
```

This command creates a powershell customizer.

### Example 4: Create a restart customizer
```powershell
PS C:\> New-AzImageBuilderCustomizerObject -RestartCustomizer -CustomizerName 'restcus' -RestartCommand 'shutdown /f /r /t 0 /c \"packer restart\"' -RestartCheckCommand 'powershell -command "& {Write-Output "restarted."}"' -RestartTimeout '10m'

Name    Type           RestartCheckCommand                                 RestartCommand                            RestartTimeout
----    ----           -------------------                                 --------------                            --------------
restcus WindowsRestart powershell -command "& {Write-Output "restarted."}" shutdown /f /r /t 0 /c \"packer restart\" 10m
```

This command creates a restart customizer.

### Example 5: Create a shell customizer
```powershell
PS C:\> New-AzImageBuilderCustomizerObject -ShellCustomizer -CustomizerName downloadBuildArtifacts -ScriptUri "https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh" -Sha256Checksum ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93 

Name                   Type  Inline ScriptUri                                                                                                      Sha256Checksum
----                   ----  ------ ---------                                                                                                      --------------
downloadBuildArtifacts Shell        https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93
```

This command creates a shell customizer.

