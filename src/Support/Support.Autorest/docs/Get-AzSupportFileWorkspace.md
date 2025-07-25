---
external help file:
Module Name: Az.Support
online version: https://learn.microsoft.com/powershell/module/az.support/get-azsupportfileworkspace
schema: 2.0.0
---

# Get-AzSupportFileWorkspace

## SYNOPSIS
Gets details for a specific file workspace in an Azure subscription.

## SYNTAX

### Get (Default)
```
Get-AzSupportFileWorkspace -Name <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSupportFileWorkspace -InputObject <ISupportIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets details for a specific file workspace in an Azure subscription.

## EXAMPLES

### Example 1: Get information about a file workspace
```powershell
Get-AzSupportFileWorkspace -Name "testworkspace"
```

```output
CreatedOn                    : 2/8/2024 3:51:36 PM
ExpirationTime               : 2/9/2024 3:51:36 PM
Id                           : /subscriptions/3bb7379e-e102-4603-a59c-60f5ca39ec55/providers/Microsoft.Support/fileWorkspaces/testworkspace
Name                         : testworkspace
ResourceGroupName            :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Support/fileWorkspaces
```

Gets details for a specific file workspace in an Azure subscription.

### Example 1: Get information about a file workspace for a support ticket
```powershell
Get-AzSupportFileWorkspace -Name "2402084010005835"
```

```output
CreatedOn                    : 2/8/2024 3:51:36 PM
ExpirationTime               : 8/9/2024 3:51:36 PM
Id                           : /subscriptions/3bb7379e-e102-4603-a59c-60f5ca39ec55/providers/Microsoft.Support/fileWorkspaces/2402084010005835
Name                         : 2402084010005835
ResourceGroupName            :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Support/fileWorkspaces
```

Gets details for a specific file workspace under a support ticket in an Azure subscription.

## PARAMETERS

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
File Workspace Name

```yaml
Type: System.String
Parameter Sets: Get
Aliases: FileWorkspaceName

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
Type: System.String[]
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.IFileWorkspaceDetails

## NOTES

## RELATED LINKS

