### Example 1: Specify port 8000 exposed on a container instance with TCP protocol
```powershell
New-AzContainerInstancePortObject -Port 8000 -Protocol TCP
```

```output
Port Protocol
----- --------
8000  TCP
```           

This command specifies port 8000 exposed on the container instance with TCP protocol.
