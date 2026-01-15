### Example 1: Get version code as base64-encoded content
```powershell
Get-AzEdgeActionVersionCode -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Version "v1"
```

```output
Content                                                                             Name
-------                                                                             ----
UEsDBBQAAAAIAI... (base64 encoded ZIP content)                                      v1
```

This command retrieves the deployed version code as a base64-encoded ZIP file. The content can be decoded and extracted to view the original source files.

### Example 2: Get version code and save to file
```powershell
Get-AzEdgeActionVersionCode -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Version "v1" -OutputPath "C:\Downloads"
```

```output
Message                      FilePath                    Name
-------                      --------                    ----
Version code saved...        C:\Downloads\v1.zip         v1
```

This command retrieves the deployed version code and saves it directly to a ZIP file in the specified output directory. The file is automatically named using the version name.

