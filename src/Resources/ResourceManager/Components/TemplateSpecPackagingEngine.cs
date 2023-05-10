// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components
{
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Represents a template packaged for Template Spec use.
    /// </summary>
    public class PackagedTemplate
    {
        public PackagedTemplate() { }

        public PackagedTemplate(TemplateSpecVersion versionModel)
        {
            this.RootTemplate = (JObject)versionModel?.MainTemplate;
            this.Artifacts = versionModel?.LinkedTemplates?.ToArray() 
                ?? new LinkedTemplateArtifact[0];
            this.UIFormDefinition = (JObject)versionModel?.UiFormDefinition;
        }

        public JObject RootTemplate { get; set; }

        public JObject UIFormDefinition { get; set; }

        public LinkedTemplateArtifact[] Artifacts { get; set; }
    }

    /// <summary>
    /// An engine that can be used to pack or unpack templates and artifacts
    /// for Template Spec use.
    /// </summary>
    public static class TemplateSpecPackagingEngine
    {
        private class PackingContext
        {
            public PackingContext(string rootTemplateDirectory)
            {
                if (string.IsNullOrWhiteSpace(rootTemplateDirectory))
                {
                    throw new ArgumentNullException(nameof(rootTemplateDirectory));
                }

                this.RootTemplateDirectory = Path.GetFullPath(rootTemplateDirectory);
                this.CurrentDirectory = RootTemplateDirectory;
            }

            public string RootTemplateDirectory { get; set; }

            public string CurrentDirectory { get; set; }

            public IList<LinkedTemplateArtifact> Artifacts { get; private set; }
                = new List<LinkedTemplateArtifact>();
        }

        /// <summary>
        /// Packs the specified template and its referenced artifacts for use
        /// in a Template Spec.
        /// </summary>
        /// <param name="rootTemplateFilePath">
        /// The path to the ARM Template .json file to pack
        /// </param>
        /// <param name="uiFormDefinitionFilePath">
        /// The path to the UI Form Definition .json to pack (if any)
        /// </param>
        public static PackagedTemplate Pack(string rootTemplateFilePath, 
            string uiFormDefinitionFilePath)
        {
            rootTemplateFilePath = Path.GetFullPath(rootTemplateFilePath);
            PackingContext context = new PackingContext(
                Path.GetDirectoryName(rootTemplateFilePath)
            );
            
            PackArtifacts(rootTemplateFilePath, context, out JObject templateObj);
            var packagedTemplate = new PackagedTemplate
            {
                RootTemplate = templateObj,
                Artifacts = context.Artifacts.ToArray()
            };

            // If a UI Form Definition file path was provided to us, make sure we package the
            // UI Form Definition as well:

            if (!string.IsNullOrWhiteSpace(uiFormDefinitionFilePath))
            {
                string uiFormDefinitionJson = FileUtilities.DataStore.ReadFileAsText(uiFormDefinitionFilePath);
                packagedTemplate.UIFormDefinition = JObject.Parse(uiFormDefinitionJson);
            }

            return packagedTemplate;
        }

        /// <summary>
        /// Recursively packs the specified template and its referenced artifacts and
        /// adds the artifacts to the current packing context.
        /// </summary>
        /// <param name="templateAbsoluteFilePath">
        /// The path to the ARM Template .json file to pack
        /// </param>
        /// <param name="context">
        /// The packing context of the current packing operation
        /// </param>
        /// <param name="artifactableTemplateObj">
        /// The packagable template object
        /// </param>
        private static void PackArtifacts(
            string templateAbsoluteFilePath,
            PackingContext context,
            out JObject artifactableTemplateObj)
        {
            string originalDirectory = context.CurrentDirectory;

            try
            {
                context.CurrentDirectory = Path.GetDirectoryName(
                    templateAbsoluteFilePath
                );

                string templateJson = FileUtilities.DataStore.ReadFileAsText(templateAbsoluteFilePath);
                JObject templateObj = artifactableTemplateObj = JObject.Parse(templateJson);

                JObject[] templateLinkToArtifactObjs = GetTemplateLinksToArtifacts(
                    templateObj, includeNested: true);

                foreach (JObject templateLinkObj in templateLinkToArtifactObjs)
                {
                    string relativePath = ((string)templateLinkObj["relativePath"])?
                        .TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

                    if (string.IsNullOrWhiteSpace(relativePath))
                    {
                        continue; // Throw here?
                    }

                    // This is a templateLink to a local template... Get the absolute path of the
                    // template based on its relative path from the current template directory and
                    // make sure it exists:

                    string absoluteLocalPath = Path.Combine(context.CurrentDirectory, relativePath);
                    if (!File.Exists(absoluteLocalPath))
                    {
                        throw new FileNotFoundException(absoluteLocalPath);
                    }

                    // Let's make sure we're not referencing a file outside of our root directory
                    // heirarchy. We won't allow such references for security purposes:

                    if (!absoluteLocalPath.StartsWith(
                        context.RootTemplateDirectory + Path.DirectorySeparatorChar,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        throw new InvalidOperationException(
                            $"Unable to handle the reference to file '{absoluteLocalPath}' from " +
                            $"'{templateAbsoluteFilePath}' because it exists outside of the root template " +
                            $"directory of '{context.RootTemplateDirectory}'");
                    }

                    // Convert the template relative path to one that is relative to our root 
                    // directory path, and then if we haven't already processed that template into
                    // an artifact elsewhere, we'll do so here...

                    string asRelativePath = AbsoluteToRelativePath(context.RootTemplateDirectory, absoluteLocalPath);
                    if (context.Artifacts.Any(prevAddedArtifact => prevAddedArtifact.Path.Equals(
                            asRelativePath, StringComparison.OrdinalIgnoreCase)))
                    {
                        continue; // We've already packed this artifact from elsewhere
                    }

                    PackArtifacts(absoluteLocalPath, context, out JObject templateObjForArtifact);

                    LinkedTemplateArtifact artifact = new LinkedTemplateArtifact
                    {
                        Path = asRelativePath,
                        Template = templateObjForArtifact
                    };

                    context.Artifacts.Add(artifact);
                }
            }
            finally
            {
                context.CurrentDirectory = originalDirectory;
            }
        }

        /// <summary>
        /// Unpacks the specified packaged template to the local filesystem.
        /// </summary>
        /// <param name="packagedTemplate">The packaged template to be unpacked</param>
        /// <param name="targetDirectory">
        /// The root directory to unpack the template and its artifacts to
        /// </param>
        /// <param name="templateFileName">
        /// The name of the file to use for the root template json
        /// </param>
        /// <param name="uiFormDefinitionFileName">
        /// The name of the file to use for the ui form definition json (if any). If set to
        /// null, the ui definition won't be unpacked even if present within the packaged template.
        /// </param>
        public static void Unpack(
            PackagedTemplate packagedTemplate,
            string targetDirectory,
            string templateFileName,
            string uiFormDefinitionFileName)
        {
            // Ensure paths are normalized:
            templateFileName = Path.GetFileName(templateFileName);
            targetDirectory = Path.GetFullPath(targetDirectory)
                .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

            string rootTemplateFilePath = Path.Combine(targetDirectory, templateFileName);

            // TODO: Directory/file existence checks..

            // Go through each artifact and make sure it's not going to place artifacts
            // outside of the target directory:

            foreach (var artifact in packagedTemplate.Artifacts)
            {
                string absoluteLocalPath = Path.GetFullPath(
                    Path.Combine(
                        targetDirectory,
                        NormalizeDirectorySeparatorsForLocalFS(artifact.Path)
                    )
                );

                if (!absoluteLocalPath.StartsWith(
                        targetDirectory + Path.DirectorySeparatorChar,
                        StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException(
                        $"Unable to unpack artifact '{artifact.Path}' because it would create a file " +
                        $"outside of the target directory heirarchy of '{targetDirectory}'");
                }
            }

            // Now that the artifact paths checkout...let's begin by writing our main template
            // file and then processing each artifact:

            FileUtilities.DataStore.CreateDirectory(targetDirectory);
            FileUtilities.DataStore.WriteFile(rootTemplateFilePath,
                packagedTemplate.RootTemplate.ToString());

            foreach (var artifact in packagedTemplate.Artifacts)
            {
                if (!(artifact is LinkedTemplateArtifact templateArtifact))
                {
                    throw new NotSupportedException("Unknown artifact type encountered...");
                }

                string absoluteLocalPath = Path.GetFullPath(
                    Path.Combine(
                        targetDirectory, 
                        NormalizeDirectorySeparatorsForLocalFS(artifact.Path)
                    )
                );

                FileUtilities.DataStore.CreateDirectory(Path.GetDirectoryName(absoluteLocalPath));
                FileUtilities.DataStore.WriteFile(absoluteLocalPath,
                    ((JObject)templateArtifact.Template).ToString());
            }

            // Lastly, let's write the UIFormDefinition file if a UIFormDefinition is present within
            // the packaged template:

            if (!string.IsNullOrWhiteSpace(uiFormDefinitionFileName) && 
                packagedTemplate.UIFormDefinition != null)
            {
                string absoluteUIFormDefinitionFilePath = Path.Combine(
                    targetDirectory, 
                    uiFormDefinitionFileName
                );

                FileUtilities.DataStore.WriteFile(
                    absoluteUIFormDefinitionFilePath,
                    packagedTemplate.UIFormDefinition.ToString()
                );
            }
        }

        /// <summary>
        /// Gets all of the deployment resource JObjects within the specified template
        /// JObject.
        /// </summary>
        /// <param name="templateObj"></param>
        /// <param name="includeNested">If true, deployment resource objects from nested
        /// templates will be included in the results</param>
        /// <remarks>
        /// When relativeUrl is added to the public SDKs we should update this to use the
        /// official template SDK models.
        /// </remarks>
        private static JObject[] GetDeploymentResourceObjects(JObject templateObj, bool includeNested = false)
        {
            JObject[] immediateDeploymentResources = templateObj?.SelectTokens(@"$.resources[*]")
                .Where(resourceToken => resourceToken is JObject resourceObj &&
                    resourceObj["type"]?.ToString().Equals("Microsoft.Resources/deployments", StringComparison.OrdinalIgnoreCase) == true)
                .Cast<JObject>()
                .ToArray() ?? new JObject[0];

            List<JObject> results = new List<JObject>();
            foreach (JObject deploymentResourceObj in immediateDeploymentResources)
            {
                results.Add(deploymentResourceObj);

                // Make sure we get any nested deployment resources:

                if (includeNested &&
                    deploymentResourceObj["properties"] is JObject deploymentResourcePropsObj &&
                    deploymentResourcePropsObj["template"] is JObject innerTemplateObj)
                {
                    results.AddRange(GetDeploymentResourceObjects(innerTemplateObj));
                }
            }

            return results.ToArray();
        }

        /// <summary>
        /// Gets all of the TemplateLink JObjects within the specified template object that
        /// are representing references to Template Spec artifacts.
        /// </summary>
        /// <param name="templateObj"></param>
        /// <param name="includeNested">If true, template links from nested templates 
        /// will be included in the results</param>
        /// <remarks>
        /// When relativeUrl is added to the public SDKs we should update this to use the
        /// official template SDK models.
        /// </remarks>
        private static JObject[] GetTemplateLinksToArtifacts(JObject templateObj, bool includeNested = false)
        {
            // First get all deployment resource objects:
            JObject[] deploymentResourceObjs = GetDeploymentResourceObjects(templateObj, includeNested);

            // Then get any template links:
            var templateLinkObjs = deploymentResourceObjs
                .Where(obj =>
                    obj["properties"] is JObject propsObj &&
                    propsObj["templateLink"]?.Type == JTokenType.Object)
                .Select(obj => { return obj["properties"]["templateLink"]; })
                .Where(templateLinkObj =>
                    templateLinkObj["relativePath"]?.Type == JTokenType.String && // Must have relative path
                    templateLinkObj.SelectToken("uri") == null) // Exclude URI relative paths 
                .Cast<JObject>()
                .ToArray();

            return templateLinkObjs;
        }

        /// <summary>
        /// Simply normalizes directory path separators in the specified path
        /// to match those of the local filesystem(s).
        /// </summary>
        private static string NormalizeDirectorySeparatorsForLocalFS(string absoluteFilePath)
        {
            if (Path.DirectorySeparatorChar == '\\') {
                // Windows based:
                return absoluteFilePath.Replace(Path.AltDirectorySeparatorChar, '\\');
            }

            // Unix/Other based:
            return absoluteFilePath.Replace('\\', Path.DirectorySeparatorChar); 
        }

        /// <summary>
        /// For the specified root, will convert the specified absolute file path
        /// to a path that is relative to the root.
        /// </summary>
        private static string AbsoluteToRelativePath(
            string rootDirectoryPath, string absoluteFilePath)
        {
            rootDirectoryPath = rootDirectoryPath
                .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

            // Ensure we have a trailing seperator
            rootDirectoryPath += Path.DirectorySeparatorChar;

            // Note: We use Path.GetFullPath to ensure the paths are normalized...
            var fileUri = new Uri(Path.GetFullPath(absoluteFilePath));
            var rootUri = new Uri(Path.GetFullPath(rootDirectoryPath));

            return Uri
                .UnescapeDataString(rootUri.MakeRelativeUri(fileUri).ToString())
                .Replace('/', Path.DirectorySeparatorChar);
        }
    }
}
