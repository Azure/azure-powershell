
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------


function New-AzAdAppCredential {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphKeyCredential], [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphPasswordCredential])]
    [CmdletBinding(DefaultParameterSetName = 'ApplicationObjectIdWithPasswordParameterSet', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter(ParameterSetName = 'ApplicationObjectIdWithPasswordParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'ApplicationObjectIdWithCertValueParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'ApplicationObjectIdWithCredentialParameterSet', Mandatory)]
        [Alias('Id')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.String]
        ${ObjectId},

        [Parameter(ParameterSetName = 'ApplicationIdWithCertValueParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'ApplicationIdWithPasswordParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'ApplicationIdWithCredentialParameterSet', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.Guid]
        ${ApplicationId},

        [Parameter(ParameterSetName = 'DisplayNameWithPasswordParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'DisplayNameWithCertValueParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'DisplayNameWithCredentialParameterSet', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.String]
        ${DisplayName},

        [Parameter(ParameterSetName = 'ApplicationObjectWithPasswordParameterSet', Mandatory, ValueFromPipeline)]
        [Parameter(ParameterSetName = 'ApplicationObjectWithCertValueParameterSet', Mandatory, ValueFromPipeline)]
        [Parameter(ParameterSetName = 'ApplicationObjectWithCredentialParameterSet', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphApplication]
        ${ApplicationObject},

        [Parameter(ParameterSetName = 'ApplicationObjectIdWithCertValueParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'ApplicationIdWithCertValueParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'DisplayNameWithCertValueParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'ApplicationObjectWithCertValueParameterSet', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.String]
        ${CertValue},

        [Parameter(ParameterSetName = 'ApplicationObjectIdWithCredentialParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationIdWithCredentialParameterSet')]
        [Parameter(ParameterSetName = 'DisplayNameWithCredentialParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationObjectWithCredentialParameterSet')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphKeyCredential[]]
        ${KeyCredentials},

        [Parameter(ParameterSetName = 'ApplicationObjectIdWithCredentialParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationIdWithCredentialParameterSet')]
        [Parameter(ParameterSetName = 'DisplayNameWithCredentialParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationObjectWithCredentialParameterSet')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphPasswordCredential[]]
        ${PasswordCredentials},

        [Parameter(ParameterSetName = 'ApplicationObjectIdWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationIdWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'DisplayNameWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationObjectWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationObjectIdWithPasswordParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationIdWithPasswordParameterSet')]
        [Parameter(ParameterSetName = 'DisplayNameWithPasswordParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationObjectWithPasswordParameterSet')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.DateTime]
        ${StartDate},

        [Parameter(ParameterSetName = 'ApplicationObjectIdWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationIdWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'DisplayNameWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationObjectWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationObjectIdWithPasswordParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationIdWithPasswordParameterSet')]
        [Parameter(ParameterSetName = 'DisplayNameWithPasswordParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationObjectWithPasswordParameterSet')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.DateTime]
        ${EndDate},

        [Parameter(ParameterSetName = 'ApplicationObjectIdWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationIdWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'DisplayNameWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationObjectWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationObjectIdWithPasswordParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationIdWithPasswordParameterSet')]
        [Parameter(ParameterSetName = 'DisplayNameWithPasswordParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationObjectWithPasswordParameterSet')]
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.String]
        ${CustomKeyIdentifier},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )
    
    process {
        if (!$PSBoundParameters['PasswordCredentials'] -and !$PSBoundParameters['KeyCredentials'] ) {
            if ($PSBoundParameters['CertValue']) {
                $credential = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphKeyCredential" `
                                         -Property @{'Key' = ([System.Convert]::FromBase64String($PSBoundParameters['CertValue']));
                                            'Usage'       = 'Verify'; 
                                            'Type'        = 'AsymmetricX509Cert'
                                         }
            } else {
                $credential = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphPasswordCredential"
            }
            if ($PSBoundParameters['CustomKeyIdentifier']) {
                $credential.CustomKeyIdentifier = [System.Convert]::FromBase64String($PSBoundParameters['CustomKeyIdentifier'])
                $null = $PSBoundParameters.Remove('CustomKeyIdentifier')
            }
            if ($PSBoundParameters['StartDate']) {
                $credential.StartDateTime = $PSBoundParameters['StartDate']
                $null = $PSBoundParameters.Remove('StartDate')
            }
            if ($PSBoundParameters['EndDate']) {
                $credential.EndDateTime = $PSBoundParameters['EndDate']
                $null = $PSBoundParameters.Remove('EndDate')
            }
            $credential.KeyId = (New-Guid).ToString()
            if ($PSBoundParameters['CertValue']) {
                $kc = $credential
                $null = $PSBoundParameters.Remove('CertValue')
            } else {
                $pc = $credential
            }
        } elseif ($PSBoundParameters['PasswordCredentials']) {
            $pc = $PSBoundParameters['PasswordCredentials']
            $null = $PSBoundParameters.Remove('PasswordCredentials')
        } else {
            $kc = $PSBoundParameters['KeyCredentials']
            $null = $PSBoundParameters.Remove('PasswordCredentials')
        }

        $param = @{}
        switch ($PSCmdlet.ParameterSetName) {
            { $_ -in 'ApplicationObjectIdWithPasswordParameterSet', 'ApplicationObjectIdWithCredentialParameterSet'} {
                $id = $PSBoundParameters['ObjectId']
                $null = $PSBoundParameters.Remove('ObjectId')
                break
            }
            { $_ -in 'ApplicationIdWithPasswordParameterSet', 'ApplicationIdWithCredentialParameterSet', 'ApplicationIdWithCertValueParameterSet'} {
                $param['ApplicationId'] = $PSBoundParameters['ApplicationId']
                $app = Get-AzAdApplication @param
                if ($app) {
                    $id = $app.Id
                    $null = $PSBoundParameters.Remove('ApplicationId')  
                }
                else {
                    Write-Error "application with application id '$($PSBoundParameters['ApplicationId'])' does not exist."
                    return
                }
                break
            }
            { $_ -in 'DisplayNameWithPasswordParameterSet', 'DisplayNameWithCredentialParameterSet', 'DisplayNameWithCertValueParameterSet'} {
                $param['DisplayName'] = $PSBoundParameters['DisplayName']
                $app = Get-AzAdApplication @param
                if (0 -eq $app.Count) {
                    Write-Error "application with display name '$($PSBoundParameters['DisPlayName'])' does not exist."
                    return
                }
                elseif (1 -eq $app.Count) {
                    $id = $app[0].Id
                    $null = $PSBoundParameters.Remove('DisplayName')
                }
                else {
                    Write-Error "More than one application found with display name '$($PSBoundParameters['DisplayName'])'. Please use the Get-AzAdApplication cmdlet to get the object id of the desired application."
                    return
                }
                break
            }
            { $_ -in 'ApplicationObjectWithPasswordParameterSet', 'ApplicationObjectWithParameterSet', 'ApplicationObjectWithCertValueParameterSet'} {
                $id = $PSBoundParameters['ApplicationObject'].Id
                $null = $PSBoundParameters.Remove('ApplicationObject')
                break
            }
            default {
                break
            }
        }  
        if ($pc) {
            $PSBoundParameters['ApplicationId'] = $id
            foreach ($credential in $pc) {
                $PSBoundParameters['PasswordCredential'] = $credential
                MSGraph.internal\Add-AzAdApplicationPassword @PSBoundParameters
            }
            $null = $PSBoundParameters.Remove('ApplicationId')
            if ($PSBoundParameters['PasswordCredential']) {
                $null = $PSBoundParameters.Remove('PasswordCredential')
            }
        }
        if ($kc) {
            $PSBoundParameters['Id'] = $id
            $PSBoundParameters['KeyCredentials'] = $kc
            MSGraph.internal\Update-AzAdApplication @PSBoundParameters
        }
    }
}