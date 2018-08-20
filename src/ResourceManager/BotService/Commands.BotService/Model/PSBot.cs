using Microsoft.Azure.Management.BotService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.BotService.Model
{
    public class PSBot
    {
        public PSBot(Bot bot)
        {
            this.Description = bot.Properties.Description;
            this.DisplayName = bot.Properties.DisplayName;
            this.Endpoint = bot.Properties.Endpoint;
            this.Etag = bot.Etag;
            this.IconUrl = bot.Properties.IconUrl;
            this.Id = bot.Id;
            this.Kind = bot.Kind;
            this.Location = bot.Location;
            this.MsaAppId = bot.Properties.MsaAppId;
            this.Name = bot.Name;
            this.ResourceGroupName = ParseResourceGroupFromId(bot.Id);
            this.Sku = bot.Sku;
            this.Tags = bot.Tags;
        }

        public string Name { get; private set; }
        public string ResourceGroupName { get; private set; }
        public string Id { get; private set; }
        public string Endpoint { get; private set; }
        public string DisplayName{ get; private set; }
        public string Description { get; private set; }
        public string IconUrl { get; private set; }
        public string MsaAppId { get; private set; }
        public string Location { get; private set; }
        public Sku Sku { get; private set; }
        public string Kind { get; set; }
        public string Etag { get; set; }
        public IDictionary<string, string> Tags { get; set; }

        public static PSBot Create(Bot bot)
        {
            return new PSBot(bot);
        }

        private static string ParseResourceGroupFromId(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                string[] tokens = id.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                return tokens[3];
            }

            return null;
        }
    }
}
