---
external help file:
Module Name: Az.DataTransfer
online version: https://learn.microsoft.com/powershell/module/az.datatransfer/new-azdatatransferconnection
schema: 2.0.0
---

# New-AzDataTransferConnection

## SYNOPSIS
Create the connection resource.

## SYNTAX

### CreateExpanded (Default)
```
New-AzDataTransferConnection -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-Direction <String>] [-FlowType <String[]>] [-IdentityType <String>]
 [-Justification <String>] [-Pin <String>] [-PipelineName <String>] [-PrimaryContact <String>]
 [-RemoteSubscriptionId <String>] [-RequirementId <String>] [-Schema <ISchema[]>] [-SchemaUri <String[]>]
 [-SecondaryContact <String[]>] [-Tag <Hashtable>] [-UserAssignedIdentity <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDataTransferConnection -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDataTransferConnection -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create the connection resource.

## EXAMPLES

### Example 1: Create a new Receive side connection with basic parameters
```powershell
New-AzDataTransferConnection -ResourceGroupName ResourceGroup01 -PipelineName Pipeline01 -Name Connection01 -Location "EastUS" -Direction "Receive" -FlowType "Mission" -RequirementId 123 -Justification "Required for 
data processing" -RemoteSubscriptionId 11111111-1111-1111-1111-111111111111 -Confirm:$false
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
Justification                : Required for data processing
LinkStatus                   : Unlinked
LinkedConnectionId           : 
Location                     : EastUS
Name                         : Connection01
Pin                          : 
Pipeline                     : Pipeline01
Policy                       : 
PrimaryContact               : 
ProvisioningState            : Succeeded
RemoteSubscriptionId         : 11111111-1111-1111-1111-111111111111
RequirementId                : 123
ResourceGroupName            : ResourceGroup01
Schema                       : 
SchemaUri                    : 
SecondaryContact             : 
Status                       : InReview
StatusReason                 : 
SystemDataCreatedAt          : 10/10/2099 11:47:31 AM
SystemDataCreatedBy          : tes@test.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/10/2099 11:47:31 AM
SystemDataLastModifiedBy     : test@test.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "creationTime": "2099-12-12T12:12:12.1111111Z",
                                 "vteam": "Experience"
                               }
Type                         : microsoft.azuredatatransfer/connections
```

This example creates a new connection named `Connection01` under the pipeline `Pipeline01`in the resource group `ResourceGroup01` located in the `EastUS` region with basic parameters direction, flow type, and justification.

### Example 2: Create a new Send side connection with basic parameters
```powershell
New-AzDataTransferConnection -ResourceGroupName ResourceGroup02 -PipelineName Pipeline01 -Name Connection02 -Location "WestUS" -Direction "Send" -PIN "ABCDEFG" -FlowType "Mission" -Justification "Required for data processing" -Confirm:$false
```

```output
Approver                     : 
DateSubmitted                : 12/12/2099 12:19:41 PM
Direction                    : Send
FlowType                     : {Mission}
ForceDisabledStatus          : 
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup02/providers/Microsoft.AzureDataTransfer/connections/Connection02
IdentityPrincipalId          : 
IdentityTenantId             : 
IdentityType                 : None
IdentityUserAssignedIdentity : {}
Justification                : Required for data processing
LinkStatus                   : 
LinkedConnectionId           : 
Location                     : WestUS
Name                         : Connection02
Pin                          : ABCDEFG
Pipeline                     : Pipeline01
Policy                       : 
PrimaryContact               : 
ProvisioningState            : Succeeded
RemoteSubscriptionId         : 
RequirementId                : 
ResourceGroupName            : ResourceGroup02
Schema                       : 
SchemaUri                    : 
SecondaryContact             : 
Status                       : Approved
StatusReason                 : 
SystemDataCreatedAt          : 12/12/2099 12:19:32 PM
SystemDataCreatedBy          : test@test.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/12/2099 12:19:32 PM
SystemDataLastModifiedBy     : test@test.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "creationTime": "2099-12-12:12:12.1111111Z",
                                 "vteam": "Experience"
                               }
Type                         : microsoft.azuredatatransfer/connections
```

This example creates a new connection named `Connection02` under the pipeline `Pipeline01` in the resource group `ResourceGroup02` located in the `WestUS` region with basic parameters direction, flow type, and justification.

### Example 3: Create a new connection with additional parameters
```powershell
New-AzDataTransferConnection -ResourceGroupName ResourceGroup01 -Name Connection03 -PipelineName Pipeline01 -Location "EastUS" -Direction "Receive" -FlowType "Mission"  -RequirementId 123 -Justification "Required for data export" -PrimaryContact "user@example.com" -SecondaryContact "admin@example.com" -Tag @{Environment="Production"} -Confirm:$false
```

```output
Approver                     : 
DateSubmitted                : 
Direction                    : Receive
FlowType                     : {Mission}
ForceDisabledStatus          : 
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/Connection03
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
                                 "creationTime": "2099-12-12T12:12:12.1111111Z",
                                 "vteam": "Experience"
                               }
Type                         : microsoft.azuredatatransfer/connections
```

This example creates a new connection named `Connection03` in the resource group `ResourceGroup01` with additional parameters such as primary and secondary contacts and resource tags.

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

### -Direction
Direction of data movement

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FlowType
The flow types being requested for this connection

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -Justification
Justification for the connection request

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: (All)
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

### -Pin
PIN to link requests together

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PipelineName
Pipeline to use to transfer data

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrimaryContact
The primary contact for this connection request

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RemoteSubscriptionId
Subscription ID to link cloud subscriptions together

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequirementId
Requirement ID of the connection

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Schema
The schemas for this connection

```yaml
Type: ADT.Models.ISchema[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SchemaUri
The schema URIs for this connection

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecondaryContact
The secondary contacts for this connection request

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
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
Parameter Sets: (All)
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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

## OUTPUTS

### ADT.Models.IConnection

## NOTES

## RELATED LINKS

