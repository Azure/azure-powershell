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

using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Management.HDInsight;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(
        VerbsCommon.Add,
        Constants.CommandNames.AzureHDInsightConfigValues),
    OutputType(
        typeof(AzureHDInsightConfig))]
    public class AddAzureHDInsightConfigValuesCommand : HDInsightCmdletBase
    {
        private Dictionary<string, Hashtable> _configurations;

        #region Input Parameter Definitions

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The HDInsight cluster configuration to use when creating the new cluster.")]
        public AzureHDInsightConfig Config { get; set; }

        [Parameter(HelpMessage = "Gets the Core Site configurations of this HDInsight cluster.")]
        public Hashtable Core { get; set; }

        [Parameter(HelpMessage = "Gets the Hive Site configurations of this HDInsight cluster.")]
        public Hashtable HiveSite { get; set; }

        [Parameter(HelpMessage = "Gets the Hive Env configurations of this HDInsight cluster.")]
        public Hashtable HiveEnv { get; set; }

        [Parameter(HelpMessage = "Gets the Oozie Site configurations of this HDInsight cluster.")]
        public Hashtable OozieSite { get; set; }

        [Parameter(HelpMessage = "Gets the Oozie Env configurations of this HDInsight cluster.")]
        public Hashtable OozieEnv { get; set; }

        [Parameter(HelpMessage = "Gets the WebHCat Site configurations of this HDInsight cluster.")]
        public Hashtable WebHCat { get; set; }

        [Parameter(HelpMessage = "Gets the HBase Site configurations of this HDInsight cluster.")]
        public Hashtable HBaseSite { get; set; }

        [Parameter(HelpMessage = "Gets the HBase Env configurations of this HDInsight cluster.")]
        public Hashtable HBaseEnv { get; set; }

        [Parameter(HelpMessage = "Gets the Storm Site configurations of this HDInsight cluster.")]
        public Hashtable Storm { get; set; }

        [Parameter(HelpMessage = "Gets the Yarn Site configurations of this HDInsight cluster.")]
        public Hashtable Yarn { get; set; }

        [Parameter(HelpMessage = "Gets the MapRed Site configurations of this HDInsight cluster.")]
        public Hashtable MapRed { get; set; }

        [Parameter(HelpMessage = "Gets the Tez Site configurations of this HDInsight cluster.")]
        public Hashtable Tez { get; set; }

        [Parameter(HelpMessage = "Gets the Hdfs Site configurations of this HDInsight cluster.")]
        public Hashtable Hdfs { get; set; }

        #endregion

        public AddAzureHDInsightConfigValuesCommand()
        {
            Core = new Hashtable();
            HiveSite = new Hashtable();
            HiveEnv = new Hashtable();
            OozieSite = new Hashtable();
            OozieEnv = new Hashtable();
            WebHCat = new Hashtable();
            HBaseSite = new Hashtable();
            HBaseEnv = new Hashtable();
            Storm = new Hashtable();
            Yarn = new Hashtable();
            MapRed = new Hashtable();
            Tez = new Hashtable();
            Hdfs = new Hashtable();
        }

        public override void ExecuteCmdlet()
        {
            _configurations = Config.Configurations ?? new Dictionary<string, Hashtable>();

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

            WriteObject(Config);
        }

        private void AddConfigToConfigurations(Hashtable userConfigs, string configKey)
        {
            //var userConfigs = HashtableToDictionary(configs);
            //if no configs of this type provided, do nothing
            if (userConfigs == null || userConfigs.Count == 0)
            {
                return;
            }

            Hashtable config;

            //if configs provided and key does not already exist, add the key with provided dictionary
            if (!_configurations.TryGetValue(configKey, out config))
            {
                _configurations.Add(configKey, userConfigs);
                return;
            }

            //if configs provided and key already exists, add the provided values to the dictionary for the key
            var updatedConfig = ConcatHashtables(config, userConfigs);

            _configurations[configKey] = updatedConfig;
        }

        private static Hashtable ConcatHashtables(Hashtable first, Hashtable second)
        {
            foreach (DictionaryEntry item in second)
            {
                first[item.Key] = item.Value;
            }
            return first;
        }
    }
}
