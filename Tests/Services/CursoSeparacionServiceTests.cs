using NUnit.Framework;
using Moq;
using wb_backend.Services;
using wb_backend.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Tests.Services
{
    public class CursoSeparacionServiceTests
    {
        private Mock<WujuDbContext> _mockDbContext;
        private CursoSeparacionService _cursoSeparacionService;

        [SetUp]
        public void Setup()
        {
            _mockDbContext = new Mock<WujuDbContext>();
            _cursoSeparacionService = new CursoSeparacionService(_mockDbContext.Object);
        }

        [Test]
        public async Task CreateCursoSeparacionAsync_Should_Add_New_CursoSeparacion()
        {
            // Arrange
            var newCursoSeparacion = new CursoSeparacion { Id = 1, First_name = "John", Last_name = "Doe" };
            _mockDbContext.Setup(x => x.CursoSeparacions.Add(newCursoSeparacion));
            _mockDbContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);


            // Act
            var result = await _cursoSeparacionService.CreateCursoSeparacionAsync(newCursoSeparacion);

            // Assert
            Assert.AreEqual(newCursoSeparacion, result);
        }

        [Test]
        public async Task GetCursoSeparacionByIdAsync_Should_Return_CursoSeparacion_With_Given_Id()
        {
            // Arrange
            var cursoSeparacion = new CursoSeparacion { Id = 1, First_name = "John", Last_name = "Doe" };
            var cursoSeparaciones = new List<CursoSeparacion> { cursoSeparacion };
            var mockDbSet = cursoSeparaciones.ToAsyncEnumerable().AsQueryable().BuildMockDbSet();
            _mockDbContext.Setup(x => x.CursoSeparacions).Returns(mockDbSet.Object);

            // Act
            var result = await _cursoSeparacionService.GetCursoSeparacionByIdAsync(1);

            // Assert
            Assert.AreEqual(cursoSeparacion, result);
        }

        [Test]
        public async Task GetAllCursoSeparacionesAsync_Should_Return_All_CursoSeparaciones()
        {
            // Arrange
            var cursoSeparaciones = new List<CursoSeparacion>
            {
                new CursoSeparacion { Id = 1, First_name = "John", Last_name = "Doe" },
                new CursoSeparacion { Id = 2, First_name = "Jane", Last_name = "Doe" }
            };
            var mockDbSet = cursoSeparaciones.ToAsyncEnumerable().AsQueryable().BuildMockDbSet();
            _mockDbContext.Setup(x => x.CursoSeparacions).Returns(mockDbSet.Object);

            // Act
            var result = await _cursoSeparacionService.GetAllCursoSeparacionesAsync();

            // Assert
            Assert.AreEqual(cursoSeparaciones.Count, result.Count());
            Assert.IsTrue(result.All(cs => cursoSeparaciones.Contains(cs)));
        }
    }


    
}
