﻿using CodingCamp44.Context;
using CodingCamp44.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CodingCamp44.Repositories
{
    public class GeneralRepository<Entity, Context> : IRepository<Entity>
        where Entity : class
        where Context : MyContext
    {
        private readonly MyContext myContext;
        private DbSet<Entity> entities;

        public GeneralRepository(MyContext myContext)
        {
            this.myContext = myContext;
            entities = myContext.Set<Entity>();
        }

        public int Create(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                entities.Add(entity);
                var result = myContext.SaveChanges();
                return result;
            }
        }

        public int Delete(int id)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                Entity entity = entities.Find(id);
                entities.Remove(entity);
                var result = myContext.SaveChanges();
                return result;
            }
        }

        public IEnumerable<Entity> Get()
        {
            return entities.AsEnumerable();
        }

        public Entity Get(int id)
        {
            return entities.Find(id);
        }

        public int Update(int id, Entity entity)
        {
            if (entity == null)
            {
            	throw new ArgumentNullException("entity");
	    }
            else
            {
            	try
            	{
                     myContext.Entry(entity).State = EntityState.Modified;
                        var result = myContext.SaveChanges();
                        return result;
                    }

                    catch (Exception)
                    {
                        throw;
                    }
                }
        }
    }
}
