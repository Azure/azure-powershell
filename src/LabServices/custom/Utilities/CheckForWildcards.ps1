#This script uses regex to confirm lab plan resource Id
[Microsoft.Azure.PowerShell.Cmdlets.LabServices.DoNotExportAttribute()]
param(
    [Parameter()]
    [System.String]
    ${ResourceId}
)

if (($ResourceId.Contains('*')) -or `
        ($ResourceId.Contains('?')) -or `
        ($ResourceId.Contains('[')) -or `
        ($ResourceId.Contains(']'))) 
{
    return $true
} else {
    return $false
}


