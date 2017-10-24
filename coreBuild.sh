#!/bin/bash

set -e

dotnet msbuild build.proj /t:BuildNetcore /p:Configuration=Debug
docker build . -t azuresdk/azure-powershell-core