﻿// <auto-generated/> - StyleCop hack to not enforce commentation errors in this file.
namespace Merchello.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Merchello.Core.Acquired;
    using Merchello.Core.Logging;
    using Merchello.Core.Marketing.Offer;

    using Umbraco.Core;

    /// <summary>
    /// Extension methods for <see cref="OfferComponentDefinition"/>.
    /// </summary>
    public static partial class Extensions
    {

        /// <summary>
        /// Wrapper to retrieve the <see cref="OfferComponentAttribute"/>.
        /// </summary>
        /// <param name="component">
        /// The component.
        /// </param>
        /// <returns>
        /// The <see cref="OfferComponentAttribute"/>.
        /// </returns>
        public static OfferComponentAttribute GetOfferComponentAttribute(this OfferComponentBase component)
        {
            return component.GetType().GetCustomAttribute<OfferComponentAttribute>(false);
        }

        /// <summary>
        /// Maps the <see cref="OfferComponentDefinition"/> to a <see cref="OfferComponentConfiguration"/> so 
        /// that it can be serialized and saved to the database as JSON more easily.
        /// </summary>
        /// <param name="definition">
        /// The definition.
        /// </param>
        /// <returns>
        /// The <see cref="OfferComponentConfiguration"/>.
        /// </returns>
        internal static OfferComponentConfiguration AsOfferComponentConfiguration(this OfferComponentDefinition definition)
        {
            if (!OfferComponentResolver.HasCurrent) throw new NullReferenceException("The OfferComponentResolver singleton has not been instantiated");

            var type = OfferComponentResolver.Current.GetTypeByComponentKey(definition.ComponentKey);
            if (type != null)
            {
                return new OfferComponentConfiguration()
                {
                    OfferSettingsKey = definition.OfferSettingsKey,
                    OfferCode = definition.OfferCode,
                    ComponentKey = definition.ComponentKey,
                    TypeFullName = type.FullName,
                    Values = definition.ExtendedData.AsEnumerable().ToArray()
                };
            }

            var nullRef = new NullReferenceException("Was not able to resolve the OfferComponentType with key: " + definition.ComponentKey);
            MultiLogHelper.Error(typeof(Extensions), "Unable to resolve OfferCompoent", nullRef);
            throw nullRef;
        }
    }
}
