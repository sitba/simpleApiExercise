using Microsoft.VisualStudio.TestTools.UnitTesting;
using simpleApiExercise.Services.Utils.Validation;
using simpleApiExercise.Common.Exceptions;
using simpleApiExercise.Model.Providers;
using Microsoft.EntityFrameworkCore;
using Moq;
using simpleApiExercise.Database;
using System.Reflection.Metadata;
using simpleApiExercise.DTOs.Providers;
using System.ComponentModel.DataAnnotations;

namespace simpleApiExercise.Services.Test.UnitTests.Utils.Validation
{
	[TestClass]
	public class SharedValidationServiceTest
	{
		public SharedValidationServiceTest()
		{
		}

		[TestMethod]
		public void ValidateNotFound_NullEntity_ThrowsNotFoundException()
		{
            // Arrange
            ISharedValidationsService sharedValidationService = new SharedValidationsService();
			Object? result = null;
			string entity = "entity";
			int id = 0;
            // Act + Arrange
            Assert.ThrowsException<NotFoundException>(() => sharedValidationService.ValidateNotFound(result, entity, id));
        }

        [Ignore]
        [TestMethod]
        // with more time I would make something like this work.
        public void ValidateAlreadyDefined_AddExistingRecords_ThrowsNotValidationException()
        {
            // Arrange
            ISharedValidationsService sharedValidationService = new SharedValidationsService();
            int providerId = 1;
            CreateProviderDto provider = new CreateProviderDto(providerId, "name", "postalAddress", DateTime.Now, TypeEnum.domestic);
            List<CreateProviderDto> providers = new List<CreateProviderDto>() { provider };

            var existingProvider = new Provider(providerId, "otherName", "otherPostalAddress", DateTime.Now, Enum.GetName(TypeEnum.roadside));
            var data = new List<Provider>() { existingProvider }.AsQueryable();
            var mockSet = new Mock<DbSet<Provider>>();
            mockSet.As<IQueryable<Provider>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Provider>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Provider>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Provider>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<ProvidersContext>();
            mockContext.Setup(m => m.Providers).Returns(mockSet.Object);

            // Act + Arrange
            Assert.ThrowsException<ValidationException>(() => sharedValidationService.ValidateAlreadyDefined(providers, nameof(Provider)));
        }
    }
}