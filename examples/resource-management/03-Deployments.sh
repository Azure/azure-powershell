#!/bin/env/bash
set -e
printf "\n=== Provisioning Deployments in Azure ===\n"

printf "\n1. Creating a new resource group: %s and location: %s.\n" "$groupName" "$location"
az resource group create --name "$groupName" --location "$location"

printf "\n2. Test template with dynamic parameters\n"
az resource group deployment test -g "$groupName" --templatefile $BASEDIR/sampleTemplate.json --siteName "$resourceName" --hostingPlanName "$resourceName" --siteLocation "$location" --workerSize "0"

printf "\n3. Test template with JSON parameter object\n"
az resource group deployment test -g "$groupName" --templatefile $BASEDIR/sampleTemplate.json --templateparameterobject "{\"siteName\":\"$resourceName\",\"hostingPlanName\":\"$resourceName\",\"siteLocation\":\"$location\",\"workerSize\": 0 }"

printf "\n4. Provisioning Deployment\n"
deploymentInfo=`az resource group deployment create --Name "$resourceName" --ResourceGroupName "$groupName" --TemplateFile $BASEDIR/sampleTemplate.json --TemplateParameterFile $BASEDIR/sampleTemplateParams.json`
echo $deploymentInfo