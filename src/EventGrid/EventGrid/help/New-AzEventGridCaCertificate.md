---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/az.eventgrid/new-azeventgridcacertificate
schema: 2.0.0
---

# New-AzEventGridCaCertificate

## SYNOPSIS
Create a CA certificate with the specified parameters.

## SYNTAX

### CreateExpanded (Default)
```
New-AzEventGridCaCertificate -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Description <String>] [-EncodedCertificate <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzEventGridCaCertificate -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzEventGridCaCertificate -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityNamespaceExpanded
```
New-AzEventGridCaCertificate -Name <String> -NamespaceInputObject <IEventGridIdentity> [-Description <String>]
 [-EncodedCertificate <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzEventGridCaCertificate -InputObject <IEventGridIdentity> [-Description <String>]
 [-EncodedCertificate <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a CA certificate with the specified parameters.

## EXAMPLES

### Example 1: Create a CA certificate with the specified parameters.
```powershell
New-AzEventGridCaCertificate -Name azps-cacert -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -EncodedCertificate "-----BEGIN CERTIFICATE-----
>> ****************
>> ****************
>> ****************
>> -----END CERTIFICATE-----"
```

```output
Name        ResourceGroupName
----        -----------------
azps-cacert AZPS_TEST_GROUP_EVENTGRID
```

Create a CA certificate with the specified parameters.
A usable EncodedCertificate file can be created from this link: https://learn.microsoft.com/en-us/azure/event-grid/mqtt-publish-and-subscribe-cli#generate-sample-client-certificate-and-thumbprint

### Example 2: Create a CA certificate with the specified parameters.
```powershell
$crtData = Get-Content -Path "C:\intermediate_ca.crt" -Raw
New-AzEventGridCaCertificate -Name azps-cacert -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -EncodedCertificate $crtData.Trim("`n")
```

```output
Name        ResourceGroupName
----        -----------------
azps-cacert AZPS_TEST_GROUP_EVENTGRID
```

Create a CA certificate with the specified parameters.
A usable EncodedCertificate file can be created from this link: https://learn.microsoft.com/en-us/azure/event-grid/mqtt-publish-and-subscribe-cli#generate-sample-client-certificate-and-thumbprint

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

### -Description
Description for the CA Certificate resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNamespaceExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncodedCertificate
Base64 encoded PEM (Privacy Enhanced Mail) format certificate data.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNamespaceExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity
Parameter Sets: CreateViaIdentityExpanded
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

### -Name
The CA certificate name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityNamespaceExpanded
Aliases: CaCertificateName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity
Parameter Sets: CreateViaIdentityNamespaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NamespaceName
Name of the namespace.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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

### -ResourceGroupName
The name of the resource group within the user's subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases: ResourceGroup

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ICaCertificate

## NOTES

## RELATED LINKS
