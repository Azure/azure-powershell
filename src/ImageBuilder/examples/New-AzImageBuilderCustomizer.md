### Example 1: {{ Add title here }}
```powershell
PS C:\>  New-AzImageBuilderCustomizer -WindowsUpdateCustomizer -Filter ("BrowseOnly", "IsInstalled") -SearchCriterion "BrowseOnly=0 and IsInstalled=0"  -UpdateLimit 100 -CustomizerName 'WindUpdate'

Name Type          Filter                    SearchCriterion                UpdateLimit
---- ----          ------                    ---------------                -----------
     WindowsUpdate {BrowseOnly, IsInstalled} BrowseOnly=0 and IsInstalled=0 100
```

{{ Add description here }}

### Example 1: {{ Add title here }}
```powershell
PS C:\> $inline = @("mkdir c:\\buildActions", "echo Azure-Image-Builder-Was-Here  > c:\\buildActions\\buildActionsOutput.txt")
PS C:\> New-AzImageBuilderCustomizer -PowerShellCustomizer -CustomizerName settingUpMgmtAgtPath -RunElevated $false -Sha256Checksum ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93 -Inline $inline

Name                 Type       Inline                                                                                                  RunElevated ScriptUri Sha256Checksum                                      ValidExitC                                                                                                                                                                                                                                                                                                                                                                                                                                        e
----                 ----       ------                                                                                                  ----------- --------- --------------                                       --
settingUpMgmtAgtPath PowerShell {mkdir c:\\buildActions, echo Azure-Image-Builder-Was-Here  > c:\\buildActions\\buildActionsOutput.txt} False                 ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> New-AzImageBuilderCustomizer -ShellCustomizer -CustomizerName downloadBuildArtifacts -ScriptUri "https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh" -Sha256Checksum ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93 

Name                   Type  Inline ScriptUri                                                                                                      Sha256Checksum
----                   ----  ------ ---------                                                                                                      --------------
downloadBuildArtifacts Shell        https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93
```

{{ Add description here }}


