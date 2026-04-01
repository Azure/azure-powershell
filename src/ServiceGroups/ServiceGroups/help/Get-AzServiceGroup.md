---
external help file: Az.ServiceGroups-help.xml
Module Name: Az.ServiceGroups
online version: https://learn.microsoft.com/powershell/module/az.servicegroups/get-azservicegroup
schema: 2.0.0
---

# Get-AzServiceGroup

## SYNOPSIS
Get the details of the serviceGroup

## SYNTAX

### Get (Default)
```
Get-AzServiceGroup -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzServiceGroup -InputObject <IServiceGroupsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the details of the serviceGroup

## EXAMPLES

### Example 1: Get a service group by name
```powershell
Get-AzServiceGroup -Name "Contoso"
```

```output
DisplayName   : Contoso Group
Id            : /providers/Microsoft.Management/serviceGroups/Contoso
Kind          :
Name          : Contoso
ParentResourceId : /providers/Microsoft.Management/serviceGroups/00000000-0000-0000-0000-000000000000
ProvisioningState : Succeeded
Type          : Microsoft.Management/serviceGroups
```

Gets the details of the service group named 'Contoso', including its display name, parent, and provisioning state.

### Example 2: Get a service group using identity input
```powershell
$inputObject = @{ServiceGroupName = "Contoso"}
Get-AzServiceGroup -InputObject $inputObject
```

```output
DisplayName   : Contoso Group
Id            : /providers/Microsoft.Management/serviceGroups/Contoso
Kind          :
Name          : Contoso
ParentResourceId : /providers/Microsoft.Management/serviceGroups/00000000-0000-0000-0000-000000000000
ProvisioningState : Succeeded
Type          : Microsoft.Management/serviceGroups
```

Gets a service group by constructing an identity object as input.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceGroups.Models.IServiceGroupsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
ServiceGroup Name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ServiceGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceGroups.Models.IServiceGroupsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceGroups.Models.IServiceGroup

## NOTES

## RELATED LINKS
