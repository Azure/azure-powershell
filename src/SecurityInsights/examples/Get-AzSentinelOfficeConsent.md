### Example 1: List all Office Consents
```powershell
PS C:\> Get-AzSentinelOfficeConsent -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"

{{ Add output here }}
```

This command lists all Office Consents under a Microsoft Sentinel workspace.

### Example 2: Get an Office Consent
```powershell
PS C:\> Get-AzSentinelOfficeConsent -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -ConsentId "myOfficeConsentId"

{{ Add output here }}
```

This command gets an Office Consent.

### Example 3: Get an Office Consent by object Id
```powershell
PS C:\> $OfficeConsents = Get-AzSentinelOfficeConsent -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
PS C:\> $OfficeConsents[0] | Get-AzSentinelOfficeConsent

{{ Add output here }}
```

This command gets an Office Consent by object