# Offline regression tests for the client-side workarounds in custom/ and the README directives.
# They exercise the model classes directly (JSON in, JSON out), so they run in every test mode
# without a service connection or a recording.

if (-not ('Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.RecoveryPlan' -as [type])) {
    Import-Module (Join-Path $PSScriptRoot '..\Az.Resiliency.psd1') -Force
}

Describe 'Az.Resiliency client workarounds' {
    BeforeAll {
        $models = 'Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models'
        function Get-ModelType([string]$Name) {
            return "$models.$Name" -as [type]
        }
        # Mode used by the generated request bodies (PUT/PATCH/POST).
        $requestMode = [Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Runtime.SerializationMode]::IncludeCreate -bor
            [Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Runtime.SerializationMode]::IncludeUpdate
        function ConvertTo-RequestJson([object]$Model) {
            return $Model.ToJson($null, $requestMode).ToString() | ConvertFrom-Json
        }
        # The service sometimes returns "properties" as a JSON-encoded string instead of an object.
        function ConvertTo-StringEncodedResponse([hashtable]$Properties) {
            return @{
                id         = '/providers/Microsoft.AzureResilienceManagement/locations/eastus2euap/operationStatuses/op1'
                name       = 'op1'
                status     = 'Succeeded'
                properties = ($Properties | ConvertTo-Json -Depth 10 -Compress)
            } | ConvertTo-Json -Depth 10 -Compress
        }
    }

    Context 'Recovery-plan action job ID (RecoveryPlanActionBaseResponse)' {
        It 'Reads jobId from string-encoded properties' {
            $json = ConvertTo-StringEncodedResponse @{ jobId = 'job-encoded' }
            (Get-ModelType 'RecoveryPlanActionBaseResponse')::FromJsonString($json).JobId | Should -Be 'job-encoded'
        }
        It 'Reads jobId in the documented shape' {
            (Get-ModelType 'RecoveryPlanActionBaseResponse')::FromJsonString('{"jobId":"job-spec"}').JobId | Should -Be 'job-spec'
        }
        It 'Prefers the documented jobId when both are present' {
            $json = '{"jobId":"job-spec","properties":"{\"jobId\":\"job-encoded\"}"}'
            (Get-ModelType 'RecoveryPlanActionBaseResponse')::FromJsonString($json).JobId | Should -Be 'job-spec'
        }
        It 'Leaves jobId empty when properties is not valid JSON' {
            { (Get-ModelType 'RecoveryPlanActionBaseResponse')::FromJsonString('{"properties":"not-json"}') } | Should -Not -Throw
            (Get-ModelType 'RecoveryPlanActionBaseResponse')::FromJsonString('{"properties":"not-json"}').JobId | Should -BeNullOrEmpty
        }
    }

    Context 'Validate-for-failover/reprotect qualifications (ValidateForRecoveryOperationBaseResponse)' {
        It 'Reads recoveryResourceQualifications from string-encoded properties' {
            $json = ConvertTo-StringEncodedResponse @{
                recoveryResourceQualifications = @(
                    @{ recoveryResource = @{ properties = @{} }; operationQualificationDetails = @{} },
                    @{ recoveryResource = @{ properties = @{} }; operationQualificationDetails = @{} }
                )
            }
            $result = (Get-ModelType 'ValidateForRecoveryOperationBaseResponse')::FromJsonString($json)
            @($result.RecoveryResourceQualification).Count | Should -Be 2
        }
    }

    Context 'Recovery plan planType (README directive)' {
        BeforeAll {
            $planJson = '{"id":"/providers/Microsoft.Management/serviceGroups/sg1/providers/Microsoft.AzureResilienceManagement/recoveryPlans/p1","name":"p1","properties":{"planType":"Zonal","planDescription":"original"}}'
        }
        It 'Reads planType from a GET response' {
            (Get-ModelType 'RecoveryPlan')::FromJsonString($planJson).PlanType | Should -Be 'Zonal'
        }
        It 'Keeps planType in the body that Update-AzResiliencyRecoveryPlan sends back (GET + PUT)' {
            $plan = (Get-ModelType 'RecoveryPlan')::FromJsonString($planJson)
            $body = ConvertTo-RequestJson $plan
            $body.properties.planType | Should -Be 'Zonal'
            $body.properties.planDescription | Should -Be 'original'
        }
    }

    Context 'Goal resource id (GoalResource, UpdateGoalResourceRequest)' {
        BeforeAll {
            $goalResourceId = '/providers/Microsoft.Management/serviceGroups/sg1/providers/Microsoft.AzureResilienceManagement/goalAssignments/ga1/goalResources/g1'
            function New-GoalResourceList([object[]]$Items) {
                $list = [System.Collections.Generic.List[Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IGoalResource]]::new()
                foreach ($item in $Items) { $list.Add($item) }
                return , $list
            }
        }
        It 'Sends the goal resource id in the request body' {
            $resource = (Get-ModelType 'GoalResource')::FromJsonString((@{
                id = $goalResourceId
                properties = @{ resourceArmId = '/vm1'; zonalResiliency = @{ goalParticipation = 'Excluded'; attestationStatus = 'ManuallyAttested' } }
            } | ConvertTo-Json -Depth 10))
            $request = (Get-ModelType 'UpdateGoalResourceRequest')::new()
            $request.Resource = New-GoalResourceList @($resource)
            $body = ConvertTo-RequestJson $request
            $body.resources[0].id | Should -Be $goalResourceId
            $body.resources[0].properties.zonalResiliency.goalParticipation | Should -Be 'Excluded'
        }
        It 'Rejects a goal resource without an id before the request is sent' {
            $resource = (Get-ModelType 'GoalResource')::FromJsonString('{"properties":{"resourceArmId":"/vm1"}}')
            $request = (Get-ModelType 'UpdateGoalResourceRequest')::new()
            $request.Resource = New-GoalResourceList @($resource)
            { ConvertTo-RequestJson $request } | Should -Throw 'Resource[0] has no Id'
        }
    }

    Context 'Goal assignment action results (UpdateGoalResourceResponse, RecommendCapacityResult)' {
        It 'Reads update-goal-resource results from string-encoded properties' {
            $json = ConvertTo-StringEncodedResponse @{
                resources = @(@{
                    id = '/goalResources/g1'
                    properties = @{ resourceArmId = '/vm1'; zonalResiliency = @{ goalParticipation = 'Included' } }
                })
            }
            $result = (Get-ModelType 'UpdateGoalResourceResponse')::FromJsonString($json)
            @($result.Resource).Count | Should -Be 1
            $result.Resource[0].Id | Should -Be '/goalResources/g1'
            $result.Resource[0].ZonalResiliencyGoalParticipation | Should -Be 'Included'
        }
        It 'Reads update-goal-resource results in the documented shape' {
            $result = (Get-ModelType 'UpdateGoalResourceResponse')::FromJsonString('{"resources":[{"id":"/goalResources/g2","properties":{"resourceArmId":"/vm2"}}]}')
            $result.Resource[0].Id | Should -Be '/goalResources/g2'
        }
        It 'Reads recommend-capacity results from string-encoded properties' {
            $json = ConvertTo-StringEncodedResponse @{
                resourceCapacities = @(@{ resourceId = '/vm1'; skuName = 'Standard_D2s_v5'; location = 'eastus2euap' })
                recommendations    = @()
                agentError         = $null
            }
            $result = (Get-ModelType 'RecommendCapacityResult')::FromJsonString($json)
            @($result.ResourceCapacity).Count | Should -Be 1
            $result.ResourceCapacity[0].ResourceId | Should -Be '/vm1'
        }
        It 'Reads recommend-capacity results in the documented shape' {
            $result = (Get-ModelType 'RecommendCapacityResult')::FromJsonString('{"resourceCapacities":[{"resourceId":"/vm2"}],"recommendations":[]}')
            $result.ResourceCapacity[0].ResourceId | Should -Be '/vm2'
        }
    }

    Context 'Drill defaultFault (IncludeOrUpdateResource)' {
        It 'Sends defaultFault when it is supplied' {
            $resource = (Get-ModelType 'IncludeOrUpdateResource')::FromJsonString((@{
                id = '/vm1'
                faultProperties = @{ defaultFault = @{ faultName = 'Shutdown'; faultUrn = 'urn:csci:microsoft:virtualMachine:shutdown/1.0'; targetResourceId = '/vm1' } }
            } | ConvertTo-Json -Depth 10))
            $body = ConvertTo-RequestJson $resource
            $body.faultProperties.defaultFault.faultName | Should -Be 'Shutdown'
            $body.faultProperties.defaultFault.faultUrn | Should -Be 'urn:csci:microsoft:virtualMachine:shutdown/1.0'
            $body.faultProperties.defaultFault.targetResourceId | Should -Be '/vm1'
        }
        It 'Does not send defaultFault when it is not supplied' {
            $resource = (Get-ModelType 'IncludeOrUpdateResource')::FromJsonString('{"id":"/vm1","faultProperties":{"overriddenDefaultFault":{"faultName":"Restart"}}}')
            $body = ConvertTo-RequestJson $resource
            $body.faultProperties.PSObject.Properties.Name | Should -Not -Contain 'defaultFault'
            $body.faultProperties.overriddenDefaultFault.faultName | Should -Be 'Restart'
        }
    }
}
