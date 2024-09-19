using Crud.Domain.Commands;
using Crud.Domain.Handlers;
using Crud.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Crud.Test
{
    public class CreatePersonCommandHandlerTests
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly CreatePersonCommandHandler _handler;

        public CreatePersonCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Crud")
                .Options;

            _dbContext = new ApplicationDbContext(options);

            _handler = new CreatePersonCommandHandler(_dbContext);
        }

        [Fact]
        public async Task Handle_ShouldCreatePerson_WhenCommandIsValid()
        {
            var command = new CreatePersonCommand { Name = "Daniel Silva", Age = 30 };

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.True(result > 0);

            var person = await _dbContext.Persons.FirstOrDefaultAsync(p => p.Id == result);
            Assert.NotNull(person);
            Assert.Equal("Daniel Silva", person.Name);
        }
    }
}
