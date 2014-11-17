using System;
using System.Collections;
using System.IO;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Common;

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

        private string fullProjectFile;
        private string fullWebConfigFileWithConfiguration;
        private string fullWebConfigFile;
        private string fullPackage;
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

            try
            {
                // Publish the package.
                WebsitesClient.PublishWebProject(Name, Slot, fullPackage, connectionStrings);
                WriteVerbose(string.Format(Resources.CompletePublishingProjectTemplate, fullPackage));
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
        /// 2. Web.<configuration>.config (like Web.Release.config)
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
