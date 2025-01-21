### Example 1: Create a new SID mapping for SAP Landscape Monitor
```powershell
New-AzWorkloadsSapLandscapeMonitorSidMappingObject -Name Prod -TopSid "{SID2,SID1}"
```

```output
Name TopSid
---- ------
Prod {{SID2,SID1}}
```

Create a new Metrics Threshold object to be used for creating a SAP Landscape Monitor
