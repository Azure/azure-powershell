---
external help file:
Module Name: Az.DataTransfer
online version: https://learn.microsoft.com/powershell/module/az.datatransfer/update-azdatatransferconnection
schema: 2.0.0
---

# Update-AzDataTransferConnection

## SYNOPSIS
Update the connection resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDataTransferConnection -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IdentityType <String>] [-Tag <Hashtable>] [-UserAssignedIdentity <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDataTransferConnection -InputObject <IDataTransferIdentity> [-IdentityType <String>]
 [-Tag <Hashtable>] [-UserAssignedIdentity <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzDataTransferConnection -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzDataTransferConnection -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update the connection resource.

## EXAMPLES

### Example 1: Update tags for a connection
```powershell
Update-AzDataTransferConnection -ResourceGroupName ResourceGroup01 -Name Connection01 -Tag @{Environment="Production"; Department="IT"} -Confirm:$false
```

```output
Approver                     : 
DateSubmitted                : 
Direction                    : Receive
FlowType                     : {Mission}
ForceDisabledStatus          : 
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/Connection01
IdentityPrincipalId          : 
IdentityTenantId             : 
IdentityType                 : None
IdentityUserAssignedIdentity : {}
Justification                : Required for data export
LinkStatus                   : Unlinked
LinkedConnectionId           : 
Location                     : EastUS
Name                         : Connection03
Pin                          : 
Pipeline                     : Pipeline01
Policy                       : 
PrimaryContact               : user@example.com
ProvisioningState            : Succeeded
RemoteSubscriptionId         : 
RequirementId                : 123
ResourceGroupName            : ResourceGroup01
Schema                       : 
SchemaUri                    : 
SecondaryContact             : {admin@example.com}
Status                       : InReview
StatusReason                 : 
SystemDataCreatedAt          : 12/12/2099 12:29:23 PM
SystemDataCreatedBy          : test@test.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/12/2099 12:29:23 PM
SystemDataLastModifiedBy     : test@test.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "Environment": "Production",
                                 "Department": "IT",
                                 "creationTime": "2099-12-12T12:12:12.1111111Z",
                                 "vteam": "Experience"
                               }
Type                         : microsoft.azuredatatransfer/connections
```

This example updates the tags for the connection `Connection01` in the resource group `ResourceGroup01`.

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

### -IdentityType
Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: ADT.Models.IDataTransferIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name for the connection to perform the operation on.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases: ConnectionName

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The set of user assigned identities associated with the resource.
The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.
The dictionary values can be empty objects ({}) in requests.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### ADT.Models.IDataTransferIdentity

## OUTPUTS

### ADT.Models.IConnection

## NOTES

## RELATED LINKS

