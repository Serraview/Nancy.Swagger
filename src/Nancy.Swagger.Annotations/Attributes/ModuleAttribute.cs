using System;

namespace Nancy.Swagger.Annotations.Attributes
{
    public class ModuleAttribute : Attribute
    {
        public string[] Tags { get; set; }
        public ModuleAttribute(params string[] tags)
        {
            Tags = tags;
        }
    }
}
