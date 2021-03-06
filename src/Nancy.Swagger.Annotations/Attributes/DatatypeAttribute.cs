﻿using System;

namespace Nancy.Swagger.Annotations.Attributes
{
    public abstract class SwaggerDataTypeAttribute : Attribute
    {
        private long? _maximum;
        private long? _minium;
        private bool? _required;
        private bool? _uniqueItems;

        protected SwaggerDataTypeAttribute(string name)
        {
            Name = name;
        }

        public string Description { get; set; }

        public string[] Enum { get; set; }

        public long Maximum
        {
            get { return _maximum.GetValueOrDefault(); }
            set { _maximum = value; }
        }

        public long Minimum
        {
            get { return _minium.GetValueOrDefault(); }
            set { _minium = value; }
        }

        public string Name { get; set; }

        public bool Required
        {
            get { return _required.GetValueOrDefault(); }
            set { _required = value; }
        }

        public bool UniqueItems
        {
            get { return _uniqueItems.GetValueOrDefault(); }
            set { _uniqueItems = value; }
        }

        public long? GetNullableMaximum()
        {
            return _maximum;
        }

        public long? GetNullableMinimum()
        {
            return _minium;
        }

        public bool? GetNullableRequired()
        {
            return _required;
        }

        public bool? GetNullableUniqueItems()
        {
            return _uniqueItems;
        }
    }
}