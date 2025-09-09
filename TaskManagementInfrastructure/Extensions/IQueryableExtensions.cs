﻿namespace TaskManagementInfrastructure.Helper
{
    public static class IQueryableExtensions
    {

        public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> query, string propertyName)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(param, propertyName);
            var lambda = Expression.Lambda(property, param);
            var method = typeof(Queryable).GetMethods()
                .First(m => m.Name == "OrderBy" && m.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), property.Type);
            return (IQueryable<T>)method.Invoke(null, new object[] { query, lambda });
        }

        public static IQueryable<T> OrderByDescendingDynamic<T>(this IQueryable<T> query, string propertyName)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(param, propertyName);
            var lambda = Expression.Lambda(property, param);
            var method = typeof(Queryable).GetMethods()
                .First(m => m.Name == "OrderByDescending" && m.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), property.Type);
            return (IQueryable<T>)method.Invoke(null, new object[] { query, lambda });
        }

    }
}
