﻿using System;
using MvcSiteMapProvider.Builder;
using MvcSiteMapProvider.Caching;
using MvcSiteMapProvider.Globalization;
using MvcSiteMapProvider.Web.Script.Serialization;

namespace MvcSiteMapProvider.Collections.Specialized
{
    /// <summary>
    /// An abstract factory that can be used to create new instances of <see cref="T:MvcSiteMapProvider.Collections.Specialized.AttributeDictionary"/>
    /// at runtime.
    /// </summary>
    public class AttributeDictionaryFactory
        : IAttributeDictionaryFactory
    {
        public AttributeDictionaryFactory(
            IRequestCache requestCache,
            IReservedAttributeNameProvider reservedAttributeNameProvider,
            IJsonToDictionaryDeserializer jsonToDictionaryDeserializer
            )
        {
            if (requestCache == null)
                throw new ArgumentNullException("requestCache");
            if (reservedAttributeNameProvider == null)
                throw new ArgumentNullException("reservedAttributeNameProvider");
            if (jsonToDictionaryDeserializer == null)
                throw new ArgumentNullException("jsonToDictionaryDeserializer");

            this.requestCache = requestCache;
            this.reservedAttributeNameProvider = reservedAttributeNameProvider;
            this.jsonToDictionaryDeserializer = jsonToDictionaryDeserializer;
        }

        protected readonly IRequestCache requestCache;
        protected readonly IReservedAttributeNameProvider reservedAttributeNameProvider;
        protected readonly IJsonToDictionaryDeserializer jsonToDictionaryDeserializer;

        #region IAttributeDictionaryFactory Members

        public virtual IAttributeDictionary Create(string siteMapNodeKey, string memberName, ISiteMap siteMap, ILocalizationService localizationService)
        {
            return new AttributeDictionary(siteMapNodeKey, memberName, siteMap, localizationService, this.reservedAttributeNameProvider, this.jsonToDictionaryDeserializer, this.requestCache);
        }

        #endregion
    }
}
