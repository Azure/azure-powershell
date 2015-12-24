#!/bin/bash
set -e
printf "\n=== Managing Virtual Machine Sizes in Azure Compute ===\n"

printf "\nShowing VM size results in location: %s.\n" "$location"
azure vmsize get --location "$location"

printf "\nChecking VM size results in location: %s.\n" "$location"
vmSizeResult=`azure vmsize get --location "$location"`

if [ "$vmSizeResult" = "" ]; then
    echo "Failure: No VM sizes!" 1>&2
    exit 1
else
    printf "\nSuccess: Non-empty Results.\n"
fi

queryString=Standard_A0
result=`echo "$vmSizeResult" | grep -q "$queryString"`
if [ "$vmSizeResult" = "" ] ; then
    printf "\nFailure: VM Size Not Found: '%s'.\n" "$queryString"
    exit 1
else
    printf "\nSuccess: VM Size Found in Results: '%s'.\n" "$queryString"
fi

queryString=Standard_G1
result=`echo "$vmSizeResult" | grep -q "$queryString"`
if [ "$vmSizeResult" = "" ] ; then
    printf "\nFailure: VM Size Not Found: '%s'.\n" "$queryString"
    exit 1
else
    printf "\nSuccess: VM Size Found in Results: '%s'.\n" "$queryString"
fi
