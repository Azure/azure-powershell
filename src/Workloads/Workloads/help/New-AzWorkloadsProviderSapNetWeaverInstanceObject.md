---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/new-azworkloadsprovidersapnetweaverinstanceobject
schema: 2.0.0
---

# New-AzWorkloadsProviderSapNetWeaverInstanceObject

## SYNOPSIS
Create an in-memory object for SapNetWeaverProviderInstanceProperties.

## SYNTAX

```
New-AzWorkloadsProviderSapNetWeaverInstanceObject [-SapClientId <String>] [-SapHostFileEntry <String[]>]
 [-SapHostname <String>] [-SapInstanceNr <String>] [-SapPassword <String>] [-SapPasswordUri <String>]
 [-SapPortNumber <String>] [-SapSid <String>] [-SapUsername <String>] [-SslCertificateUri <String>]
 [-SslPreference <SslPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for SapNetWeaverProviderInstanceProperties.

## EXAMPLES

### Example 1: Create SAP Netweaver Provider 
```powershell
New-AzWorkloadsProviderSapNetWeaverInstanceObject -SapClientId 000 -SapHostFileEntry '["10.0.82.4 l13appvm0.ams.azure.com l13appvm0","10.0.82.5 l13ascsvm.ams.azure.com l13ascsvm"]' -SapHostname 10.0.82.4 -SapInstanceNr 00 -SapPassword Password@1234 -SapSid L13 -SapUsername AMSUSER -SslPreference Disabled
```

```output
ProviderType SapClientId SapHostFileEntry                                                                                SapHostname
------------ ----------- ----------------                                                                                -----------
SapNetWeaver 000         {["10.0.82.4 l13appvm0.ams.azure.com l13appvm0","10.0.82.5 l13ascsvm.ams.azure.com l13ascsvm"]} 10.0.82.4
```

Create SAP Netweaver Provider for an AMS instance

## PARAMETERS

### -SapClientId
Gets or sets the SAP Client ID.

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

### -SapHostFileEntry
Gets or sets the list of HostFile Entries.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SapHostname
Gets or sets the target virtual machine IP Address/FQDN.

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

### -SapInstanceNr
Gets or sets the instance number of SAP NetWeaver.

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

### -SapPassword
Sets the SAP password.

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

### -SapPasswordUri
Gets or sets the key vault URI to secret with the SAP password.

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

### -SapPortNumber
Gets or sets the SAP HTTP port number.

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

### -SapSid
Gets or sets the SAP System Identifier.

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

### -SapUsername
Gets or sets the SAP user name.

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

### -SslCertificateUri
Gets or sets the blob URI to SSL certificate for the SAP system.

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

### -SslPreference
Gets or sets certificate preference if secure communication is enabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Support.SslPreference
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.SapNetWeaverProviderInstanceProperties

## NOTES

ALIASES

## RELATED LINKS

