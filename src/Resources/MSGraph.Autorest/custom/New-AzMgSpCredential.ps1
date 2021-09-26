
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


function New-AzMgSpCredential {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphKeyCredential], [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphPasswordCredential])]
    [CmdletBinding(DefaultParameterSetName='SpObjectIdWithPasswordParameterSet', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(ParameterSetName='SpObjectIdWithPasswordParameterSet', Mandatory)]
        [Parameter(ParameterSetName='SpObjectIdWithCertValueParameterSet', Mandatory)]
        [Parameter(ParameterSetName='SpObjectIdWithKeyCredentialParameterSet', Mandatory)]
        [Parameter(ParameterSetName='SpObjectIdWithPasswordCredentialParameterSet', Mandatory)]
        [Alias('Id')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.String]
        ${ObjectId},

        [Parameter(ParameterSetName='SPNWithCertValueParameterSet', Mandatory)]
        [Parameter(ParameterSetName='SPNWithPasswordParameterSet', Mandatory)]
        [Parameter(ParameterSetName='SPNWithKeyCredentialParameterSet', Mandatory)]
        [Parameter(ParameterSetName='SPNWithPasswordCredentialParameterSet', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.String]
        ${ServicePrincipalName},

        [Parameter(ParameterSetName='ServicePrincipalObjectWithCertValueParameterSet', Mandatory, ValueFromPipeline)]
        [Parameter(ParameterSetName='ServicePrincipalObjectWithPasswordParameterSet', Mandatory, ValueFromPipeline)]
        [Parameter(ParameterSetName='ServicePrincipalObjectWithKeyCredentialParameterSet', Mandatory)]
        [Parameter(ParameterSetName='ServicePrincipalObjectWithPasswordCredentialParameterSet', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphServicePrincipal]
        ${ServicePrincipalObject},

        [Parameter(ParameterSetName='SpObjectIdWithCertValueParameterSet', Mandatory)]
        [Parameter(ParameterSetName='SPNWithCertValueParameterSet', Mandatory)]
        [Parameter(ParameterSetName='ServicePrincipalObjectWithCertValueParameterSet', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.String]
        ${CertValue},

        [Parameter(ParameterSetName='SpObjectIdWithKeyCredentialParameterSet', Mandatory)]
        [Parameter(ParameterSetName='SPNWithKeyCredentialParameterSet', Mandatory)]
        [Parameter(ParameterSetName='ServicePrincipalObjectWithKeyCredentialParameterSet', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphKeyCredential]
        ${KeyCredential},

        [Parameter(ParameterSetName='SpObjectIdWithPasswordCredentialParameterSet', Mandatory)]
        [Parameter(ParameterSetName='SPNWithPasswordCredentialParameterSet', Mandatory)]
        [Parameter(ParameterSetName='ServicePrincipalObjectWithPasswordCredentialParameterSet', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphPasswordCredential]
        ${PasswordCredential},

        [Parameter(ParameterSetName='SpObjectIdWithCertValueParameterSet')]
        [Parameter(ParameterSetName='SPNWithCertValueParameterSet')]
        [Parameter(ParameterSetName='ServicePrincipalObjectWithCertValueParameterSet')]
        [Parameter(ParameterSetName='SpObjectIdWithPasswordParameterSet')]
        [Parameter(ParameterSetName='SPNWithPasswordParameterSet')]
        [Parameter(ParameterSetName='ServicePrincipalObjectWithPasswordParameterSet')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.DateTime]
        ${StartDate},

        [Parameter(ParameterSetName='SpObjectIdWithCertValueParameterSet')]
        [Parameter(ParameterSetName='SPNWithCertValueParameterSet')]
        [Parameter(ParameterSetName='ServicePrincipalObjectWithCertValueParameterSet')]
        [Parameter(ParameterSetName='SpObjectIdWithPasswordParameterSet')]
        [Parameter(ParameterSetName='SPNWithPasswordParameterSet')]
        [Parameter(ParameterSetName='ServicePrincipalObjectWithPasswordParameterSet')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.DateTime]
        ${EndDate},

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
        if (!$PSBoundParameters['PasswordCredential'] -and !$PSBoundParameters['KeyCredential']) {
            if ($PSBoundParameters.ContainsKey('CertValue')) {
                $credential = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphKeyCredential" `
                                         -Property @{'Key'=([System.Convert]::FromBase64String($PSBoundParameters['CertValue']));
                                                     'Usage'='Verify'; 
                                                     'Type'='AsymmetricX509Cert'}
            } else {
                $credential = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphPasswordCredential"
            }

            if ($PSBoundParameters.ContainsKey('StartDate')) {
                $credential.StartDateTime = $PSBoundParameters['StartDate']
                $null = $PSBoundParameters.Remove('StartDate')
            }
            if ($PSBoundParameters.ContainsKey('EndDate')) {
                $credential.EndDateTime = $PSBoundParameters['EndDate']
                $null = $PSBoundParameters.Remove('EndDate')

            }
            $credential.KeyId = (New-Guid).ToString()
            if ($PSBoundParameters.ContainsKey('CertValue')) {
                $PSBoundParameters['KeyCredential'] = $credential
                $null = $PSBoundParameters.Remove('CertValue')
            } else {
                $PSBoundParameters['PasswordCredential'] = $credential
            }
        }
        
        switch ($PSCmdlet.ParameterSetName) {
            {$_ -in 'SpObjectIdWithPasswordParameterSet', 'SpObjectIdWithPasswordCredentialParameterSet'} {
                $PSBoundParameters['ServicePrincipalId'] = $PSBoundParameters['ObjectId']
                $null = $PSBoundParameters.Remove('ObjectId')
                MSGraph.internal\Add-AzMgServicePrincipalPassword @PSBoundParameters
                break
            }
            {$_ -in 'SpObjectIdWithCertValueParameterSet', 'SpObjectIdWithKeyCredentialParameterSet'} {
                $PSBoundParameters['ServicePrincipalId'] = $PSBoundParameters['ObjectId']
                $null = $PSBoundParameters.Remove('ObjectId')
                MSGraph.internal\Add-AzMgServicePrincipalKey @PSBoundParameters
                break
            }
            {$_ -in 'SPNWithPasswordParameterSet', 'SPNWithPasswordCredentialParameterSet'} {
                $sp = Get-AzMgServicePrincipal -ServicePrincipalName $PSBoundParameters['ServicePrincipalName'] -Select Id
                if($sp) {
                    $PSBoundParameters['ServicePrincipalId'] = $sp.Id
                    $null = $PSBoundParameters.Remove('ServicePrincipalName')
                    MSGraph.internal\Add-AzMgServicePrincipalPassword @PSBoundParameters
                } else {
                    Write-Error "service principal with name '$($PSBoundParameters['ServicePrincipalName'])' does not exist."
                    return
                }
                break
            }
            {$_ -in 'SPNWithCertValueParameterSet', 'SPNWithKeyCredentialParameterSet'} {
                $sp = Get-AzMgServicePrincipal -ServicePrincipalName $PSBoundParameters['ServicePrincipalName'] -Select Id
                if($sp) {
                    $PSBoundParameters['ServicePrincipalId'] = $sp.Id
                    $null = $PSBoundParameters.Remove('ServicePrincipalName')
                    MSGraph.internal\Add-AzMgServicePrincipalKey @PSBoundParameters
                } else {
                    Write-Error "service principal with name '$($PSBoundParameters['ServicePrincipalName'])' does not exist."
                    return
                }
                break
            }
            {$_ -in 'ServicePrincipalObjectWithPasswordParameterSet', 'ServicePrincipalObjectWithPasswordCredentialParameterSet'} {
                $PSBoundParameters['ServicePrincipalId'] = $PSBoundParameters['ServicePrincipalObject'].Id
                $null = $PSBoundParameters.Remove('ServicePrincipalObject')
                MSGraph.internal\Add-AzMgServicePrincipalPassword @PSBoundParameters
                break
            }
            {$_ -in 'ServicePrincipalObjectWithCertValueParameterSet', 'ServicePrincipalObjectWithKeyCredentialParameterSet'} {
                $PSBoundParameters['ServicePrincipalId'] = $PSBoundParameters['ServicePrincipalObject'].Id
                $null = $PSBoundParameters.Remove('ServicePrincipalObject')
                MSGraph.internal\Add-AzMgServicePrincipalKey @PSBoundParameters
                break
            }
            default {
                break
            }
        }    
    }
}