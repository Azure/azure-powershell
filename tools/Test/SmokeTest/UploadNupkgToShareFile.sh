az upgrade
az login --service-principal --username f6ae5532-8683-43cd-a23f-6da8341dc6bd --password c46W_J8GRc8G1g_pO3wU.UEq64-sYVdTQ8 --tenant 72f988bf-86f1-41af-91ab-2d7cd011db47
az storage copy -s "https://bezstorage101.file.core.windows.net/localrepo/current release/*" -d "https://bezstorage101.file.core.windows.net/localrepo/previous release/"
az storage remove --account-name bezstorage101 --account-key ugETFrp3J59u4sfrfpNFRLB0UiyFZ5ZqvNtrTs5l9IW0LBHgnbYCu/PzwRgUe25M2Yphj8zsZViboZMUZsEigw== -s localrepo -p "current release/*"
az storage copy -s "$(Pipeline.Workspace)/*.nupkg" -d "https://bezstorage101.file.core.windows.net/localrepo/current release"
az storage copy -s "https://bezstorage101.file.core.windows.net/localrepo/current release/*" -d "https://bezstorage101.file.core.windows.net/localrepo/previous release/"
az storage remove --account-name bezstorage101 --account-key ugETFrp3J59u4sfrfpNFRLB0UiyFZ5ZqvNtrTs5l9IW0LBHgnbYCu/PzwRgUe25M2Yphj8zsZViboZMUZsEigw== -s localrepo -p "local repository/*"
az storage copy -s "https://bezstorage101.file.core.windows.net/localrepo/current release/*" -d "https://bezstorage101.file.core.windows.net/localrepo/local repository/"
az storage copy -s "https://bezstorage101.file.core.windows.net/localrepo/previous release/*" -d "https://bezstorage101.file.core.windows.net/localrepo/local repository/"
