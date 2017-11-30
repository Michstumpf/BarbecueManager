using BarbecueManager.Patterns.Application.Messages;
using BarbecueManager.Patterns.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarbecueManager.Patterns.Application
{
    public abstract class AbstractApp<TEntity, TIdentityPredicate, TMessage, TQueryPredicate>
        : IApp<TEntity, TIdentityPredicate, TMessage, TQueryPredicate>
        where TEntity : class
        where TMessage : class
        where TIdentityPredicate : AbstractIdentityPredicate
        where TQueryPredicate : AbstractQueryPredicate
    {
        private readonly IRepository<TEntity, TIdentityPredicate, TQueryPredicate> _repository;
        private readonly IValidator<TEntity> _validator;

        protected AbstractApp(
            IRepository<TEntity, TIdentityPredicate, TQueryPredicate> repository,
            IValidator<TEntity> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public virtual QueryResponse<TEntity> Query(QueryIdentityRequest<TIdentityPredicate> request)
        {
            var entity = _repository.Query(request.Predicate);

            var response = new QueryResponse<TEntity>()
            {
                StatusCode = 200,
                Payload = entity
            };

            return response;
        }

        public virtual QueryResponse<TEntity[]> Query(QueryPredicateRequest<TQueryPredicate> request)
        {
            var entities = _repository.Query(request.Predicate);

            var response = new QueryResponse<TEntity[]>()
            {
                StatusCode = 200,
                Payload = entities
            };

            return response;
        }

        public abstract TEntity CreateFromMessage(TMessage message);

        public virtual InsertResponse<TEntity> Insert(InsertRequest<TMessage> request)
        {
            var entity = CreateFromMessage(request.Message);

            var result = _validator.Validate<TEntity>(entity);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            entity = _repository.Insert(entity);

            var response = new InsertResponse<TEntity>()
            {
                StatusCode = 200,
                Payload = entity
            };

            return response;
        }

        public abstract TEntity UpdateFromMessage(TEntity entity, TMessage message);

        public virtual UpdateResponse<TEntity> Update(UpdateRequest<TIdentityPredicate, TMessage> request)
        {
            var entity = _repository.Query(request.Identity);

            entity = UpdateFromMessage(entity, request.Message);

            var result = _validator.Validate<TEntity>(entity);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            entity = _repository.Update(entity);

            var response = new UpdateResponse<TEntity>()
            {
                StatusCode = 200,
                Payload = entity
            };

            return response;
        }

        public DeleteResponse<TEntity> Delete(DeleteRequest<TIdentityPredicate> request)
        {
            var entity = _repository.Delete(request.Identity);

            var response = new DeleteResponse<TEntity>()
            {
                StatusCode = 200,
                Payload = entity
            };

            return response;
        }
    }
}