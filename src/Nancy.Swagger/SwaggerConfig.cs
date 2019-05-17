namespace Nancy.Swagger
{
    [SwaggerApi]
    public static class SwaggerConfig
    {
        static SwaggerConfig()
        {
        }
        
        public static string ResourceListingPath { get; set; } = "";
    }
}
