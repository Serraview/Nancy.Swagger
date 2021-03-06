﻿using Nancy.Bootstrapper;
using Nancy.Swagger.Services;

namespace Nancy.Swagger
{
    [SwaggerApi]
    public class SwaggerRegistrations : Registrations
    {
        public SwaggerRegistrations()
        {
            RegisterWithDefault<ISwaggerMetadataProvider>(typeof(DefaultSwaggerMetadataProvider));
            RegisterWithDefault<ISwaggerModelCatalog>(typeof(DefaultSwaggerModelCatalog));
            RegisterWithDefault<ISwaggerTagCatalog>(typeof(DefaultSwaggerTagCatalog));
            RegisterAll<ISwaggerModelDataProvider>();
            RegisterAll<ISwaggerTagProvider>();
        }
    }
}