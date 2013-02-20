using System;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;

namespace ShowPlanner.Data.Orm
{
    public static class ObjectContextExtensions
    {
        internal static EntitySetBase GetEntitySet<TEntity>(this ObjectContext context)
        {
            var container = context.MetadataWorkspace
                .GetEntityContainer(context.DefaultContainerName, DataSpace.CSpace);
            var baseType = GetBaseType(typeof (TEntity));
            var entitySet = container.BaseEntitySets
                .FirstOrDefault(item => item.ElementType.Name.Equals(baseType.Name));

            return entitySet;
        }

        private static Type GetBaseType(Type type)
        {
            var baseType = type.BaseType;
            if (baseType != null && baseType != typeof (EntityObject))
            {
                return GetBaseType(type.BaseType);
            }
            return type;
        }
    }
}