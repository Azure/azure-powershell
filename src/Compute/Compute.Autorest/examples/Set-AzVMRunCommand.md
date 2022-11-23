### Example 1: Create or update Run Command on a VM using a storage blob SAS URL
```powershell
Set-AzVMRunCommand -ResourceGroupName MyRG0 -VMName MyVMEE -RunCommandName MyRunCommand -Location EastUS2EUAP -SourceScriptUri "https://myst.blob.core.windows.net/mycontainer/myscript.ps1?sp=r&st=2022-10-27T21:02:35Z&se=2022-10-28T05:02:35Z&spr=https&sv=2021-06-08&sr=b&sig=0I%2FIiYayRwHasfasasfdasdfasdeTsQjLnpZjA%3D"
```

```output
Location      Name         Type
--------      ----         ----
eastus2euap   MyRunCommand Microsoft.Compute/virtualMachines/runCommands
```

Create or update Run Command on a Windows VM using a SAS URL of a storage blob that contains .ps1 script. Note SAS URL must provide read access to the blob. An expiry time of 24 hours is suggested for SAS URL. SAS URLs can be generated on Azure portal using blob's options , or SAS token using New-AzStorageBlobSASToken. If generating SAS token using New-AzStorageBlobSASToken, your SAS URL = base blob URL + "?" + SAS token from New-AzStorageBlobSASToken.

### Example 2: Create or update Run Command on a VM using a local script file.
```powershell
Set-AzVMRunCommand -ResourceGroupName MyRG0 -VMName MyVMEE -RunCommandName MyRunCommand -Location EastUS2EUAP -ScriptLocalPath "C:\MyScriptsDir\MyScript.ps1"
```

```output
Location      Name         Type
--------      ----         ----
eastus2euap   MyRunCommand Microsoft.Compute/virtualMachines/runCommands
```

Create or update Run Command on a VM using a local script file that is on the client machine where cmdlet is executed.

### Example 3: Create or update Run Command on a VM using script text.
```powershell
Set-AzVMRunCommand -ResourceGroupName MyRG0 -VMName MyVML -RunCommandName MyRunCommand2 -Location EastUS2EUAP -SourceScript "id; echo HelloWorld"
```

```output
Location      Name          Type
--------      ----          ----
eastus2euap   MyRunCommand2 Microsoft.Compute/virtualMachines/runCommands
```

Create or update Run Command on a VM passing the script content directly to -SourceScript parameter. Use ';' to delimit multiple commands.

### Example 4: Create or update Run Command on a VM using commandId.
```powershell
Set-AzVMRunCommand -ResourceGroupName MyRG0 -VMName MyVMEE -RunCommandName MyRunCommand -Location EastUS2EUAP -SourceCommandId DisableWindowsUpdate
```

```output
Location      Name         Type
--------      ----         ----
eastus2euap   MyRunCommand Microsoft.Compute/virtualMachines/runCommands
```

Create or update Run Command on a VM using pre-existing commandId. Available commandIds can be retrieved using Get-AzVMRunCommandDocument.

### Example 5: Create or update Run Command on a VM and stream standard output and standard error messages to output and error Append blobs.
```powershell
Set-AzVMRunCommand -ResourceGroupName MyRG0 -VMName MyVML -RunCommandName MyRunCommand3 -Location EastUS2EUAP -ScriptLocalPath "C:\MyScriptsDir\MyScript.ps1" -OutputBlobUri "https://vivst.blob.core.windows.net/vivcontainer/output.txt?sp=racw&st=2022-10-27T22:18:36Z&se=2022-10-28T06:18:36Z&spr=https&sv=2021-06-08&sr=b&sig=HQAu3Bl%2BKMofYTjMo8o5hasfadsfasdF4jIkRJra4S5FlEo%3D" -ErrorBlobUri "https://vivst.blob.core.windows.net/vivcontainer/error.txt?sp=racw&st=2022-10-27T22:18:36Z&se=2022-10-28T06:18:36Z&spr=https&sv=2021-06-08&sr=b&sig=HQAu3Bl%2BKMofYTjMo8o5h%asfasdfgdT%2F4jasfasdf5FlEo%3D"
```

```output
Location      Name          Type
--------      ----         ----
eastus2euap   MyRunCommand3 Microsoft.Compute/virtualMachines/runCommands
```

Create or update Run Command on a VM and stream standard output and standard error messages to output and error Append blobs. Note output and error blobs must be of type AppendBlob and their  SAS URLs must provide read, append, create, write access to the blob. An expiry time of 24 hours is suggested for SAS URL. If output or error blob does not exist, a blob of type AppendBlob will be created.  SAS URLs can be generated on Azure portal using blob's options , or SAS token using New-AzStorageBlobSASToken. If generating SAS token using New-AzStorageBlobSASToken, your SAS URL = base blob URL + "?" + SAS token from New-AzStorageBlobSASToken.

### Example 6: Create or update Run Command on a VM, run the Run Command as a different user using RunAsUser and RunAsPassword parameters.
```powershell
Set-AzVMRunCommand -ResourceGroupName MyRG0 -VMName MyVMEE -RunCommandName MyRunCommand -Location EastUS2EUAP -ScriptLocalPath "C:\MyScriptsDir\MyScript.ps1" -RunAsUser myusername -RunAsPassword mypassword
```

```output
Location      Name         Type
--------      ----         ----
eastus2euap   MyRunCommand Microsoft.Compute/virtualMachines/runCommands
```

Create or update Run Command on a VM, run the Run Command as a different user using RunAsUser and RunAsPassword parameters. For RunAs to work properly, contact admin of VM and make sure user is added on the VM, user has access to resources accessed by the Run Command (Directories, Files, Network etc.), and in case of Windows VM, 'Secondary Logon' service is running on the VM.