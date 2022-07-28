using Api.Context;
using Api.Repositories;
using Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Tests
{
    public abstract class TestBase
    {
        protected IRepositoryWrapper? _repository;

        protected TestBase()
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>().UseInMemoryDatabase(databaseName: "dotz_in_memo").Options;
            var context = new RepositoryContext(options);
            _repository = new RepositoryWrapper(context);
        }
    }
}
