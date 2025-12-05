
<#
.Synopsis
Get Edge Action version code and optionally save to file.
.Description
A long-running resource action that retrieves the version code for an Edge Action version.
When the -OutputPath parameter is specified, the base64-encoded content is decoded and saved 
as a zip file to the specified directory. Otherwise, returns the raw response with base64 content.
.Example
PS C:\> Get-AzEdgeActionVersionCode -ResourceGroupName "myRG" -EdgeActionName "myAction" -Version "v1" -OutputPath "C:\Downloads"

Get the version code and save it as a zip file to C:\Downloads\v1.zip

.Outputs
System.Management.Automation.PSCustomObject
#>
function Get-AzEdgeActionVersionCode {
    [OutputType([System.Management.Automation.PSCustomObject])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(ParameterSetName='GetAndSave', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Path')]
        [System.String]
        # The name of the Edge Action
        ${EdgeActionName},

        [Parameter(ParameterSetName='GetAndSave', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Path')]
        [System.String]
        # The name of the resource group. The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(ParameterSetName='GetAndSave')]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String[]]
        # The ID of the target subscription. The value must be an UUID.
        ${SubscriptionId},

        [Parameter(ParameterSetName='GetAndSave', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Path')]
        [System.String]
        # The name of the Edge Action version
        ${Version},

        [Parameter(ParameterSetName='GetAndSave', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Body')]
        [System.String]
        # Output directory to save the decoded version code as a zip file.
        ${OutputPath},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        try {
            # Build parameters for the internal cmdlet (exclude OutputPath)
            $params = @{}
            
            # Copy all bound parameters except OutputPath
            foreach ($key in $PSBoundParameters.Keys) {
                if ($key -ne 'OutputPath') {
                    $params[$key] = $PSBoundParameters[$key]
                }
            }

            Write-Verbose "Calling internal Get-AzEdgeActionVersionCode cmdlet"
            
            # Call the generated private cmdlet
            $result = Az.EdgeAction.private\Get-AzEdgeActionVersionCode_Get @params

            # Decode and save the file to OutputPath
            if (-not $result) {
                throw "No response returned from the API"
            }

            # Get the base64 encoded content and name from the result
            $content = $result.Content
            $name = $result.Name
            
            if (-not $content) {
                throw "No content returned from the API"
            }
            
            if (-not $name) {
                $name = $Version
            }

            Write-Verbose "Decoding base64 content (length: $($content.Length))"

            # Decode base64 content
            try {
                $decodedContent = [System.Convert]::FromBase64String($content)
            } catch {
                throw "Failed to decode base64 content: $_"
            }

            # Create output directory if it doesn't exist
            if (-not (Test-Path -Path $OutputPath)) {
                Write-Verbose "Creating output directory: $OutputPath"
                New-Item -Path $OutputPath -ItemType Directory -Force | Out-Null
            }

            # Build output file path
            $outputFile = Join-Path -Path $OutputPath -ChildPath "$name.zip"

            # Save the file
            Write-Verbose "Saving version code to: $outputFile"
            try {
                [System.IO.File]::WriteAllBytes($outputFile, $decodedContent)
                Write-Host "Version code saved to: $outputFile"
                
                # Return a custom object with file info
                return [PSCustomObject]@{
                    Message = "Version code saved successfully"
                    FilePath = $outputFile
                    Name = $name
                }
            } catch {
                throw "Failed to save file: $_"
            }
        } catch {
            throw
        }
    }
}
