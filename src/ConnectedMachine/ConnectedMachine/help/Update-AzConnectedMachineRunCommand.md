---
external help file: Az.ConnectedMachine-help.xml
Module Name: Az.ConnectedMachine
online version: https://learn.microsoft.com/powershell/module/az.connectedmachine/update-azconnectedmachineruncommand
schema: 2.0.0
---

# Update-AzConnectedMachineRunCommand

## SYNOPSIS
The operation to Create a run command.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzConnectedMachineRunCommand -MachineName <String> -ResourceGroupName <String> -RunCommandName <String>
 [-SubscriptionId <String>] [-AsyncExecution] [-ErrorBlobManagedIdentityClientId <String>]
 [-ErrorBlobManagedIdentityObjectId <String>] [-ErrorBlobUri <String>]
 [-OutputBlobManagedIdentityClientId <String>] [-OutputBlobManagedIdentityObjectId <String>]
 [-OutputBlobUri <String>] [-Parameter <IRunCommandInputParameter[]>]
 [-ProtectedParameter <IRunCommandInputParameter[]>] [-RunAsPassword <String>] [-RunAsUser <String>]
 [-ScriptUriManagedIdentityClientId <String>] [-ScriptUriManagedIdentityObjectId <String>]
 [-SourceCommandId <String>] [-SourceScript <String>] [-SourceScriptUri <String>] [-Tag <Hashtable>]
 [-TimeoutInSecond <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Update
```
Update-AzConnectedMachineRunCommand -MachineName <String> -ResourceGroupName <String> -RunCommandName <String>
 [-SubscriptionId <String>] -RunCommandProperty <IMachineRunCommand> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityMachineExpanded
```
Update-AzConnectedMachineRunCommand -RunCommandName <String> -MachineInputObject <IConnectedMachineIdentity>
 [-AsyncExecution] [-ErrorBlobManagedIdentityClientId <String>] [-ErrorBlobManagedIdentityObjectId <String>]
 [-ErrorBlobUri <String>] [-OutputBlobManagedIdentityClientId <String>]
 [-OutputBlobManagedIdentityObjectId <String>] [-OutputBlobUri <String>]
 [-Parameter <IRunCommandInputParameter[]>] [-ProtectedParameter <IRunCommandInputParameter[]>]
 [-RunAsPassword <String>] [-RunAsUser <String>] [-ScriptUriManagedIdentityClientId <String>]
 [-ScriptUriManagedIdentityObjectId <String>] [-SourceCommandId <String>] [-SourceScript <String>]
 [-SourceScriptUri <String>] [-Tag <Hashtable>] [-TimeoutInSecond <Int32>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityMachine
```
Update-AzConnectedMachineRunCommand -RunCommandName <String> -MachineInputObject <IConnectedMachineIdentity>
 -RunCommandProperty <IMachineRunCommand> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzConnectedMachineRunCommand -InputObject <IConnectedMachineIdentity> [-AsyncExecution]
 [-ErrorBlobManagedIdentityClientId <String>] [-ErrorBlobManagedIdentityObjectId <String>]
 [-ErrorBlobUri <String>] [-OutputBlobManagedIdentityClientId <String>]
 [-OutputBlobManagedIdentityObjectId <String>] [-OutputBlobUri <String>]
 [-Parameter <IRunCommandInputParameter[]>] [-ProtectedParameter <IRunCommandInputParameter[]>]
 [-RunAsPassword <String>] [-RunAsUser <String>] [-ScriptUriManagedIdentityClientId <String>]
 [-ScriptUriManagedIdentityObjectId <String>] [-SourceCommandId <String>] [-SourceScript <String>]
 [-SourceScriptUri <String>] [-Tag <Hashtable>] [-TimeoutInSecond <Int32>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzConnectedMachineRunCommand -InputObject <IConnectedMachineIdentity>
 -RunCommandProperty <IMachineRunCommand> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The operation to Create a run command.

## EXAMPLES

### EXAMPLE 1
```
Update-AzConnectedMachineRunCommand -ResourceGroupName "az-sdk-test" -RunCommandName "myRunCommand3" -MachineName "testmachine" -SubscriptionId "e6fe6705-4c9c-4b54-81d2-e455780e20b8" -Tag @{Tag1="tag1"; Tag2="tag2"}
```

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsyncExecution
Optional.
If set to true, provisioning will complete as soon as script starts and will not wait for script to complete.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityMachineExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityMachineExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityMachineExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityMachineExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IConnectedMachineIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MachineInputObject
Identity Parameter
To construct, see NOTES section for MACHINEINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IConnectedMachineIdentity
Parameter Sets: UpdateViaIdentityMachineExpanded, UpdateViaIdentityMachine
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
Parameter Sets: UpdateExpanded, Update
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutputBlobManagedIdentityClientId
Client Id (GUID value) of the user-assigned managed identity.
ObjectId should not be used if this is provided.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityMachineExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityMachineExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityMachineExpanded, UpdateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IRunCommandInputParameter[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityMachineExpanded, UpdateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IRunCommandInputParameter[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityMachineExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, Update
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityMachineExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityMachineExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, Update, UpdateViaIdentityMachineExpanded, UpdateViaIdentityMachine
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RunCommandProperty
Describes a Run Command
To construct, see NOTES section for RUNCOMMANDPROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IMachineRunCommand
Parameter Sets: Update, UpdateViaIdentityMachine, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ScriptUriManagedIdentityClientId
Client Id (GUID value) of the user-assigned managed identity.
ObjectId should not be used if this is provided.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityMachineExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityMachineExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityMachineExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityMachineExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityMachineExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, Update
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityMachineExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityMachineExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
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
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<IConnectedMachineIdentity\>: Identity Parameter
  \[ExtensionName \<String\>\]: The name of the machine extension.
  \[ExtensionType \<String\>\]: The extensionType of the Extension being received.
  \[GroupName \<String\>\]: The name of the private link resource.
  \[Id \<String\>\]: Resource identity path
  \[LicenseName \<String\>\]: The name of the license.
  \[LicenseProfileName \<String\>\]: The name of the license profile.
  \[Location \<String\>\]: The location of the Extension being received.
  \[MachineName \<String\>\]: The name of the hybrid machine.
  \[MetadataName \<String\>\]: Name of the HybridIdentityMetadata.
  \[Name \<String\>\]: The name of the hybrid machine.
  \[OSType \<String\>\]: Defines the os type.
  \[PerimeterName \<String\>\]: The name, in the format {perimeterGuid}.{associationName}, of the Network Security Perimeter resource.
  \[PrivateEndpointConnectionName \<String\>\]: The name of the private endpoint connection.
  \[PrivateLinkScopeId \<String\>\]: The id (Guid) of the Azure Arc PrivateLinkScope resource.
  \[Publisher \<String\>\]: The publisher of the Extension being received.
  \[ResourceGroupName \<String\>\]: The name of the resource group.
The name is case insensitive.
  \[ResourceUri \<String\>\]: The fully qualified Azure Resource manager identifier of the resource to be connected.
  \[RunCommandName \<String\>\]: The name of the run command.
  \[ScopeName \<String\>\]: The name of the Azure Arc PrivateLinkScope resource.
  \[SubscriptionId \<String\>\]: The ID of the target subscription.
  \[Version \<String\>\]: The version of the Extension being received.

MACHINEINPUTOBJECT \<IConnectedMachineIdentity\>: Identity Parameter
  \[ExtensionName \<String\>\]: The name of the machine extension.
  \[ExtensionType \<String\>\]: The extensionType of the Extension being received.
  \[GroupName \<String\>\]: The name of the private link resource.
  \[Id \<String\>\]: Resource identity path
  \[LicenseName \<String\>\]: The name of the license.
  \[LicenseProfileName \<String\>\]: The name of the license profile.
  \[Location \<String\>\]: The location of the Extension being received.
  \[MachineName \<String\>\]: The name of the hybrid machine.
  \[MetadataName \<String\>\]: Name of the HybridIdentityMetadata.
  \[Name \<String\>\]: The name of the hybrid machine.
  \[OSType \<String\>\]: Defines the os type.
  \[PerimeterName \<String\>\]: The name, in the format {perimeterGuid}.{associationName}, of the Network Security Perimeter resource.
  \[PrivateEndpointConnectionName \<String\>\]: The name of the private endpoint connection.
  \[PrivateLinkScopeId \<String\>\]: The id (Guid) of the Azure Arc PrivateLinkScope resource.
  \[Publisher \<String\>\]: The publisher of the Extension being received.
  \[ResourceGroupName \<String\>\]: The name of the resource group.
The name is case insensitive.
  \[ResourceUri \<String\>\]: The fully qualified Azure Resource manager identifier of the resource to be connected.
  \[RunCommandName \<String\>\]: The name of the run command.
  \[ScopeName \<String\>\]: The name of the Azure Arc PrivateLinkScope resource.
  \[SubscriptionId \<String\>\]: The ID of the target subscription.
  \[Version \<String\>\]: The version of the Extension being received.

PARAMETER \<IRunCommandInputParameter\[\]\>: The parameters used by the script.
  Name \<String\>: The run command parameter name.
  Value \<String\>: The run command parameter value.

PROTECTEDPARAMETER \<IRunCommandInputParameter\[\]\>: The parameters used by the script.
  Name \<String\>: The run command parameter name.
  Value \<String\>: The run command parameter value.

RUNCOMMANDPROPERTY \<IMachineRunCommand\>: Describes a Run Command
  Location \<String\>: The geo-location where the resource lives
  \[Tag \<ITrackedResourceTags\>\]: Resource tags.
    \[(Any) \<String\>\]: This indicates any property can be added to this object.
  \[AsyncExecution \<Boolean?\>\]: Optional.
If set to true, provisioning will complete as soon as script starts and will not wait for script to complete.
  \[ErrorBlobManagedIdentityClientId \<String\>\]: Client Id (GUID value) of the user-assigned managed identity.
ObjectId should not be used if this is provided.
  \[ErrorBlobManagedIdentityObjectId \<String\>\]: Object Id (GUID value) of the user-assigned managed identity.
ClientId should not be used if this is provided.
  \[ErrorBlobUri \<String\>\]: Specifies the Azure storage blob where script error stream will be uploaded.
Use a SAS URI with read, append, create, write access OR use managed identity to provide the VM access to the blob.
Refer errorBlobManagedIdentity parameter.
  \[OutputBlobManagedIdentityClientId \<String\>\]: Client Id (GUID value) of the user-assigned managed identity.
ObjectId should not be used if this is provided.
  \[OutputBlobManagedIdentityObjectId \<String\>\]: Object Id (GUID value) of the user-assigned managed identity.
ClientId should not be used if this is provided.
  \[OutputBlobUri \<String\>\]: Specifies the Azure storage blob where script output stream will be uploaded.
Use a SAS URI with read, append, create, write access OR use managed identity to provide the VM access to the blob.
Refer outputBlobManagedIdentity parameter. 
  \[Parameter \<List\<IRunCommandInputParameter\>\>\]: The parameters used by the script.
    Name \<String\>: The run command parameter name.
    Value \<String\>: The run command parameter value.
  \[ProtectedParameter \<List\<IRunCommandInputParameter\>\>\]: The parameters used by the script.
  \[RunAsPassword \<String\>\]: Specifies the user account password on the machine when executing the run command.
  \[RunAsUser \<String\>\]: Specifies the user account on the machine when executing the run command.
  \[ScriptUriManagedIdentityClientId \<String\>\]: Client Id (GUID value) of the user-assigned managed identity.
ObjectId should not be used if this is provided.
  \[ScriptUriManagedIdentityObjectId \<String\>\]: Object Id (GUID value) of the user-assigned managed identity.
ClientId should not be used if this is provided.
  \[SourceCommandId \<String\>\]: Specifies the commandId of predefined built-in script.
  \[SourceScript \<String\>\]: Specifies the script content to be executed on the machine.
  \[SourceScriptUri \<String\>\]: Specifies the script download location.
It can be either SAS URI of an Azure storage blob with read access or public URI.
  \[TimeoutInSecond \<Int32?\>\]: The timeout in seconds to execute the run command.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.connectedmachine/update-azconnectedmachineruncommand](https://learn.microsoft.com/powershell/module/az.connectedmachine/update-azconnectedmachineruncommand)
