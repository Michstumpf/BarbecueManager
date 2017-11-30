using BarbecueManager.Patterns.Application.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarbecueManager.Patterns.Repository
{
    public interface IRepository<TEntity, TIdentityPredicate, TQueryPredicate>
            where TEntity : class
            where TIdentityPredicate : AbstractIdentityPredicate
            where TQueryPredicate : AbstractQueryPredicate
    {
        TEntity Query(TIdentityPredicate predicate);

        TEntity[] Query(TQueryPredicate predicate);

        TEntity Insert(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity Delete(TIdentityPredicate identity);

        int Count(TQueryPredicate predicate);
    }
}
