namespace Microsoft.Azure.Commands.Common.Strategies.Templates
{
    public class TemplateEngine : IEngine
    {
        public string GetId<TModel>(IEntityConfig<TModel> config)
            where TModel : class
            => "[concat(resourceGroup().id, '" + config.GetProvidersId().IdToString() + "')]";

        public static TemplateEngine Instance { get; }
            = new TemplateEngine();

        private TemplateEngine() { }
    }
}
