﻿using Microsoft.EntityFrameworkCore;
using Template.Shared.Kernel.Domain;
using Template.Shared.Kernel.Mediator;
using System.Linq;
using System.Threading.Tasks;

namespace Template.Infrastructure.Data.Extensions
{
    public static class MediatorExtension
    {
        public static async Task PublishEvents<T>(this IMediatorHandler mediator, T context) where T : DbContext
        {
            var domainEntities = context.ChangeTracker
                                            .Entries<Entity>()
                                            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities.SelectMany(x => x.Entity.DomainEvents).ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents.Select(async (domainEvent) =>
            {
                await mediator.PublishEvent(domainEvent);
            });

            await Task.WhenAll(tasks);
        }
    }
}
