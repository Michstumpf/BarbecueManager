using BarbecueManager.Domain.ParticipantFeature;
using BarbecueManager.Domain.ParticipantFeature.Interfaces;
using BarbecueManager.Domain.ParticipantFeature.Predicates;
using BarbecueManager.Patterns.Infrastructure;
using Dapper.FastCrud;
using ParticipantManager.Infrastructure.ParticipantFeature.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticipantManager.Infrastructure.ParticipantFeature
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly ParticipantPredicateFactory _predicateFactory;

        public ParticipantRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _predicateFactory = new ParticipantPredicateFactory();
        }

        public Participant Query(ParticipantIdentityPredicate identity)
        {
            using (var cn = _connectionFactory.CreateConnection())
            {
                Participant participant = _predicateFactory.Create(identity);

                return cn.Get(participant);
            }
        }

        public Participant[] Query(ParticipantQueryPredicate predicate)
        {
            using (var cn = _connectionFactory.CreateConnection())
            {
                return cn.Find<Participant>(statement =>
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

        public Participant Insert(Participant entity)
        {
            using (var cn = _connectionFactory.CreateConnection())
            {
                cn.Insert(entity);
            }

            return entity;
        }

        public Participant Update(Participant entity)
        {
            bool sucess = false;
            using (var cn = _connectionFactory.CreateConnection())
            {
                sucess = cn.Update(entity);
            }

            return sucess ? entity : null;
        }

        public Participant Delete(ParticipantIdentityPredicate predicate)
        {
            bool sucess = false;
            Participant Participant = _predicateFactory.Create(predicate);

            using (var cn = _connectionFactory.CreateConnection())
            {
                sucess = cn.Delete(Participant);
            }

            return sucess ? Participant : null;
        }

        public int Count(ParticipantQueryPredicate predicate)
        {
            using (var cn = _connectionFactory.CreateConnection())
            {

                int count = cn.Count<Participant>(statement =>
                {
                    statement.Where(_predicateFactory.Create(predicate));
                    statement.WithParameters(predicate);
                });

                return count;
            }
        }
    }
}
