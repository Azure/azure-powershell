### Example 1:  Gets a continuous web job by name under specified web app.
```powershell
PS C:\> Get-AzWebAppContinuouWebJob -Name webapp-pwsh01 -ResourceGroupName lucas-rg-test -WebJobName continuewebjob

Name                         Status         Kind WebJobType ResourceGroupName
----                         ------         ---- ---------- -----------------
webapp-pwsh01/continuewebjob PendingRestart                 lucas-rg-test
```

gets a continuous web job by name under specified web app

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

