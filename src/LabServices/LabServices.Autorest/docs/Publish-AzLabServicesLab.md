---
external help file:
Module Name: Az.LabServices
online version: https://learn.microsoft.com/powershell/module/az.labservices/publish-azlabserviceslab
schema: 2.0.0
---

# Publish-AzLabServicesLab

## SYNOPSIS
Publish or re-publish a lab.
This will create or update all lab resources, such as virtual machines.

## SYNTAX

### ResourceId (Default)
```
Publish-AzLabServicesLab -ResourceId <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [<CommonParameters>]
```

### Lab
```
Publish-AzLabServicesLab -Lab <Lab> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [<CommonParameters>]
```

### Publish
```
Publish-AzLabServicesLab -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PublishViaIdentity
```
Publish-AzLabServicesLab -InputObject <ILabServicesIdentity> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Publish or re-publish a lab.
This will create or update all lab resources, such as virtual machines.

## EXAMPLES

### Example 1: Publish the lab.
```powershell
Publish-AzLabServicesLab -Name "Lab Name" -ResourceGroupName "Group Name"
```

```output
Location Name
-------- ----
eastus2  Lab Name
```

Publish the lab template.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.ILabServicesIdentity
Parameter Sets: PublishViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Lab
The object of lab service lab to publish.

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

### -Name
The name of the lab that uniquely identifies it within containing lab account.
Used in resource URIs.

```yaml
Type: System.String
Parameter Sets: Publish
Aliases: LabName

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

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Publish, PublishViaIdentity
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
Parameter Sets: Publish
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource Id of lab service lab.

```yaml
Type: System.String
Parameter Sets: ResourceId
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
Type: System.String
Parameter Sets: Lab, Publish, ResourceId
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.ILabServicesIdentity

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Lab

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.ILab

### System.Boolean

## NOTES

## RELATED LINKS

