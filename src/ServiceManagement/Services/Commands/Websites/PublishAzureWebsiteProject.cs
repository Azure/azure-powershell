using System;
using System.Collections;
using System.IO;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Common;
using Microsoft.Web.Deployment;

namespace Microsoft.WindowsAzure.Commands.Websites
{
    [Cmdlet(VerbsData.Publish, "AzureWebsiteProject")]
    public class PublishAzureWebsiteProject : WebsiteContextBaseCmdlet, IDynamicParameters
    {
        [Parameter(ParameterSetName = "ProjectFile", Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The Visual Studio web application project to be published.")]
        [ValidateNotNullOrEmpty]
        public string ProjectFile { get; set; }

        [Parameter(ParameterSetName = "ProjectFile", Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The configuration used to build the Visual Studio web application project.")]
        [ValidateNotNullOrEmpty]
        public string Configuration { get; set; }

        [Parameter(ParameterSetName = "Package", Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The WebDeploy package folder for zip file of the Visual Studio web application project to be published.")]
        [ValidateNotNullOrEmpty]
        public string Package { get; set; }

        [Parameter(ParameterSetName = "ProjectFile", Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The connection strings to use for the deployment.")]
        [Parameter(ParameterSetName = "Package", Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The connection strings to use for the deployment.")]
        [ValidateNotNullOrEmpty]
        public Hashtable ConnectionString { get; set; }

        [Parameter(ParameterSetName = "Package", Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The configuration tokens to use for the deployment.")]
        [ValidateNotNullOrEmpty]
        public string Tokens { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Package", HelpMessage = "The WebDeploy SetParameters.xml file to transform configuration within the package.")]
        public string SetParametersFile { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "ProjectFile")]
        [Parameter(Mandatory = false, ParameterSetName = "Package")]
        public SwitchParameter SkipAppData { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "ProjectFile")]
        [Parameter(Mandatory = false, ParameterSetName = "Package")]
        public SwitchParameter DoNotDelete { get; set; }

        private string fullProjectFile;
        private string fullWebConfigFileWithConfiguration;
        private string fullWebConfigFile;
        private string fullPackage;
        private string fullSetParametersFile;
        private string configuration;

        private RuntimeDefinedParameterDictionary dynamicParameters;

        public override void ExecuteCmdlet()
        {
            PrepareFileFullPaths();

            // If a project file is specified, use MSBuild to build the package zip file.
            if (!string.IsNullOrEmpty(ProjectFile))
            {
                WriteVerbose(string.Format(Resources.StartBuildingProjectTemplate, fullProjectFile));
                fullPackage = WebsitesClient.BuildWebProject(fullProjectFile, configuration, Path.Combine(CurrentPath(), "build.log"));
                WriteVerbose(string.Format(Resources.CompleteBuildingProjectTemplate, fullProjectFile));
            }

            // Resolve the full path of the package file or folder when the "Package" parameter set is used.
            fullPackage = string.IsNullOrEmpty(fullPackage) ? this.TryResolvePath(Package) : fullPackage;
            WriteVerbose(string.Format(Resources.StartPublishingProjectTemplate, fullPackage));

            fullSetParametersFile = string.IsNullOrEmpty(fullSetParametersFile) ? this.TryResolvePath(SetParametersFile) : fullSetParametersFile;

            // Convert dynamic parameters to a connection string hash table.
            var connectionStrings = ConnectionString;
            if (connectionStrings == null)
            {
                connectionStrings = new Hashtable();
                if (dynamicParameters != null)
                {
                    foreach (var dp in dynamicParameters)
                    {
                        if (MyInvocation.BoundParameters.ContainsKey(dp.Key))
                        {
                            connectionStrings[dp.Value.Name.ToString()] = dp.Value.Value.ToString();
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(fullSetParametersFile) && !File.Exists(fullSetParametersFile))
            {
                if (File.Exists(Path.Combine(Path.GetDirectoryName(fullPackage), fullSetParametersFile)))
                {
                    WriteVerbose("Setting path for Parameters file to local one to package: " + Path.Combine(Path.GetDirectoryName(fullPackage), fullSetParametersFile));
                    fullSetParametersFile = Path.Combine(Path.GetDirectoryName(fullPackage),fullSetParametersFile);
                }
            }

            // If tokens are passed in, update the parameters file if there is one
            if (!string.IsNullOrEmpty(Tokens) && !string.IsNullOrEmpty(fullSetParametersFile))
            {
                // Convert tokens string to hashtable
                string[] tokenSplit = Tokens.Split(';');

                WriteVerbose(string.Format("Replacing tokens in {0}", fullSetParametersFile));
                var fileContents = File.ReadAllText(fullSetParametersFile);

                foreach (string pair in tokenSplit)
                {
                    string[] data = pair.Split('=');
                    fileContents = fileContents.Replace(string.Format("__{0}__", data[0].Replace("\"", "")), data[1].Replace("\"", ""));
                }

                File.WriteAllText(fullSetParametersFile, fileContents);
            }

            try
            {
                // Publish the package.
                DeploymentChangeSummary changeSummary = WebsitesClient.PublishWebProject(Name, Slot, fullPackage, fullSetParametersFile, connectionStrings, SkipAppData.IsPresent, DoNotDelete.IsPresent);
                WriteVerbose(string.Format(Resources.CompletePublishingProjectTemplate, fullPackage));

                if (changeSummary != null)
                {
                    WriteObject("Change Summary:");
                    WriteObject(string.Format("Bytes Copied: {0}", changeSummary.BytesCopied.ToString()));
                    WriteObject(string.Format("Files Added: {0}", changeSummary.ObjectsAdded.ToString()));
                    WriteObject(string.Format("Files Updated: {0}", changeSummary.ObjectsUpdated.ToString()));
                    WriteObject(string.Format("Files Deleted: {0}", changeSummary.ObjectsDeleted.ToString()));
                    WriteObject(string.Format("Errors: {0}", changeSummary.Errors.ToString()));
                    WriteObject(string.Format("Warnings: {0}", changeSummary.Warnings.ToString()));
                    WriteObject(string.Format("Parameters Changed: {0}", changeSummary.ParameterChanges.ToString()));
                    WriteObject(string.Format("Total No of Changes: {0}", changeSummary.TotalChanges.ToString()));
                }
            }
            catch (Exception)
            {
                WriteVerbose(string.Format(Resources.FailPublishingProjectTemplate, fullPackage));
                throw;
            }
        }

        /// <summary>
        /// Generate dynamic parameters based on the connection strings in the Web.config.
        /// It will look at 2 Web.config files:
        /// 1. Web.config
        /// 2. Web.&lt;configuration&gt;.config (like Web.Release.config)
        /// This only works when -ProjectFile is used and -ConnectionString is not used.
        /// </summary>
        /// <returns>The dynamic parameters.</returns>
        public object GetDynamicParameters()
        {
            if (!string.IsNullOrEmpty(ProjectFile) && ConnectionString == null)
            {
                // Get the 2 Web.config files.
                PrepareFileFullPaths();

                dynamicParameters = new RuntimeDefinedParameterDictionary();
                if (string.Compare("ProjectFile", ParameterSetName) == 0)
                {
                    // Parse the connection strings from the Web.config files.
                    var names = WebsitesClient.ParseConnectionStringNamesFromWebConfig(fullWebConfigFile, fullWebConfigFileWithConfiguration);

                    // Create a dynmaic parameter for each connection string using the same name.
                    foreach (var name in names)
                    {
                        var parameter = new RuntimeDefinedParameter();
                        parameter.Name = name;
                        parameter.ParameterType = typeof(string);
                        parameter.Attributes.Add(new ParameterAttribute()
                            {
                                ParameterSetName = "ProjectFile",
                                Mandatory = false,
                                ValueFromPipelineByPropertyName = true,
                                HelpMessage = "Connection string from Web.config."
                            }
                        );
                        dynamicParameters.Add(name, parameter);
                    }
                }
            }
            return dynamicParameters;
        }

        /// <summary>
        /// Prepare the full path of the project file and Web.config files.
        /// </summary>
        private void PrepareFileFullPaths()
        {
            if (!string.IsNullOrEmpty(ProjectFile))
            {
                fullProjectFile = this.TryResolvePath(ProjectFile).Trim(new char[] { '"' });
                fullWebConfigFile = Path.Combine(Path.GetDirectoryName(fullProjectFile), "Web.config");
                configuration = string.IsNullOrEmpty(Configuration) ? "Release" : Configuration;
                fullWebConfigFileWithConfiguration = Path.Combine(Path.GetDirectoryName(fullProjectFile), string.Format("Web.{0}.config", configuration));
            }
        }
    }
}
