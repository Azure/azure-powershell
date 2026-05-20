---
<<<<<<<< HEAD:src/SignalR/SignalR/help/Update-AzWebPubSubCustomDomain.md
external help file: Az.SignalR-help.xml
Module Name: Az.SignalR
online version: https://learn.microsoft.com/powershell/module/az.signalr/update-azwebpubsubcustomdomain
schema: 2.0.0
---

# Update-AzWebPubSubCustomDomain

## SYNOPSIS
Update a custom domain.
========
external help file: Az.MachineLearningServices-help.xml
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.machinelearningservices/update-azmlworkspacedatacontainer
schema: 2.0.0
---

# Update-AzMLWorkspaceDataContainer

## SYNOPSIS
Update container.
>>>>>>>> upstream/main:src/MachineLearningServices/MachineLearningServices/help/Update-AzMLWorkspaceDataContainer.md

## SYNTAX

### UpdateExpanded (Default)
```
<<<<<<<< HEAD:src/SignalR/SignalR/help/Update-AzWebPubSubCustomDomain.md
Update-AzWebPubSubCustomDomain -Name <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String>] [-CustomCertificateId <String>] [-DomainName <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
========
Update-AzMLWorkspaceDataContainer -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -WorkspaceName <String> [-Description <String>] [-IsArchived] [-ResourceBaseProperty <Hashtable>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityWorkspaceExpanded
```
Update-AzMLWorkspaceDataContainer -Name <String> -WorkspaceInputObject <IMachineLearningServicesIdentity>
 [-Description <String>] [-IsArchived] [-ResourceBaseProperty <Hashtable>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
>>>>>>>> upstream/main:src/MachineLearningServices/MachineLearningServices/help/Update-AzMLWorkspaceDataContainer.md
```

### UpdateViaIdentityWebPubSubExpanded
```
Update-AzWebPubSubCustomDomain -Name <String> -WebPubSubInputObject <IWebPubSubIdentity>
 [-CustomCertificateId <String>] [-DomainName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
<<<<<<<< HEAD:src/SignalR/SignalR/help/Update-AzWebPubSubCustomDomain.md
Update-AzWebPubSubCustomDomain -InputObject <IWebPubSubIdentity> [-CustomCertificateId <String>]
 [-DomainName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
========
Update-AzMLWorkspaceDataContainer -InputObject <IMachineLearningServicesIdentity> [-Description <String>]
 [-IsArchived] [-ResourceBaseProperty <Hashtable>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
>>>>>>>> upstream/main:src/MachineLearningServices/MachineLearningServices/help/Update-AzMLWorkspaceDataContainer.md
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
<<<<<<<< HEAD:src/SignalR/SignalR/help/Update-AzWebPubSubCustomDomain.md
Update a custom domain.

## EXAMPLES

### Example 1: Update a custom domain
```powershell
$cert = Get-AzWebPubSubCustomCertificate -Name mycustomcert -ResourceGroupName rg -ResourceName wps
Update-AzWebPubSubCustomDomain -Name mydomain -ResourceGroupName rg -ResourceName wps -DomainName wps.manual-test.dev.signalr.azure.com -CustomCertificateId $cert.Id
```

```output
Name     DomainName                                    ProvisioningState
----     ----------                                    -----------------
mydomain wps.manual-test.dev.signalr.azure.com Succeeded
```

Update a custom domain.

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

### -CustomCertificateId
Resource ID.

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

========
Update container.

## EXAMPLES

### Example 1: Update data container
```powershell
Update-AzMLWorkspaceDataContainer -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2 -Name datacontainer-pwsh01 -IsArchived
```

```output
DataType                     : uri_file
Description                  : 
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/data/datacontainer-pwsh01
IsArchived                   : True
LatestVersion                : 
Name                         : datacontainer-pwsh01
NextVersion                  : 1
ResourceBaseProperty         : {
                               }
ResourceGroupName            : ml-test
SystemDataCreatedAt          : 11/5/2025 8:38:23 AM
SystemDataCreatedBy          : User Name (Example)
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/5/2025 8:38:23 AM
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : {
                               }
Type                         : Microsoft.MachineLearningServices/workspaces/data
XmsAsyncOperationTimeout     :
```

This command updates data container.

## PARAMETERS

>>>>>>>> upstream/main:src/MachineLearningServices/MachineLearningServices/help/Update-AzMLWorkspaceDataContainer.md
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

<<<<<<<< HEAD:src/SignalR/SignalR/help/Update-AzWebPubSubCustomDomain.md
### -DomainName
The custom domain name.
========
### -Description
The asset description text.
>>>>>>>> upstream/main:src/MachineLearningServices/MachineLearningServices/help/Update-AzMLWorkspaceDataContainer.md

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

### -InputObject
Identity Parameter

```yaml
<<<<<<<< HEAD:src/SignalR/SignalR/help/Update-AzWebPubSubCustomDomain.md
Type: Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.IWebPubSubIdentity
========
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity
>>>>>>>> upstream/main:src/MachineLearningServices/MachineLearningServices/help/Update-AzMLWorkspaceDataContainer.md
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

<<<<<<<< HEAD:src/SignalR/SignalR/help/Update-AzWebPubSubCustomDomain.md
### -Name
Custom domain name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityWebPubSubExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously
========
### -IsArchived
Is the asset archived?
>>>>>>>> upstream/main:src/MachineLearningServices/MachineLearningServices/help/Update-AzMLWorkspaceDataContainer.md

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

### -Name
Container name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityWorkspaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceBaseProperty
The asset property dictionary.

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

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

<<<<<<<< HEAD:src/SignalR/SignalR/help/Update-AzWebPubSubCustomDomain.md
### -ResourceName
The name of the resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

========
>>>>>>>> upstream/main:src/MachineLearningServices/MachineLearningServices/help/Update-AzMLWorkspaceDataContainer.md
### -SubscriptionId
Gets subscription Id which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

<<<<<<<< HEAD:src/SignalR/SignalR/help/Update-AzWebPubSubCustomDomain.md
### -WebPubSubInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.IWebPubSubIdentity
Parameter Sets: UpdateViaIdentityWebPubSubExpanded
========
### -Tag
Tag dictionary.
Tags can be added, removed, and updated.

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

### -WorkspaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity
Parameter Sets: UpdateViaIdentityWorkspaceExpanded
>>>>>>>> upstream/main:src/MachineLearningServices/MachineLearningServices/help/Update-AzMLWorkspaceDataContainer.md
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

<<<<<<<< HEAD:src/SignalR/SignalR/help/Update-AzWebPubSubCustomDomain.md
========
### -WorkspaceName
Name of Azure Machine Learning workspace.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

>>>>>>>> upstream/main:src/MachineLearningServices/MachineLearningServices/help/Update-AzMLWorkspaceDataContainer.md
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

<<<<<<<< HEAD:src/SignalR/SignalR/help/Update-AzWebPubSubCustomDomain.md
### Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.IWebPubSubIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.ICustomDomain
========
### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IDataContainer
>>>>>>>> upstream/main:src/MachineLearningServices/MachineLearningServices/help/Update-AzMLWorkspaceDataContainer.md

## NOTES

## RELATED LINKS
