---
external help file:
Module Name: Az.Arc
online version: https://docs.microsoft.com/en-us/powershell/module/az.arc/new-azarcactivedirectoryconnector
schema: 2.0.0
---

# New-AzArcActiveDirectoryConnector

## SYNOPSIS
Creates or replaces an Active Directory connector resource.

## SYNTAX

```
New-AzArcActiveDirectoryConnector -DataControllerName <String> -Name <String> -ResourceGroupName <String>
 -ActiveDirectoryRealm <String> -DnsNameserverIPAddress <String[]> [-SubscriptionId <String>]
 [-ActiveDirectoryNetbiosDomainName <String>] [-ActiveDirectoryOuDistinguishedName <String>]
 [-ActiveDirectoryServiceAccountProvisioning <AccountProvisioningMode>] [-DnsDomainName <String>]
 [-DnsPreferK8SDnsForPtrLookup] [-DnsReplica <Int64>]
 [-DomainControllerSecondaryDomainController <IActiveDirectoryDomainController[]>]
 [-DomainServiceAccountLoginInformationPassword <String>]
 [-DomainServiceAccountLoginInformationUsername <String>] [-PrimaryDomainControllerHostname <String>]
 [-Status <IActiveDirectoryConnectorStatus>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or replaces an Active Directory connector resource.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -ActiveDirectoryNetbiosDomainName
NETBIOS name of the Active Directory domain.

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

### -ActiveDirectoryOuDistinguishedName
The distinguished name of the Active Directory Organizational Unit.

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

### -ActiveDirectoryRealm
Name (uppercase) of the Active Directory domain that this AD connector will be associated with.

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

### -ActiveDirectoryServiceAccountProvisioning
The service account provisioning mode for this Active Directory connector.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Arc.Support.AccountProvisioningMode
Parameter Sets: (All)
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

### -DataControllerName
The name of the data controller

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -DnsDomainName
DNS domain name for which DNS lookups should be forwarded to the Active Directory DNS servers.

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

### -DnsNameserverIPAddress
List of Active Directory DNS server IP addresses.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DnsPreferK8SDnsForPtrLookup
Flag indicating whether to prefer Kubernetes DNS server response over AD DNS server response for IP address lookups.

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

### -DnsReplica
Replica count for DNS proxy service.
Default value is 1.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DomainControllerSecondaryDomainController
null
To construct, see NOTES section for DOMAINCONTROLLERSECONDARYDOMAINCONTROLLER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Arc.Models.Api20220301Preview.IActiveDirectoryDomainController[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DomainServiceAccountLoginInformationPassword
Login password.

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

### -DomainServiceAccountLoginInformationUsername
Login username.

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

### -Name
The name of the Active Directory connector instance

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ActiveDirectoryConnectorName

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

### -PrimaryDomainControllerHostname
Fully-qualified domain name of a domain controller in the AD domain.

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

### -ResourceGroupName
The name of the Azure resource group

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

### -Status
null
To construct, see NOTES section for STATUS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Arc.Models.Api20220301Preview.IActiveDirectoryConnectorStatus
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the Azure subscription

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

### Microsoft.Azure.PowerShell.Cmdlets.Arc.Models.Api20220301Preview.IActiveDirectoryConnectorResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


DOMAINCONTROLLERSECONDARYDOMAINCONTROLLER <IActiveDirectoryDomainController[]>: null
  - `Hostname <String>`: Fully-qualified domain name of a domain controller in the AD domain.

STATUS <IActiveDirectoryConnectorStatus>: null
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[LastUpdateTime <String>]`: The time that the custom resource was last updated.
  - `[ObservedGeneration <Int64?>]`: The version of the replicaSet associated with the AD connector custom resource.
  - `[State <String>]`: The state of the AD connector custom resource.

## RELATED LINKS

