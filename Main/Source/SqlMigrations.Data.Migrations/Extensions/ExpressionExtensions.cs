namespace SqlMigrations.Data.Migrations.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    internal static class ExpressionExtensions
    {
        public static IEnumerable<PropertyInfo> GetPropertyAccessList(this LambdaExpression propertyAccessExpression)
        {
            IEnumerable<PropertyInfo> enumerable = MatchPropertyAccessList(propertyAccessExpression, (Func<Expression, Expression, PropertyInfo>)((p, e) => ExpressionExtensions.MatchPropertyAccess(e, p)));
            if (enumerable == null)
            {
                throw new InvalidOperationException("propertyAccessExpression is not valid");
            }

            return enumerable;
        }

        private static IEnumerable<PropertyInfo> MatchPropertyAccessList(this LambdaExpression lambdaExpression, Func<Expression, Expression, PropertyInfo> propertyMatcher)
        {
            var newExpression = RemoveConvert(lambdaExpression.Body) as NewExpression;
            if (newExpression != null)
            {
                ParameterExpression parameterExpression = lambdaExpression.Parameters.Single();
                IEnumerable<PropertyInfo> enumerable = newExpression.Arguments.Select(a => propertyMatcher(a, parameterExpression)).Where(p => p != null);
                if (enumerable.Count() == newExpression.Arguments.Count())
                {
                    if (!HasDefaultMembersOnly(newExpression, enumerable))
                    {
                        return null;
                    }
                    
                    return enumerable;
                }
            }

            var propertyInfo = propertyMatcher(lambdaExpression.Body, lambdaExpression.Parameters.Single());
            if (propertyInfo == null)
            {
                return null;
            }

            return new[] { propertyInfo };
        }

        private static bool HasDefaultMembersOnly(this NewExpression newExpression, IEnumerable<PropertyInfo> propertyInfos)
        {
            return !newExpression.Members.Where((t, i) => !string.Equals(t.Name, propertyInfos.ElementAt(i).Name, StringComparison.Ordinal)).Any();
        }

        private static PropertyInfo MatchPropertyAccess(this Expression parameterExpression, Expression propertyAccessExpression)
        {
            var memberExpression = RemoveConvert(propertyAccessExpression) as MemberExpression;
            if (memberExpression == null)
            {
                return null;
            }

            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo == null)
            {
                return null;
            }

            return memberExpression.Expression != parameterExpression
                ? null 
                : propertyInfo;
        }

        public static Expression RemoveConvert(this Expression expression)
        {
            while (expression != null && (expression.NodeType == ExpressionType.Convert || expression.NodeType == ExpressionType.ConvertChecked))
            {
                expression = RemoveConvert(((UnaryExpression)expression).Operand);
            }

            return expression;
        }
    }
}
