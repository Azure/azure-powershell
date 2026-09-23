---
external help file: Az.LabServices-help.xml
Module Name: Az.LabServices
online version: https://learn.microsoft.com/powershell/module/az.labservices/get-azlabservicesvm
schema: 2.0.0
---

# Get-AzLabServicesVM

## SYNOPSIS
Returns the properties for a lab virtual machine.

## SYNTAX

### List (Default)
```
Get-AzLabServicesVM -LabName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzLabServicesVM -LabName <String> -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Lab
```
Get-AzLabServicesVM [-Name <String>] [-SubscriptionId <String[]>] -Lab <Lab> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityLab
```
Get-AzLabServicesVM -Name <String> -LabInputObject <ILabServicesIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzLabServicesVM -InputObject <ILabServicesIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns the properties for a lab virtual machine.

## EXAMPLES

### Example 1: Gets all the Virtual machines in the lab.
```powershell
Get-AzLabServicesVM -LabName "Lab Name" -ResourceGroupName "Group Name"
```

```output
Name
----
0
1
2
```

Returns all the VMs.

### Example 2: Gets the specific VM in the lab.
```powershell
Get-AzLabServicesVM -LabName "Lab Name" -ResourceGroupName "Group Name" -Name 2
```

```output
Name
----
2
```

Returns the specific VM.

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

### -Filter
The filter to apply to the operation.

```yaml
Type: System.String
Parameter Sets: List
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
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.ILabServicesIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Lab
The object of lab service lab.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Lab
Parameter Sets: Lab
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LabInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.ILabServicesIdentity
Parameter Sets: GetViaIdentityLab
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LabName
The name of the lab that uniquely identifies it within containing lab account.
Used in resource URIs.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The ID of the virtual machine that uniquely identifies it within the containing lab.
Used in resource URIs.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityLab
Aliases: VirtualMachineName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: Lab
Aliases: VirtualMachineName

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
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: List, Get, Lab
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

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.ILabServicesIdentity

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Lab

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.IVirtualMachine

## NOTES

## RELATED LINKS
