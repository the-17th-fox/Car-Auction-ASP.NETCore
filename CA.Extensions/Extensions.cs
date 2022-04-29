using CA.Domain.Entities;
using System.Linq.Expressions;

namespace CA.Extensions
{
    public static class Extensions
    {
        public static IQueryable<TEntity> WhereIdEquals<TEntity>(
            this IQueryable<TEntity> source,
            Expression<Func<TEntity, int>> keyExpression,
            int otherKeyValue)
            where TEntity : BasicEntity
        {
            var memberExpression = (MemberExpression)keyExpression.Body;
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var property = Expression.Property(parameter, memberExpression.Member.Name);
            var equal = Expression.Equal(property, Expression.Constant(otherKeyValue));
            var lambda = Expression.Lambda<Func<TEntity, bool>>(equal, parameter);
            return source.Where(lambda);
        }
    }
}