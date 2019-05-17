using System;
using System.Collections.Generic;

namespace Nancy.Swagger
{
    /// <summary>
    /// This class allows you to customize how you want a type to be represented in the swagger output. 
    /// For example, if a service serializes/deserializes DateTime as a string when being sent/received, 
    /// there should be a SwaggerTypeMapping from DateTime to string in order to make the swagger output match what is actually expected.
    /// </summary>
    public static class SwaggerTypeMapping
    {
        private static readonly Dictionary<Type, Type> TypeMappings = new Dictionary<Type, Type>();
        
        public static void AddTypeMapping(Type source, Type target)
        {
            TypeMappings[source] = target;
        }

        public static bool IsMappedType(Type type)
        {
            return TypeMappings.ContainsKey(type);
        }

        public static Type GetMappedType(Type type)
        {
            return GetMappedType(type, new HashSet<Type>());
        }

        private static Type GetMappedType(Type type, ISet<Type> previousTypes)
        {
            if (!TypeMappings.ContainsKey(type))
                throw new ArgumentException($"Type '{type.FullName}' does not have a mapping.");

            var returnType = TypeMappings[type];

            //Check to see if there are any indirect mappings
            if (!IsMappedType(returnType))
                return returnType;

            //Only perform recursion if there is no cycle yet
            if (previousTypes.Contains(type))
                return returnType;

            previousTypes.Add(type);
            return GetMappedType(returnType, previousTypes);
        }
    }
}
