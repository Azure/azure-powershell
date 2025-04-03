---
external help file:
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/set-azvmssvmruncommand
schema: 2.0.0
---

# Set-AzVmssVMRunCommand

## SYNOPSIS
The operation to create or update the VMSS VM run command.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzVmssVMRunCommand -InstanceId <String> -ResourceGroupName <String> -RunCommandName <String>
 -VMScaleSetName <String> -Location <String> [-SubscriptionId <String>] [-AsyncExecution]
 [-ErrorBlobManagedIdentityClientId <String>] [-ErrorBlobManagedIdentityObjectId <String>]
 [-ErrorBlobUri <String>] [-OutputBlobManagedIdentityClientId <String>]
 [-OutputBlobManagedIdentityObjectId <String>] [-OutputBlobUri <String>]
 [-Parameter <IRunCommandInputParameter[]>] [-ProtectedParameter <IRunCommandInputParameter[]>]
 [-RunAsPassword <String>] [-RunAsUser <String>] [-ScriptUriManagedIdentityClientId <String>]
 [-ScriptUriManagedIdentityObjectId <String>] [-SourceCommandId <String>] [-SourceScript <String>]
 [-SourceScriptUri <String>] [-Tag <Hashtable>] [-TimeoutInSecond <Int32>] [-TreatFailureAsDeploymentFailure]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ScriptLocalPath
