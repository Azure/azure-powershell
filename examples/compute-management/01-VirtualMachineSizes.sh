#!/bin/env/bash
set -e
printf "\n=== Managing Virtual Machine Sizes in Azure Compute ===\n"

printf "\n1. Showing VM size results in location: %s.\n" "$location"
az vm size ls --location "$location"

printf "\n2. Checking VM size results in location: %s.\n" "$location"
vmSizeResult=`az vm size ls --location "$location"`

if [[ $vmSizeResult == "" ]]; then
    echo "Failure: No VM sizes!" 1>&2
    exit 1
else
    echo "Success: Non-empty Results."
fi

filterResult=`az vm size ls --location "$location" | cat | jq 'select(.name | contains("Standard_A0"))' --raw-output`
if [[ "$filterResult" == "" ]]; then
    echo "Failure: Standard_A0 vm size not found." 1>&2
    exit 1
else
    echo "Success: Standard_A0 vm size found."
fi

filterResult=`az vm size ls --location "$location" | cat | jq 'select(.name | contains("Standard_G1"))' --raw-output`
if [[ "$filterResult" == "" ]]; then
    echo "Failure: Standard_G1 vm size not found." 1>&2
    exit 1
else
    echo "Success: Standard_G1 vm size found."
fi

filterResult=`az vm size ls --location "$location" | cat | jq 'select(.name | contains("NonStandard_A1"))' --raw-output`
if [[ "$filterResult" == "" ]]; then
    echo "Success: NonStandard_A1 vm size not found."
else
    echo "Failure: NonStandard_A1 vm size found." 1>&2
    exit 1
fi 