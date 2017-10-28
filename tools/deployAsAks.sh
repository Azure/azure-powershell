#!/bin/bash

# This uses Azure CLI since we are in bash for this script.

set -e

az login
az group create -n AzPsKube --location westus2
az aks create -g AzPsKube -n AzPsKube --agent-count 1 --generate-ssh-keys
az aks get-credentials -g AzPsKube -n AzPsKube

kubectl run azpsweb --image=azuresdk/azure-powershell-web --port=80
kubectl expose deployment azpsweb --type=LoadBalancer --name=azpswebservice

kubectl get services azpswebservice