```
Set-AzVmssVMRunCommand -InstanceId <String> -ResourceGroupName <String> -RunCommandName <String>
 -VMScaleSetName <String> -Location <String> -ScriptLocalPath <String> [-SubscriptionId <String>]
 [-AsyncExecution] [-ErrorBlobManagedIdentityClientId <String>] [-ErrorBlobManagedIdentityObjectId <String>]
 [-ErrorBlobUri <String>] [-OutputBlobManagedIdentityClientId <String>]
 [-OutputBlobManagedIdentityObjectId <String>] [-OutputBlobUri <String>]
 [-Parameter <IRunCommandInputParameter[]>] [-ProtectedParameter <IRunCommandInputParameter[]>]
 [-RunAsPassword <String>] [-RunAsUser <String>] [-ScriptUriManagedIdentityClientId <String>]
 [-ScriptUriManagedIdentityObjectId <String>] [-Tag <Hashtable>] [-TimeoutInSecond <Int32>]
 [-TreatFailureAsDeploymentFailure] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
The operation to create or update the VMSS VM run command.

## EXAMPLES

### Example 1: Create or update Run Command on a VMSS VM instance using a storage blob SAS URL
```powershell
Set-AzVmssVMRunCommand -ResourceGroupName MyRG0 -VMScaleSetName MyVMSS -InstanceId 0 -RunCommandName MyRunCommand -Location EastUS2EUAP -SourceScriptUri "https://myst.blob.core.windows.net/mycontainer/myscript.ps1?sp=r&st=2022-10-27T21:02:35Z&se=2022-10-28T05:02:35Z&spr=https&sv=2021-06-08&sr=b&sig=0I%2FIiYayRwHasfasasfdasdfasdeTsQjLnpZjA%3D"
```

```output
Location      Name          Type
--------      ----          ----
eastus2euap   MyRunCommand  Microsoft.Compute/virtualMachines/runCommands
```

Create or update Run Command on a Windows VMSS VM instance  using a SAS URL of a storage blob that contains .ps1 script.
Note SAS URL must provide read access to the blob.
An expiry time of 24 hours is suggested for SAS URL.
SAS URLs can be generated on Azure portal using blob's options , or SAS token using New-AzStorageBlobSASToken.
If generating SAS token using New-AzStorageBlobSASToken, your SAS URL = base blob URL + "?" + SAS token from New-AzStorageBlobSASToken.

### Example 2: Create or update Run Command on a VMSS VM instance  using a local script file.
```powershell
Set-AzVmssVMRunCommand -ResourceGroupName MyRG0 -VMScaleSetName MyVMSS -InstanceId 0 -RunCommandName MyRunCommand -Location EastUS2EUAP -ScriptLocalPath "C:\MyScriptsDir\MyScript.ps1"
```

```output
Location      Name          Type
--------      ----          ----
eastus2euap   MyRunCommand  Microsoft.Compute/virtualMachines/runCommands
```

Create or update Run Command on a VMSS VM instance  using a local script file that is on the client machine where cmdlet is executed.

### Example 3: Create or update Run Command on a VMSS VM instance using script text.
```powershell
Set-AzVmssVMRunCommand -ResourceGroupName MyRG0 -VMScaleSetName MyVMSSL -InstanceId 1 -RunCommandName MyRunCommand2 -Location EastUS2EUAP -SourceScript "id; echo HelloWorld"
```

```output
Location      Name           Type
--------      ----           ----
eastus2euap   MyRunCommand2  Microsoft.Compute/virtualMachines/runCommands
```

Create or update Run Command on a VMSS VM instance  passing the script content directly to -SourceScript parameter.
Use ';' to delimit multiple commands.

### Example 4: Create or update Run Command on a VMSS VM instance using commandId.
```powershell
Set-AzVmssVMRunCommand -ResourceGroupName MyRG0 -VMScaleSetName MyVMSS -InstanceId 0 -RunCommandName MyRunCommand -Location EastUS2EUAP -SourceCommandId DisableWindowsUpdate
```

```output
Location      Name          Type
--------      ----          ----
eastus2euap   MyRunCommand  Microsoft.Compute/virtualMachines/runCommands
```

Create or update Run Command on a VMSS VM instance using pre-existing commandId.
Available commandIds can be retrieved using Get-AzVMRunCommandDocument.

### Example 5: Create or update Run Command on a VMSS VM instance and stream standard output and standard error messages to output and error Append blobs.
```powershell
Set-AzVmssVMRunCommand -ResourceGroupName MyRG0 -VMScaleSetName MyVMSS -InstanceId 1 -RunCommandName MyRunCommand3 -Location EastUS2EUAP -ScriptLocalPath "C:\MyScriptsDir\MyScript.ps1" -OutputBlobUri "https://vivst.blob.core.windows.net/vivcontainer/output.txt?sp=racw&st=2022-10-27T22:18:36Z&se=2022-10-28T06:18:36Z&spr=https&sv=2021-06-08&sr=b&sig=HQAu3Bl%2BKMofYTjMo8o5hasfadsfasdF4jIkRJra4S5FlEo%3D" -ErrorBlobUri "https://vivst.blob.core.windows.net/vivcontainer/error.txt?sp=racw&st=2022-10-27T22:18:36Z&se=2022-10-28T06:18:36Z&spr=https&sv=2021-06-08&sr=b&sig=HQAu3Bl%2BKMofYTjMo8o5h%asfasdfgdT%2F4jasfasdf5FlEo%3D"
```

```output
Location      Name           Type
--------      ----           ----
eastus2euap   MyRunCommand3  Microsoft.Compute/virtualMachines/runCommands
```

Create or update Run Command on a VMSS VM instance and stream standard output and standard error messages to output and error Append blobs.
Note output and error blobs must be of type AppendBlob and their  SAS URLs must provide read, append, create, write access to the blob.
An expiry time of 24 hours is suggested for SAS URL.
If output or error blob does not exist, a blob of type AppendBlob will be created.
SAS URLs can be generated on Azure portal using blob's options , or SAS token using New-AzStorageBlobSASToken.
If generating SAS token using New-AzStorageBlobSASToken, your SAS URL = base blob URL + "?" + SAS token from New-AzStorageBlobSASToken.

### Example 6: Create or update Run Command on a VMSS VM instance, run the Run Command as a different user using RunAsUser and RunAsPassword parameters.
```powershell
Set-AzVmssVMRunCommand -ResourceGroupName MyRG0 -VMScaleSetName MyVMSS -InstanceId 1 -RunCommandName MyRunCommand -Location EastUS2EUAP -ScriptLocalPath "C:\MyScriptsDir\MyScript.ps1" -RunAsUser myusername -RunAsPassword mypassword
```

```output
Location      Name          Type
--------      ----          ----
eastus2euap   MyRunCommand  Microsoft.Compute/virtualMachines/runCommands
```

Create or update Run Command on a VMSS VM instance, run the Run Command as a different user using RunAsUser and RunAsPassword parameters.
For RunAs to work properly, contact admin of VM and make sure user is added on the VM, user has access to resources accessed by the Run Command (Directories, Files, Network etc.), and in case of Windows VM, 'Secondary Logon' service is running on the VM.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsyncExecution
Optional.
If set to true, provisioning will complete as soon as the script starts and will not wait for script to complete.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ErrorBlobManagedIdentityClientId
Client Id (GUID value) of the user-assigned managed identity.
ObjectId should not be used if this is provided.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ErrorBlobManagedIdentityObjectId
Object Id (GUID value) of the user-assigned managed identity.
ClientId should not be used if this is provided.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ErrorBlobUri
Specifies the Azure storage blob where script error stream will be uploaded.
Use a SAS URI with read, append, create, write access OR use managed identity to provide the VM access to the blob.
Refer errorBlobManagedIdentity parameter.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstanceId
The instance ID of the virtual machine.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Resource location

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutputBlobManagedIdentityClientId
Client Id (GUID value) of the user-assigned managed identity.
ObjectId should not be used if this is provided.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutputBlobManagedIdentityObjectId
Object Id (GUID value) of the user-assigned managed identity.
ClientId should not be used if this is provided.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutputBlobUri
Specifies the Azure storage blob where script output stream will be uploaded.
Use a SAS URI with read, append, create, write access OR use managed identity to provide the VM access to the blob.
Refer outputBlobManagedIdentity parameter.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
The parameters used by the script.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20230701.IRunCommandInputParameter[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProtectedParameter
The parameters used by the script.
To construct, see NOTES section for PROTECTEDPARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20230701.IRunCommandInputParameter[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RunAsPassword
Specifies the user account password on the VM when executing the run command.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RunAsUser
Specifies the user account on the VM when executing the run command.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RunCommandName
The name of the virtual machine run command.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScriptLocalPath


```yaml
Type: System.String
Parameter Sets: ScriptLocalPath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScriptUriManagedIdentityClientId
Client Id (GUID value) of the user-assigned managed identity.
ObjectId should not be used if this is provided.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScriptUriManagedIdentityObjectId
Object Id (GUID value) of the user-assigned managed identity.
ClientId should not be used if this is provided.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceCommandId
Specifies a commandId of predefined built-in script.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceScript
Specifies the script content to be executed on the VM.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceScriptUri
Specifies the script download location.
It can be either SAS URI of an Azure storage blob with read access or public URI.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeoutInSecond
The timeout in seconds to execute the run command.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TreatFailureAsDeploymentFailure
Optional.
If set to true, any failure in the script will fail the deployment and ProvisioningState will be marked as Failed.
If set to false, ProvisioningState would only reflect whether the run command was run or not by the extensions platform, it would not indicate whether script failed in case of script failures.
See instance view of run command in case of script failures to see executionMessage, output, error: https://aka.ms/runcommandmanaged#get-execution-status-and-results

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMScaleSetName
The name of the VM scale set.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20230701.IVirtualMachineRunCommand

## NOTES

## RELATED LINKS

