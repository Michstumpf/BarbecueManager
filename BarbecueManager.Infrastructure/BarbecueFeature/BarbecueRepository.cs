using BarbecueManager.Domain.BarbecueFeature.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper.FastCrud;
using BarbecueManager.Domain.BarbecueFeature;
using BarbecueManager.Domain.BarbecueFeature.Predicates;
using BarbecueManager.Infrastructure.BarbecueFeature.Factories;
using BarbecueManager.Patterns.Infrastructure;
using System.Linq;
using BarbecueManager.Domain.ParticipantFeature;

namespace BarbecueManager.Infrastructure.BarbecueFeature
{
    public class BarbecueRepository : IBarbecueRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly BarbecuePredicateFactory _predicateFactory;

        public BarbecueRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _predicateFactory = new BarbecuePredicateFactory();
        }

        public Barbecue Query(BarbecueIdentityPredicate identity)
        {
            using (var cn = _connectionFactory.CreateConnection())
            {
                Barbecue barbecue = _predicateFactory.Create(identity);

                return cn.Get(barbecue,
                    statement => statement.Include<Participant>(join => join.InnerJoin()));
            }
        }

        public Barbecue[] Query(BarbecueQueryPredicate predicate)
        {
            using (var cn = _connectionFactory.CreateConnection())
            {
                return cn.Find<Barbecue>(statement =>
                {
                    statement.Where(_predicateFactory.Create(predicate));

                    if (predicate.Offset > 0)
                        statement.Skip(predicate.Offset);

                    if (predicate.Limit > 0)
                        statement.Top(predicate.Limit);

                    statement.WithParameters(predicate);
                }).ToArray();
            }
        }

        public Barbecue Insert(Barbecue entity)
        {
            using (var cn = _connectionFactory.CreateConnection())
            {
                cn.Insert(entity);
            }

            return entity;
        }

        public Barbecue Update(Barbecue entity)
        {
            bool sucess = false;
            using (var cn = _connectionFactory.CreateConnection())
            {
                sucess = cn.Update(entity);
            }

            return sucess ? entity : null;
        }

        public Barbecue Delete(BarbecueIdentityPredicate predicate)
        {
            bool sucess = false;
            Barbecue barbecue = _predicateFactory.Create(predicate);

            using (var cn = _connectionFactory.CreateConnection())
            {
                sucess = cn.Delete(barbecue);
            }

            return sucess ? barbecue : null;
        }

        public int Count(BarbecueQueryPredicate predicate)
        {
            using (var cn = _connectionFactory.CreateConnection())
            {

                int count = cn.Count<Barbecue>(statement =>
                {
                    statement.Where(_predicateFactory.Create(predicate));
                    statement.WithParameters(predicate);
                });

                return count;
            }
        }
    }
}
