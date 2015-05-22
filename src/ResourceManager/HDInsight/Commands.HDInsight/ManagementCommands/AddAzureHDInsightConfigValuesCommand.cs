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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Management.HDInsight;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(
        VerbsCommon.Add,
        Constants.CommandNames.AzureHDInsightConfigValues),
    OutputType(
        typeof(AzureHDInsightConfig))]
    public class AddAzureHDInsightConfigValuesCommand : HDInsightCmdletBase
    {
        private Dictionary<string, Dictionary<string, string>> _configurations;
            
        #region Input Parameter Definitions

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The HDInsight cluster configuration to use when creating the new cluster")]
        public AzureHDInsightConfig Config { get; set; }

        [Parameter(HelpMessage = "Gets the Core Site configurations of this HDInsight cluster.")]
        public Dictionary<string, string> Core { get; set; }

        [Parameter(HelpMessage = "Gets the Hive Site configurations of this HDInsight cluster.")]
        public Dictionary<string, string> HiveSite { get; set; }

        [Parameter(HelpMessage = "Gets the Hive Env configurations of this HDInsight cluster.")]
        public Dictionary<string, string> HiveEnv { get; set; }

        [Parameter(HelpMessage = "Gets the Oozie Site configurations of this HDInsight cluster.")]
        public Dictionary<string, string> OozieSite { get; set; }

        [Parameter(HelpMessage = "Gets the Oozie Env configurations of this HDInsight cluster.")]
        public Dictionary<string, string> OozieEnv { get; set; }

        [Parameter(HelpMessage = "Gets the WebHCat Site configurations of this HDInsight cluster.")]
        public Dictionary<string, string> WebHCat { get; set; }

        [Parameter(HelpMessage = "Gets the HBase Site configurations of this HDInsight cluster.")]
        public Dictionary<string, string> HBaseSite { get; set; }

        [Parameter(HelpMessage = "Gets the HBase Env configurations of this HDInsight cluster.")]
        public Dictionary<string, string> HBaseEnv { get; set; }

        [Parameter(HelpMessage = "Gets the Storm Site configurations of this HDInsight cluster.")]
        public Dictionary<string, string> Storm { get; set; }

        [Parameter(HelpMessage = "Gets the Yarn Site configurations of this HDInsight cluster.")]
        public Dictionary<string, string> Yarn { get; set; }

        [Parameter(HelpMessage = "Gets the MapRed Site configurations of this HDInsight cluster.")]
        public Dictionary<string, string> MapRed { get; set; }

        [Parameter(HelpMessage = "Gets the Tez Site configurations of this HDInsight cluster.")]
        public Dictionary<string, string> Tez { get; set; }

        [Parameter(HelpMessage = "Gets the Hdfs Site configurations of this HDInsight cluster.")]
        public Dictionary<string, string> Hdfs { get; set; }

        #endregion

        public AddAzureHDInsightConfigValuesCommand()
        {
            Core = new Dictionary<string, string>();
            HiveSite = new Dictionary<string, string>();
            HiveEnv = new Dictionary<string, string>();
            OozieSite = new Dictionary<string, string>();
            OozieEnv = new Dictionary<string, string>();
            WebHCat = new Dictionary<string, string>();
            HBaseSite = new Dictionary<string, string>();
            HBaseEnv = new Dictionary<string, string>();
            Storm = new Dictionary<string, string>();
            Yarn = new Dictionary<string, string>();
            MapRed = new Dictionary<string, string>();
            Tez = new Dictionary<string, string>();
            Hdfs = new Dictionary<string, string>();
        }

        public override void ExecuteCmdlet()
        {
            var config = Config;
            _configurations = config.Configurations ?? new Dictionary<string, Dictionary<string, string>>();

            AddConfigToConfigurations(Core, ConfigurationKey.CoreSite);
            AddConfigToConfigurations(HiveSite, ConfigurationKey.HiveSite);
            AddConfigToConfigurations(HiveEnv, ConfigurationKey.HiveEnv);
            AddConfigToConfigurations(OozieSite, ConfigurationKey.OozieSite);
            AddConfigToConfigurations(OozieEnv, ConfigurationKey.OozieEnv);
            AddConfigToConfigurations(WebHCat, ConfigurationKey.WebHCatSite);
            AddConfigToConfigurations(HBaseSite, ConfigurationKey.HBaseSite);
            AddConfigToConfigurations(HBaseEnv, ConfigurationKey.HBaseEnv);
            AddConfigToConfigurations(Storm, ConfigurationKey.StormSite);
            AddConfigToConfigurations(Yarn, ConfigurationKey.YarnSite);
            AddConfigToConfigurations(MapRed, ConfigurationKey.MapRedSite);
            AddConfigToConfigurations(Tez, ConfigurationKey.TezSite);
            AddConfigToConfigurations(Hdfs, ConfigurationKey.HdfsSite);

            WriteObject(_configurations);
        }

        private void AddConfigToConfigurations(Dictionary<string, string> userConfigs, string configKey)
        {
            //if no configs of this type provided, do nothing
            if (userConfigs == null || userConfigs.Count == 0)
            {
                return;
            }

            Dictionary<string, string> config;
            
            //if configs provided and key does not already exist, add the key with provided dictionary
            if (!_configurations.TryGetValue(configKey, out config))
            {
                _configurations.Add(configKey, userConfigs);
                return;
            }

            //if configs provided and key already exists, add the provided values to the dictionary for the key
            foreach (var conf in userConfigs)
            {
                config.Add(conf.Key, conf.Value);
            }
            _configurations[configKey] = config;
        }
    }
}
