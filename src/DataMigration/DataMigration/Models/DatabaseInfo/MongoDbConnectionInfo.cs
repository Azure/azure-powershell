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
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.DataMigration.Models
{
    public class MongoDbConnectionInfo : Microsoft.Azure.Management.DataMigration.Models.ConnectionInfo
    {
        //
        // Summary:
        //     Gets or sets a MongoDB connection string or blob container URL. The user name
        //     and password can be specified here or in the userName and password properties
        [JsonProperty(PropertyName = "connectionString")]
        public string ConnectionString { get; set; }

        //
        // Summary: server name 
        [JsonProperty(PropertyName = "serverName")]
        public string ServerName { get; set; }

        //
        // Summary: mongo database port 
        [JsonProperty(PropertyName = "port")]
        public int? Port { get; set; }

        //
        // Summary: use ssl 
        [JsonProperty(PropertyName = "useSSL")]
        public bool? UseSSL { get; set; }

        //
        // Summary: server version
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

        private static int defaultMongoPort = 27017;

        private void AssembleMongoDbConnectionString()
        {
            string usernamePassword = string.IsNullOrWhiteSpace(this.UserName) ? "" : 
                string.Format("{0}:{1}@", this.UserName, this.Password);
            this.ConnectionString = string.Format("mongodb://{0}{1}", usernamePassword, this.ServerName);
            string portString = this.Port == null ? "": string.Format(":{0}", this.Port);
            this.ConnectionString += portString;
            this.ConnectionString += this.UseSSL == true ? "/?ssl=true" : "/?ssl=false";
        }

        public void ConstructConnectionString()
        {
            if (string.IsNullOrWhiteSpace(this.ConnectionString))
            {
                AssembleMongoDbConnectionString();
            }
            else if (this.ConnectionString.StartsWith("https", System.StringComparison.InvariantCultureIgnoreCase))
            {
                this.UserName = "";
                this.Password = "";
                this.ServerName = "AzureStorage";
                this.Port = null;
            }
            else
            {
                var regex = new Regex(@"^mongodb:\/\/((?<user>[^:@\/\?]*)?(:?(?<pass>[^:@\/\?]*)?)?@)?(?<server>[^\/:@\?]+)(:(?<port>\d+))?([\/\?]*(?<ssl>.*))$", RegexOptions.IgnoreCase);
                var matchs = regex.Matches(ConnectionString);
                if (matchs.Count >= 1)
                {
                    var m = matchs[0];
                    string username = m.Groups["user"].ToString();
                    this.UserName = string.IsNullOrWhiteSpace(this.UserName) ? username : this.UserName;
                    string password = m.Groups["pass"].ToString();
                    this.Password = string.IsNullOrWhiteSpace(this.Password) ? password : this.Password;
                    string server = m.Groups["server"].ToString();
                    this.ServerName = string.IsNullOrWhiteSpace(this.ServerName) ? server : this.ServerName;
                    string port = m.Groups["port"].ToString();
                    int portNumber = defaultMongoPort;
                    bool connStrPortVal = !string.IsNullOrWhiteSpace(port) && int.TryParse(port, out portNumber);
                    this.Port = this.Port == null && connStrPortVal ? portNumber : this.Port;
                    string ssl = m.Groups["ssl"].ToString();
                    this.UseSSL = this.UseSSL != null || string.IsNullOrWhiteSpace(ssl) ? this.UseSSL : ssl.ToLowerInvariant().Contains("ssl=true");
                }
                this.AssembleMongoDbConnectionString();
            }
        }
    }
}
