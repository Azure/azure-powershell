<!--
    Please leave this section at the top of the change log.

    Changes for the current release should go under the section titled "Current Release", and should adhere to the following format:

    ## Current Release
    * Overview of change #1
        - Additional information about change #1
    * Overview of change #2
        - Additional information about change #2
        - Additional information about change #2
    * Overview of change #3
    * Overview of change #4
        - Additional information about change #4

    ## YYYY.MM.DD - Version X.Y.Z (Previous Release)
    * Overview of change #1
        - Additional information about change #1

## Current Release
* Added support for RServer cluster type
    - Edgenode VM size can be specified for R Server cluster in New-AzureRmHDInsightCluster or New-AzureRmHDInsightClusterConfig
    - RServer is now a configuration option in Add-AzureRmHDInsightConfigValues. It allows for RStudio flag to be set to indicate that R Studio installation should be done.

## Version 2.7.0

## Version 2.6.0

## Version 2.5.0

## Version 2.4.0

## Version 2.3.0
* Add support to create HDInsight Spark 2.0 cluster using new cmdlet Add-AzureRmHDInsightComponentVersion to specify the component version of Spark
* Get-AzureRmHDInsightCluster now returns the component version in a Spark 2.0 cluster
* New cmdlet
    - Add-AzureRmHDInsightSecurityProfile