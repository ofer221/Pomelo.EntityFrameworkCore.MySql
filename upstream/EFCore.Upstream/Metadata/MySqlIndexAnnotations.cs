// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Pomelo.EntityFrameworkCore.MySql.Metadata.Internal;

namespace Microsoft.EntityFrameworkCore.Metadata
{
    /// <summary>
    ///     Properties for relational-specific annotations accessed through
    ///     <see cref="MySqlMetadataExtensions.MySql(IMutableIndex)" />.
    /// </summary>
    public class MySqlIndexAnnotations : RelationalIndexAnnotations, IMySqlIndexAnnotations
    {
        /// <summary>
        ///     Constructs an instance for annotations of the given <see cref="IIndex" />.
        /// </summary>
        /// <param name="index"> The <see cref="IIndex" /> to use. </param>
        public MySqlIndexAnnotations([NotNull] IIndex index)
            : base(index)
        {
        }

        /// <summary>
        ///     Constructs an instance for annotations of the <see cref="IIndex" />
        ///     represented by the given annotation helper.
        /// </summary>
        /// <param name="annotations">
        ///     The <see cref="RelationalAnnotations" /> helper representing the <see cref="IIndex" /> to annotate.
        /// </param>
        protected MySqlIndexAnnotations([NotNull] RelationalAnnotations annotations)
            : base(annotations)
        {
        }

        /// <summary>
        ///     Indicates whether or not the index is clustered, or <c>null</c> if clustering has not
        ///     been specified.
        /// </summary>
        public virtual bool? IsClustered
        {
            get => (bool?)Annotations.Metadata[MySqlAnnotationNames.Clustered];
            set => SetIsClustered(value);
        }

        /// <summary>
        ///     Attempts to set clustering using the semantics of the <see cref="RelationalAnnotations" /> in use.
        /// </summary>
        /// <param name="value"> The value to set. </param>
        /// <returns> <c>True</c> if the annotation was set; <c>false</c> otherwise. </returns>
        protected virtual bool SetIsClustered(bool? value) => Annotations.SetAnnotation(
            MySqlAnnotationNames.Clustered,
            value);
    }
}
