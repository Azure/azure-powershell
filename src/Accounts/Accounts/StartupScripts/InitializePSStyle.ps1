try{
    Write-Debug "Initializing PSStyle."
    [Microsoft.WindowsAzure.Commands.Common.PSStyle]::Initialize($Host)
}
catch{
    Write-Warning $_
}