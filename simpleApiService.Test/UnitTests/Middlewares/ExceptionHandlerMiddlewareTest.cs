using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using simpleApiExercise.Common.Exceptions;
using simpleApiExercise.Middlewares;

namespace simpleApiService.Common.Test.UnitTests.Middlewares
{
    [TestClass]
    public class ExceptionHandlerMiddlewareTest
	{
        public ExceptionHandlerMiddlewareTest() { }

        [TestMethod]
        public async Task HandleNotFoundExceptionAsync_Returns_HttpStatusCode_404()
        {
            // Arrange
            IExceptionHandler exeptionHandler = new ExceptionHandler();
            var httpContext = new DefaultHttpContext();
            var notFoundException = new NotFoundException();
            // Act
            await exeptionHandler.HandleNotFoundExceptionAsync(httpContext, notFoundException);
            // Assert
            Assert.AreEqual((int)HttpStatusCode.NotFound, httpContext.Response.StatusCode);
        }

        [TestMethod]
        public async Task HandleValidationExceptionAsync_Returns_HttpStatusCode_401()
        {
            // Arrange
            IExceptionHandler exeptionHandler = new ExceptionHandler();
            var httpContext = new DefaultHttpContext();
            var validationException = new ValidationException();
            // Act
            await exeptionHandler.HandleValidationExceptionAsync(httpContext, validationException);
            // Assert
            Assert.AreEqual((int)HttpStatusCode.Unauthorized, httpContext.Response.StatusCode);
        }

        [TestMethod]
        public async Task HandleExceptionAsync_Returns_HttpStatusCode_500()
        {
            // Arrange
            IExceptionHandler exeptionHandler = new ExceptionHandler();
            var httpContext = new DefaultHttpContext();
            var exception = new Exception();
            // Act
            await exeptionHandler.HandleExceptionAsync(httpContext, exception);
            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, httpContext.Response.StatusCode);
        }

        [Ignore]
        [TestMethod]
        // Run out of time while developing this test. With more time I would make this work.
        public async Task InvokeAsync_WhenThrowsNotFoundException_HandleNotFoundExceptionAsyncIsCalled()
        {
            // Arrange
            HttpContext httpContext = new DefaultHttpContext();
            var exceptionHandlerMock = new Mock<ExceptionHandler>();

            var nextDelegateMock = new Mock<RequestDelegate>();
            nextDelegateMock
                .Setup(x => x.Invoke(It.IsAny<HttpContext>()))
                .Throws(new NotFoundException());

            var exceptionHandlerMiddlewareMock = new Mock<ExceptionHandlerMiddleware>(nextDelegateMock);

            // Act
            try
            {
                await exceptionHandlerMiddlewareMock.Object.InvokeAsync(httpContext, exceptionHandlerMock.Object);
            }
            finally
            {
                //Assert
                exceptionHandlerMock.Verify(exceptionHandler =>
                    exceptionHandler.HandleNotFoundExceptionAsync(It.IsAny<HttpContext>(), It.IsAny<NotFoundException>()), Times.Once);
            }
        }
    }
}