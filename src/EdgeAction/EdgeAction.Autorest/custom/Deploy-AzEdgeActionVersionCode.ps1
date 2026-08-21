
<#
.Synopsis
Deploy Edge Action version code from a file.
.Description
Deploy Edge Action version code from a JavaScript or zip file. This command handles file reading, 
automatic zipping (for JavaScript files when using zip deployment), and base64 encoding.
.Example
PS C:\> Deploy-AzEdgeActionVersionCode -ResourceGroupName "myRG" -EdgeActionName "myAction" -Version "v1" -FilePath "handler.js" -DeploymentType "file"

Deploy a JavaScript file directly as file type.
.Example
PS C:\> Deploy-AzEdgeActionVersionCode -ResourceGroupName "myRG" -EdgeActionName "myAction" -Version "v1" -FilePath "handler.js" -DeploymentType "zip"

Deploy a JavaScript file as a zip archive (automatically zipped).
.Example
PS C:\> Deploy-AzEdgeActionVersionCode -ResourceGroupName "myRG" -EdgeActionName "myAction" -Version "v1" -FilePath "code.zip" -DeploymentType "zip"

Deploy an existing zip file.

.Outputs
System.Object
#>
function Deploy-AzEdgeActionVersionCode {
    [OutputType([System.Object])]
    [CmdletBinding(DefaultParameterSetName='DeployFromFile', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Path')]
        [System.String]
        # The name of the resource group. The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Path')]
        [System.String]
        # The name of the Edge Action
        ${EdgeActionName},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Path')]
        [System.String]
        # The version name
        ${Version},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Body')]
        [System.String]
        # Path to JavaScript (.js) or zip (.zip) file
        ${FilePath},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Body')]
        [ValidateSet('file', 'zip')]
        [System.String]
        # Deployment type: 'file' for JavaScript files, 'zip' for zip archives. Auto-detected if not specified.
        ${DeploymentType},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Body')]
        [System.String]
        # The version code deployment name. Defaults to the version name if not specified.
        ${Name},

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
            # Validate file exists
            if (-not (Test-Path -Path $FilePath -PathType Leaf)) {
                throw "File not found: $FilePath"
            }

            # Get file extension
            $fileExtension = [System.IO.Path]::GetExtension($FilePath).ToLower().TrimStart('.')

            # Auto-detect deployment type if not specified
            if (-not $PSBoundParameters.ContainsKey('DeploymentType')) {
                if ($fileExtension -eq 'js') {
                    $DeploymentType = 'file'
                    Write-Verbose "Auto-detected deployment type: file"
                } elseif ($fileExtension -eq 'zip') {
                    $DeploymentType = 'zip'
                    Write-Verbose "Auto-detected deployment type: zip"
                } else {
                    throw "Unable to auto-detect deployment type. File extension '$fileExtension' is not supported. Use .js or .zip files."
                }
            }

            # Validate deployment type and file extension combinations
            if ($DeploymentType -eq 'file') {
                # 'file' deployment type: Only accept .js files
                if ($fileExtension -ne 'js') {
                    throw "Deployment type 'file' only supports JavaScript (.js) files. Provided file has extension: .$fileExtension"
                }
            } elseif ($DeploymentType -eq 'zip') {
                # 'zip' deployment type: Accept both .js (will auto-zip) and .zip files
                if ($fileExtension -notin @('js', 'zip')) {
                    throw "Deployment type 'zip' only supports JavaScript (.js) or zip (.zip) files. Provided file has extension: .$fileExtension"
                }
            }

            Write-Verbose "Processing file: $FilePath (deployment type: $DeploymentType)"

            # Process file based on deployment type and file extension
            $encodedContent = $null

            if ($DeploymentType -eq 'file') {
                # Read and encode the JavaScript file directly
                $fileBytes = [System.IO.File]::ReadAllBytes($FilePath)
                $encodedContent = [System.Convert]::ToBase64String($fileBytes)
                Write-Verbose "Encoded file content to base64 (length: $($encodedContent.Length))"
            } elseif ($DeploymentType -eq 'zip') {
                if ($fileExtension -eq 'zip') {
                    # File is already a zip, just encode it
                    $fileBytes = [System.IO.File]::ReadAllBytes($FilePath)
                    $encodedContent = [System.Convert]::ToBase64String($fileBytes)
                    Write-Verbose "Encoded zip file to base64 (length: $($encodedContent.Length))"
                } elseif ($fileExtension -eq 'js') {
                    # Create a zip file in memory containing the JavaScript file
                    $memoryStream = New-Object System.IO.MemoryStream
                    $zipArchive = New-Object System.IO.Compression.ZipArchive($memoryStream, [System.IO.Compression.ZipArchiveMode]::Create, $true)
                    
                    $entryName = [System.IO.Path]::GetFileName($FilePath)
                    $zipEntry = $zipArchive.CreateEntry($entryName)
                    $zipEntryStream = $zipEntry.Open()
                    $fileStream = [System.IO.File]::OpenRead($FilePath)
                    $fileStream.CopyTo($zipEntryStream)
                    $fileStream.Close()
                    $zipEntryStream.Close()
                    $zipArchive.Dispose()
                    
                    $zipBytes = $memoryStream.ToArray()
                    $memoryStream.Close()
                    
                    $encodedContent = [System.Convert]::ToBase64String($zipBytes)
                    Write-Verbose "Created zip archive and encoded to base64 (length: $($encodedContent.Length))"
                }
            }

            # Use version name as deployment name if not specified
            if (-not $PSBoundParameters.ContainsKey('Name')) {
                $Name = $Version
                Write-Verbose "Using version name as deployment name: $Name"
            }

            # Prepare parameters for the generated cmdlet
            $params = @{
                ResourceGroupName = $ResourceGroupName
                EdgeActionName = $EdgeActionName
                Version = $Version
                Content = $encodedContent
                Name = $Name
            }

            # Add optional parameters if provided
            if ($PSBoundParameters.ContainsKey('SubscriptionId')) { $params['SubscriptionId'] = $SubscriptionId }
            if ($PSBoundParameters.ContainsKey('DefaultProfile')) { $params['DefaultProfile'] = $DefaultProfile }
            if ($PSBoundParameters.ContainsKey('AsJob')) { $params['AsJob'] = $AsJob }
            if ($PSBoundParameters.ContainsKey('Break')) { $params['Break'] = $Break }
            if ($PSBoundParameters.ContainsKey('HttpPipelineAppend')) { $params['HttpPipelineAppend'] = $HttpPipelineAppend }
            if ($PSBoundParameters.ContainsKey('HttpPipelinePrepend')) { $params['HttpPipelinePrepend'] = $HttpPipelinePrepend }
            if ($PSBoundParameters.ContainsKey('NoWait')) { $params['NoWait'] = $NoWait }
            if ($PSBoundParameters.ContainsKey('Proxy')) { $params['Proxy'] = $Proxy }
            if ($PSBoundParameters.ContainsKey('ProxyCredential')) { $params['ProxyCredential'] = $ProxyCredential }
            if ($PSBoundParameters.ContainsKey('ProxyUseDefaultCredentials')) { $params['ProxyUseDefaultCredentials'] = $ProxyUseDefaultCredentials }

            Write-Verbose "Calling internal deployment implementation with Content and Name parameters"
            
            # Call the generated private cmdlet with the DeployExpanded parameter set
            # This is the same cmdlet that would be called for the DeployExpanded parameter set
            $result = Az.EdgeAction.private\Deploy-AzEdgeActionVersionCode_DeployExpanded @params
            
            # The API returns EdgeActionVersionProperties which doesn't include the version name
            # Add the version name to the result object for consistency with other cmdlets
            if ($result -and -not $result.PSObject.Properties['Name']) {
                $result | Add-Member -MemberType NoteProperty -Name 'Name' -Value $Version -Force
            }
            
            # Return the enhanced result to the caller
            return $result
        } catch {
            throw
        }
    }
}
