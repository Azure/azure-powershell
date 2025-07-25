### Example 1: Create a data flow object
```powershell
New-AzDataFlowObject -Stream Microsoft-Perf,Microsoft-Syslog,Microsoft-WindowsEvent -Destination eastusWorkSpace
```

```output
BuiltInTransform : 
Destination      : {eastusWorkSpace}
OutputStream     : 
Stream           : {Microsoft-Perf, Microsoft-Syslog, Microsoft-WindowsEvent}
TransformKql     : 
```

This command creates a data flow object.

