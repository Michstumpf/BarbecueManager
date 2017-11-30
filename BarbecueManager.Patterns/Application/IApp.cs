using BarbecueManager.Patterns.Application.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarbecueManager.Patterns.Application
{
    public interface IApp<TEntity, TIdentityPredicate, TMessage, TQueryPredicate>
        where TEntity : class
        where TIdentityPredicate : AbstractIdentityPredicate
        where TMessage : class
        where TQueryPredicate : AbstractQueryPredicate
    {
        QueryResponse<TEntity> Query(QueryIdentityRequest<TIdentityPredicate> request);

        QueryResponse<TEntity[]> Query(QueryPredicateRequest<TQueryPredicate> request);

        InsertResponse<TEntity> Insert(InsertRequest<TMessage> request);

        UpdateResponse<TEntity> Update(UpdateRequest<TIdentityPredicate, TMessage> request);

        DeleteResponse<TEntity> Delete(DeleteRequest<TIdentityPredicate> request);
    }
}
