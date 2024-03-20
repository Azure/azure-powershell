---
external help file: Az.ConnectedMachine-help.xml
Module Name: Az.ConnectedMachine
online version: https://learn.microsoft.com/powershell/module/az.connectedmachine/new-azconnectedmachineruncommand
schema: 2.0.0
---

# New-AzConnectedMachineRunCommand

## SYNOPSIS
The operation to Create a run command.

## SYNTAX

### CreateExpanded (Default)
```
New-AzConnectedMachineRunCommand -MachineName <String> -ResourceGroupName <String> -RunCommandName <String>
 [-SubscriptionId <String>] -Location <String> [-AsyncExecution] [-ErrorBlobManagedIdentityClientId <String>]
 [-ErrorBlobManagedIdentityObjectId <String>] [-ErrorBlobUri <String>]
 [-OutputBlobManagedIdentityClientId <String>] [-OutputBlobManagedIdentityObjectId <String>]
 [-OutputBlobUri <String>] [-Parameter <IRunCommandInputParameter[]>]
 [-ProtectedParameter <IRunCommandInputParameter[]>] [-RunAsPassword <String>] [-RunAsUser <String>]
 [-ScriptUriManagedIdentityClientId <String>] [-ScriptUriManagedIdentityObjectId <String>]
 [-SourceCommandId <String>] [-SourceScript <String>] [-SourceScriptUri <String>] [-Tag <Hashtable>]
 [-TimeoutInSecond <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ScriptLocalPath
```
New-AzConnectedMachineRunCommand -MachineName <String> -ResourceGroupName <String> -RunCommandName <String>
 [-SubscriptionId <String>] -Location <String> [-AsyncExecution] [-ErrorBlobManagedIdentityClientId <String>]
 [-ErrorBlobManagedIdentityObjectId <String>] [-ErrorBlobUri <String>]
 [-OutputBlobManagedIdentityClientId <String>] [-OutputBlobManagedIdentityObjectId <String>]
 [-OutputBlobUri <String>] [-Parameter <IRunCommandInputParameter[]>]
 [-ProtectedParameter <IRunCommandInputParameter[]>] [-RunAsPassword <String>] [-RunAsUser <String>]
 [-ScriptUriManagedIdentityClientId <String>] [-ScriptUriManagedIdentityObjectId <String>]
 [-SourceCommandId <String>] [-SourceScript <String>] [-SourceScriptUri <String>] [-Tag <Hashtable>]
 [-TimeoutInSecond <Int32>] [-ScriptLocalPath <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzConnectedMachineRunCommand -MachineName <String> -ResourceGroupName <String> -RunCommandName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzConnectedMachineRunCommand -MachineName <String> -ResourceGroupName <String> -RunCommandName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Create
```
New-AzConnectedMachineRunCommand -MachineName <String> -ResourceGroupName <String> -RunCommandName <String>
 [-SubscriptionId <String>] -RunCommandProperty <IMachineRunCommand> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityMachineExpanded
```
New-AzConnectedMachineRunCommand -RunCommandName <String> -MachineInputObject <IConnectedMachineIdentity>
 -Location <String> [-AsyncExecution] [-ErrorBlobManagedIdentityClientId <String>]
 [-ErrorBlobManagedIdentityObjectId <String>] [-ErrorBlobUri <String>]
 [-OutputBlobManagedIdentityClientId <String>] [-OutputBlobManagedIdentityObjectId <String>]
 [-OutputBlobUri <String>] [-Parameter <IRunCommandInputParameter[]>]
 [-ProtectedParameter <IRunCommandInputParameter[]>] [-RunAsPassword <String>] [-RunAsUser <String>]
 [-ScriptUriManagedIdentityClientId <String>] [-ScriptUriManagedIdentityObjectId <String>]
 [-SourceCommandId <String>] [-SourceScript <String>] [-SourceScriptUri <String>] [-Tag <Hashtable>]
 [-TimeoutInSecond <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityMachine
```
New-AzConnectedMachineRunCommand -RunCommandName <String> -MachineInputObject <IConnectedMachineIdentity>
 -RunCommandProperty <IMachineRunCommand> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzConnectedMachineRunCommand -InputObject <IConnectedMachineIdentity> -Location <String> [-AsyncExecution]
 [-ErrorBlobManagedIdentityClientId <String>] [-ErrorBlobManagedIdentityObjectId <String>]
 [-ErrorBlobUri <String>] [-OutputBlobManagedIdentityClientId <String>]
 [-OutputBlobManagedIdentityObjectId <String>] [-OutputBlobUri <String>]
 [-Parameter <IRunCommandInputParameter[]>] [-ProtectedParameter <IRunCommandInputParameter[]>]
 [-RunAsPassword <String>] [-RunAsUser <String>] [-ScriptUriManagedIdentityClientId <String>]
 [-ScriptUriManagedIdentityObjectId <String>] [-SourceCommandId <String>] [-SourceScript <String>]
 [-SourceScriptUri <String>] [-Tag <Hashtable>] [-TimeoutInSecond <Int32>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzConnectedMachineRunCommand -InputObject <IConnectedMachineIdentity>
 -RunCommandProperty <IMachineRunCommand> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The operation to Create a run command.

## EXAMPLES

### Example 1: Create a run-command for a machine
```powershell
New-AzConnectedMachineRunCommand -ResourceGroupName "az-sdk-test" -Location "eastus2euap" -SourceScript "Write-Host Hello World!" -RunCommandName "myRunCommand3" -MachineName "testmachine" -SubscriptionId "e6fe6705-4c9c-4b54-81d2-e455780e20b8"
```

```output
AsyncExecution                    : False
ErrorBlobManagedIdentityClientId  :
ErrorBlobManagedIdentityObjectId  :
ErrorBlobUri                      :
Id                                : /subscriptions/e6fe6705-4c9c-4b54-81d2-e455780e20b8/resourceGroups/az-sdk-test/prov
                                    iders/Microsoft.HybridCompute/machines/testmachine/runcommands/myRunCommand3
InstanceViewEndTime               : 12/5/2023 7:27:26 PM
InstanceViewError                 :
InstanceViewExecutionMessage      : RunCommand script execution completed
InstanceViewExecutionState        : Succeeded
InstanceViewExitCode              : 0
InstanceViewOutput                : Hello World!
InstanceViewStartTime             : 12/5/2023 7:27:24 PM
InstanceViewStatuses              :
Location                          : eastus2euap
Name                              : myRunCommand3
OutputBlobManagedIdentityClientId :
OutputBlobManagedIdentityObjectId :
OutputBlobUri                     :
Parameter                         :
ProtectedParameter                :
ProvisioningState                 : Succeeded
ResourceGroupName                 : az-sdk-test
RunAsPassword                     :
RunAsUser                         :
ScriptUriManagedIdentityClientId  :
ScriptUriManagedIdentityObjectId  :
SourceCommandId                   :
SourceScript                      : Write-Host Hello World!
SourceScriptUri                   :
SystemDataCreatedAt               :
SystemDataCreatedBy               :
SystemDataCreatedByType           :
SystemDataLastModifiedAt          :
SystemDataLastModifiedBy          :
SystemDataLastModifiedByType      :
Tag                               : {
                                    }
TimeoutInSecond                   : 0
Type                              : Microsoft.HybridCompute/machines/runcommands
```

Create a run-command for a machine

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
If set to true, provisioning will complete as soon as script starts and will not wait for script to complete.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, ScriptLocalPath, CreateViaIdentityMachineExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, ScriptLocalPath, CreateViaIdentityMachineExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, ScriptLocalPath, CreateViaIdentityMachineExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, ScriptLocalPath, CreateViaIdentityMachineExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IConnectedMachineIdentity
Parameter Sets: CreateViaIdentityExpanded, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded, ScriptLocalPath, CreateViaIdentityMachineExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MachineInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IConnectedMachineIdentity
Parameter Sets: CreateViaIdentityMachineExpanded, CreateViaIdentityMachine
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MachineName
The name of the hybrid machine.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, ScriptLocalPath, CreateViaJsonString, CreateViaJsonFilePath, Create
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
Parameter Sets: CreateExpanded, ScriptLocalPath, CreateViaIdentityMachineExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, ScriptLocalPath, CreateViaIdentityMachineExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, ScriptLocalPath, CreateViaIdentityMachineExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
The parameters used by the script.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IRunCommandInputParameter[]
Parameter Sets: CreateExpanded, ScriptLocalPath, CreateViaIdentityMachineExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProtectedParameter
The parameters used by the script.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IRunCommandInputParameter[]
Parameter Sets: CreateExpanded, ScriptLocalPath, CreateViaIdentityMachineExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, ScriptLocalPath, CreateViaJsonString, CreateViaJsonFilePath, Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RunAsPassword
Specifies the user account password on the machine when executing the run command.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, ScriptLocalPath, CreateViaIdentityMachineExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RunAsUser
Specifies the user account on the machine when executing the run command.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, ScriptLocalPath, CreateViaIdentityMachineExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RunCommandName
The name of the run command.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, ScriptLocalPath, CreateViaJsonString, CreateViaJsonFilePath, Create, CreateViaIdentityMachineExpanded, CreateViaIdentityMachine
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RunCommandProperty
Describes a Run Command

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IMachineRunCommand
Parameter Sets: Create, CreateViaIdentityMachine, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ScriptLocalPath

```yaml
Type: System.String
Parameter Sets: ScriptLocalPath
Aliases:

Required: False
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
Parameter Sets: CreateExpanded, ScriptLocalPath, CreateViaIdentityMachineExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, ScriptLocalPath, CreateViaIdentityMachineExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceCommandId
Specifies the commandId of predefined built-in script.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, ScriptLocalPath, CreateViaIdentityMachineExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceScript
Specifies the script content to be executed on the machine.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, ScriptLocalPath, CreateViaIdentityMachineExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, ScriptLocalPath, CreateViaIdentityMachineExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, ScriptLocalPath, CreateViaJsonString, CreateViaJsonFilePath, Create
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, ScriptLocalPath, CreateViaIdentityMachineExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, ScriptLocalPath, CreateViaIdentityMachineExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IConnectedMachineIdentity

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IMachineRunCommand

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IMachineRunCommand

## NOTES

## RELATED LINKS
