### Example 1: {{ Add title here }}
```powershell
$dateS = Get-Date -Day 23
$dateE = Get-Date -Day 24

Get-AzOrbitalSpacecraftContactAvailable -ResourceGroupName azpstest-gp -SpacecraftName azps-orbitalspacecraft -EndTime $dateE -GroundStationName "KSAT_SVALBARD" -StartTime $dateS -ContactProfileId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azpstest-gp/providers/Microsoft.Orbital/contactProfiles/azps-orbital-contactprofile"
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

