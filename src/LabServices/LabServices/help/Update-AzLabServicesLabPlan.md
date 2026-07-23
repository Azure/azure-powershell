---
external help file: Az.LabServices-help.xml
Module Name: Az.LabServices
online version: https://learn.microsoft.com/powershell/module/az.labservices/update-azlabserviceslabplan
schema: 2.0.0
---

# Update-AzLabServicesLabPlan

## SYNOPSIS
Operation to update a Lab Plan resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzLabServicesLabPlan -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AllowedRegion <String[]>] [-DefaultAutoShutdownProfileDisconnectDelay <TimeSpan>]
 [-DefaultAutoShutdownProfileIdleDelay <TimeSpan>] [-DefaultAutoShutdownProfileNoConnectDelay <TimeSpan>]
 [-DefaultAutoShutdownProfileShutdownOnDisconnect <String>]
 [-DefaultAutoShutdownProfileShutdownOnIdle <String>]
 [-DefaultAutoShutdownProfileShutdownWhenNotConnected <String>]
 [-DefaultConnectionProfileClientRdpAccess <String>] [-DefaultConnectionProfileClientSshAccess <String>]
 [-DefaultConnectionProfileWebRdpAccess <String>] [-DefaultConnectionProfileWebSshAccess <String>]
 [-DefaultNetworkProfileSubnetId <String>] [-LinkedLmsInstance <String>] [-SharedGalleryId <String>]
 [-SupportInfoEmail <String>] [-SupportInfoInstruction <String>] [-SupportInfoPhone <String>]
 [-SupportInfoUrl <String>] [-Tag <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzLabServicesLabPlan -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzLabServicesLabPlan -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### LabPlan
```
Update-AzLabServicesLabPlan [-SubscriptionId <String>] -LabPlan <LabPlan> [-AllowedRegion <String[]>]
 [-DefaultAutoShutdownProfileDisconnectDelay <TimeSpan>] [-DefaultAutoShutdownProfileIdleDelay <TimeSpan>]
 [-DefaultAutoShutdownProfileNoConnectDelay <TimeSpan>]
 [-DefaultAutoShutdownProfileShutdownOnDisconnect <String>]
 [-DefaultAutoShutdownProfileShutdownOnIdle <String>]
 [-DefaultAutoShutdownProfileShutdownWhenNotConnected <String>] [-DefaultNetworkProfileSubnetId <String>]
 [-LinkedLmsInstance <String>] [-SharedGalleryId <String>] [-SupportInfoEmail <String>]
 [-SupportInfoInstruction <String>] [-SupportInfoPhone <String>] [-SupportInfoUrl <String>] [-Tag <String[]>]
 [-DefaultConnectionProfileClientRdpAccessEnabled <String>]
 [-DefaultConnectionProfileClientSshAccessEnabled <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzLabServicesLabPlan -InputObject <ILabServicesIdentity> [-AllowedRegion <String[]>]
 [-DefaultAutoShutdownProfileDisconnectDelay <TimeSpan>] [-DefaultAutoShutdownProfileIdleDelay <TimeSpan>]
 [-DefaultAutoShutdownProfileNoConnectDelay <TimeSpan>]
 [-DefaultAutoShutdownProfileShutdownOnDisconnect <String>]
 [-DefaultAutoShutdownProfileShutdownOnIdle <String>]
 [-DefaultAutoShutdownProfileShutdownWhenNotConnected <String>]
 [-DefaultConnectionProfileClientRdpAccess <String>] [-DefaultConnectionProfileClientSshAccess <String>]
 [-DefaultConnectionProfileWebRdpAccess <String>] [-DefaultConnectionProfileWebSshAccess <String>]
 [-DefaultNetworkProfileSubnetId <String>] [-LinkedLmsInstance <String>] [-SharedGalleryId <String>]
 [-SupportInfoEmail <String>] [-SupportInfoInstruction <String>] [-SupportInfoPhone <String>]
 [-SupportInfoUrl <String>] [-Tag <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Operation to update a Lab Plan resource.

## EXAMPLES

### Example 1: Update Lab plan
```powershell
Update-AzLabServicesLabPlan -ResourceGroupName "Group Name" -Name "LabPlan Name" -DefaultAutoShutdownProfileShutdownOnDisconnect 'Enabled' -DefaultAutoShutdownProfileDisconnectDelay "00:17:00"
```

```output
Location Name
-------- ----
westus2  LabPlan Name
```

This example updates the lab plan enabling the Shutdown on disconnect with a delay of 17 minutes.

## PARAMETERS

### -AllowedRegion
The allowed regions for the lab creator to use when creating labs using this lab plan.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, LabPlan, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -DefaultAutoShutdownProfileDisconnectDelay
The amount of time a VM will stay running after a user disconnects if this behavior is enabled.

```yaml
Type: System.TimeSpan
Parameter Sets: UpdateExpanded, LabPlan, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultAutoShutdownProfileIdleDelay
The amount of time a VM will idle before it is shutdown if this behavior is enabled.

```yaml
Type: System.TimeSpan
Parameter Sets: UpdateExpanded, LabPlan, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultAutoShutdownProfileNoConnectDelay
The amount of time a VM will stay running before it is shutdown if no connection is made and this behavior is enabled.

```yaml
Type: System.TimeSpan
Parameter Sets: UpdateExpanded, LabPlan, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultAutoShutdownProfileShutdownOnDisconnect
Whether shutdown on disconnect is enabled

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, LabPlan, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultAutoShutdownProfileShutdownOnIdle
Whether a VM will get shutdown when it has idled for a period of time.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, LabPlan, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultAutoShutdownProfileShutdownWhenNotConnected
Whether a VM will get shutdown when it hasn't been connected to after a period of time.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, LabPlan, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultConnectionProfileClientRdpAccess
The enabled access level for Client Access over RDP.

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

### -DefaultConnectionProfileClientRdpAccessEnabled

```yaml
Type: System.String
Parameter Sets: LabPlan
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultConnectionProfileClientSshAccess
The enabled access level for Client Access over SSH.

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

### -DefaultConnectionProfileClientSshAccessEnabled

```yaml
Type: System.String
Parameter Sets: LabPlan
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultConnectionProfileWebRdpAccess
The enabled access level for Web Access over RDP.

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

### -DefaultConnectionProfileWebSshAccess
The enabled access level for Web Access over SSH.

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

### -DefaultNetworkProfileSubnetId
The external subnet resource id

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, LabPlan, UpdateViaIdentityExpanded
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

### -LabPlan

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.LabPlan
Parameter Sets: LabPlan
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LinkedLmsInstance
Base Url of the lms instance this lab plan can link lab rosters against.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, LabPlan, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the lab plan that uniquely identifies it within containing resource group.
Used in resource URIs and in UI.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases: LabPlanName

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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharedGalleryId
Resource ID of the Shared Image Gallery attached to this lab plan.
When saving a lab template virtual machine image it will be persisted in this gallery.
Shared images from the gallery can be made available to use when creating new labs.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, LabPlan, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, LabPlan
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SupportInfoEmail
Support contact email address.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, LabPlan, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SupportInfoInstruction
Support instructions.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, LabPlan, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SupportInfoPhone
Support contact phone number.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, LabPlan, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SupportInfoUrl
Support web address.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, LabPlan, UpdateViaIdentityExpanded
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
Type: System.String[]
Parameter Sets: UpdateExpanded, LabPlan, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.ILabServicesIdentity

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.LabPlan

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.ILabPlan

## NOTES

## RELATED LINKS
