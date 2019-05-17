using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Swagger.ObjectModel;
using Swagger.ObjectModel.Builders;

namespace Nancy.Swagger
{
    public static class SwaggerSchemaFactory
    {
        private const string DefinitionsRefLocation = "#/definitions/";

        public static Schema CreateSchema(this Model sModel, Type t)
        {
            if (typeof(IEnumerable).IsAssignableFrom(t))
            {
                return new EnumerableSchema(t, sModel);
            }
            if (t.IsEnum)
            {
                return new EnumSchema(t, sModel);
            }
            return new ObjectSchema(t, sModel);
        }

        private class EnumerableSchema : Schema
        {
            public EnumerableSchema(Type t, Model sModel)
            {
                Type = "array";
                Items = new Item();

                Type subType = t.GetGenericArguments().FirstOrDefault();
                Items.Type = "object";
                
                Items.Ref = DefinitionsRefLocation + SwaggerBuilderConfig.ModelIdConvention(subType);
                Ref = DefinitionsRefLocation + SwaggerBuilderConfig.ModelIdConvention(t);
            }
        }

        private class EnumSchema : Schema
        {
            public EnumSchema(Type t, Model sModel)
            {
                Type = "string";
                Ref = DefinitionsRefLocation + SwaggerBuilderConfig.ModelIdConvention(t);
                Description = sModel.Description;
                Enum = t.GetEnumNames();
            }
        }

        private class ObjectSchema : Schema
        {
            public ObjectSchema(Type t, Model sModel)
            {
                Type = "object";
                Ref = DefinitionsRefLocation + SwaggerBuilderConfig.ModelIdConvention(t);
                Required = (sModel.Required as IList<string>)?.Select(x => x.ToCamelCase()).ToList();
                Description = sModel.Description;
                Properties = new Dictionary<string, Schema>();
                foreach (var member in sModel.Properties)
                {
                    Properties.Add(member.Key.ToCamelCase(), GenerateSchemaForProperty(member.Value));
                }
            }
        }

        private static Schema GenerateSchemaForProperty(ModelProperty property)
        {
            Schema schema = new Schema();
            schema.Type = property.Type?.ToCamelCase();

            if (schema.Type == null)
            {
                schema.Ref = DefinitionsRefLocation + property.Ref;
            }
            else if (schema.Type.Equals("array"))
            {
                schema.Items = CopyItem(property.Items);
            }
            return schema;
        }

        private static Item CopyItem(Item item)
        {
            var copiedItem = new Item();
            if (!string.IsNullOrEmpty(item.Type))
            {
                copiedItem.Type = item.Type;
                if (item.Items != null)
                    copiedItem.Items = CopyItem(item.Items);
            }
            else
            {
                copiedItem.Type = "object";
                copiedItem.Ref = DefinitionsRefLocation + item.Ref;
            }

            return copiedItem;
        }
    }
}
