az upgrade
az login --service-principal --username $0 --password  $1 --tenant $2
az storage copy -s "https://bezstorage101.file.core.windows.net/localrepo/current release/*" -d "https://bezstorage101.file.core.windows.net/localrepo/previous release/"
az storage remove --account-name bezstorage101 --account-key ugETFrp3J59u4sfrfpNFRLB0UiyFZ5ZqvNtrTs5l9IW0LBHgnbYCu/PzwRgUe25M2Yphj8zsZViboZMUZsEigw== -s localrepo -p "current release/*"
az storage copy -s "$(Pipeline.Workspace)/*.nupkg" -d "https://bezstorage101.file.core.windows.net/localrepo/current release"
az storage copy -s "https://bezstorage101.file.core.windows.net/localrepo/current release/*" -d "https://bezstorage101.file.core.windows.net/localrepo/previous release/"
az storage remove --account-name bezstorage101 --account-key ugETFrp3J59u4sfrfpNFRLB0UiyFZ5ZqvNtrTs5l9IW0LBHgnbYCu/PzwRgUe25M2Yphj8zsZViboZMUZsEigw== -s localrepo -p "local repository/*"
az storage copy -s "https://bezstorage101.file.core.windows.net/localrepo/current release/*" -d "https://bezstorage101.file.core.windows.net/localrepo/local repository/"
az storage copy -s "https://bezstorage101.file.core.windows.net/localrepo/previous release/*" -d "https://bezstorage101.file.core.windows.net/localrepo/local repository/"