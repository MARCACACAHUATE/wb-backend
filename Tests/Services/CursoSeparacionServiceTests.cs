using NUnit.Framework;
using Moq;
using wb_backend.Services;
using wb_backend.Models;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;

namespace Tests.Services
{
    public class CursoSeparacionServiceTests
    {
        //private Mock<WujuDbContext> _mockDbContext;
        //private CursoSeparacionService _cursoSeparacionService;
        private CursoSeparacionService _cursoSeparacionService;
        private WujuDbContext _dbContext;


        [SetUp]
        public void Setup()
        {
           // _mockDbContext = new Mock<WujuDbContext>();
            //_cursoSeparacionService = new CursoSeparacionService(_mockDbContext.Object);

            // Configurar el contexto de base de datos en memoria
            var options = new DbContextOptionsBuilder<WujuDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _dbContext = new WujuDbContext(options,null);
            _cursoSeparacionService = new CursoSeparacionService(_dbContext);
        }

        [Test]
        public async Task CreateCursoSeparacionAsync_Should_Add_New_CursoSeparacion()
        {
            // Arrange
            var newCursoSeparacion = new CursoSeparacion { First_name = "Luis", Last_name = "Lopez", Edad=20, Telefono= 73374283, Email = "luis@hotmail.com", Cantidad_personas_contratadas=1, IdCursos=1 };

            // Act
            var result = await _cursoSeparacionService.CreateCursoSeparacionAsync(newCursoSeparacion);

            // Imprimir el ID del curso que se agrego CursoSeparacion
            Console.WriteLine("Agregado CursoSeparacion ID: " + newCursoSeparacion.Id);

            // Assert
            Assert.AreEqual(newCursoSeparacion, result);

            // Verificar que el nuevo CursoSeparacion se agregó correctamente al DbContext
            var addedCursoSeparacion = await _dbContext.CursoSeparacions.FindAsync(newCursoSeparacion.Id);
            Assert.AreEqual(newCursoSeparacion, addedCursoSeparacion);
        }


        [Test]
        public async Task GetCursoSeparacionByIdAsync_Should_Return_CursoSeparacion_With_Given_Id()
        {
            // Arrange
            var cursoSeparacion = new CursoSeparacion { First_name = "Luis", Last_name = "Lopez", Edad=20, Telefono= 73374283, Email = "luis@hotmail.com", Cantidad_personas_contratadas=1, IdCursos=1 };
            _dbContext.CursoSeparacions.Add(cursoSeparacion);
            await _dbContext.SaveChangesAsync();

            // Imprimir los registros de CursoSeparacion en la base de datos
            var cursosSeparacion = await _dbContext.CursoSeparacions.ToListAsync();
            Console.WriteLine("Registros de CursoSeparacion en la base de datos:");
            foreach (var cs in cursosSeparacion)
            {
                Console.WriteLine($"ID: {cs.Id}");
                Console.WriteLine($"First name: {cs.First_name}");
                // Imprimir otros campos si es necesario
            }

            // Act
            var result = await _cursoSeparacionService.GetCursoSeparacionByIdAsync(1);

            // Imprimir el ID del curso que se agrego CursoSeparacion
            Console.WriteLine("Agregado CursoSeparacion ID: " + cursoSeparacion.Id);

            // Assert
            result.Should().NotBeNull(); // Verificar que el resultado no sea nulo
            result.Should().BeEquivalentTo(cursoSeparacion, options => options.Excluding(x => x.Id)); // Comparar todas las propiedades excepto Id
            result.Id.Should().Be(cursoSeparacion.Id); // Comparar la propiedad Id por separado
        }

        [Test]
        public async Task GetAllCursoSeparacionesAsync_Should_Return_All_CursoSeparaciones()
        {
            // Arrange
            var cursoSeparaciones = new List<CursoSeparacion>
            {
                new CursoSeparacion { First_name = "Luis", Last_name = "Lopez", Edad=20, Telefono= 73374283, Email = "luis@hotmail.com", Cantidad_personas_contratadas=1, IdCursos=1 },
                new CursoSeparacion { First_name = "Dana", Last_name = "Gonzalez", Edad=20, Telefono= 6216516, Email = "dana@hotmail.com", Cantidad_personas_contratadas=1, IdCursos=2 }
            };

            foreach (var cursoSeparacion in cursoSeparaciones)
            {
                _dbContext.CursoSeparacions.Add(cursoSeparacion);
            }
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _cursoSeparacionService.GetAllCursoSeparacionesAsync();

            // Assert
            Assert.AreEqual(cursoSeparaciones.Count, result.Count());
            Assert.IsTrue(result.All(cs => cursoSeparaciones.Contains(cs)));
        }


        [Test]
        public async Task UpdateCursoSeparacionAsync_Should_Update_CursoSeparacion()
        {
            // Arrange
            var existingCursoSeparacion = new CursoSeparacion { First_name = "Luis", Last_name = "Lopez" };
            _dbContext.CursoSeparacions.Add(existingCursoSeparacion);
            await _dbContext.SaveChangesAsync();

            var updatedCursoSeparacion = new CursoSeparacion { First_name = "RamonActualizado", Last_name = "Lopez" , Edad=20, Telefono= 6216516, Email = "ramon@hotmail.com", Cantidad_personas_contratadas=1, IdCursos=2 };

            // Act
            var result = await _cursoSeparacionService.UpdateCursoSeparacionAsync(updatedCursoSeparacion.Id, updatedCursoSeparacion);

            // Assert
            Assert.AreEqual(updatedCursoSeparacion, result);

            // Verificar que el CursoSeparacion se actualizó correctamente en el DbContext
            var updatedCursoSeparacionInDb = await _dbContext.CursoSeparacions.FindAsync(updatedCursoSeparacion.Id);
            Assert.AreEqual(updatedCursoSeparacion, updatedCursoSeparacionInDb);
        }

        [Test]
        public async Task DeleteCursoSeparacionAsync_Should_Delete_CursoSeparacion()
        {
            // Arrange
            var existingCursoSeparacion = new CursoSeparacion { First_name = "Luis", Last_name = "Lopez", Edad=20, Telefono= 6216516, Email = "luis@hotmail.com", Cantidad_personas_contratadas=1, IdCursos=1 };
            _dbContext.CursoSeparacions.Add(existingCursoSeparacion);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _cursoSeparacionService.DeleteCursoSeparacionAsync(existingCursoSeparacion.Id);

            // Assert
            Assert.IsTrue(result);

            // Verificar que el CursoSeparacion se eliminó correctamente del DbContext
            var deletedCursoSeparacion = await _dbContext.CursoSeparacions.FindAsync(existingCursoSeparacion.Id);
            Assert.IsNull(deletedCursoSeparacion);
        }

        [Test]
        public async Task GetCursoSeparacionesAsync_Should_Return_All_CursoSeparaciones()
        {
            // Arrange
            var cursoSeparaciones = new List<CursoSeparacion>
            {
               new CursoSeparacion { First_name = "Luis", Last_name = "Lopez", Edad=20, Telefono= 73374283, Email = "luis@hotmail.com", Cantidad_personas_contratadas=1, IdCursos=1 },
                new CursoSeparacion { First_name = "Dana", Last_name = "Gonzalez", Edad=20, Telefono= 6216516, Email = "dana@hotmail.com", Cantidad_personas_contratadas=1, IdCursos=2 }
            };

            foreach (var cursoSeparacion in cursoSeparaciones)
            {
                _dbContext.CursoSeparacions.Add(cursoSeparacion);
            }
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _cursoSeparacionService.GetCursoSeparacionesAsync();

            // Assert
            Assert.AreEqual(cursoSeparaciones.Count, result.Count());
            Assert.IsTrue(result.All(cs => cursoSeparaciones.Contains(cs)));
        }


        [Test]
        public async Task GetSeparacionesByCursoIdAsync_Should_Return_Separaciones_With_Given_CursoId()
        {
            // Arrange
            int cursoId = 1;
            var separaciones = new List<CursoSeparacion>
            {
                new CursoSeparacion { Id = 1, IdCursos = 1, First_name = "Luis", Last_name = "Lopez", Edad=20, Telefono= 73374283, Email = "luis@hotmail.com", Cantidad_personas_contratadas=1 },
                new CursoSeparacion { Id = 2, IdCursos = 1, First_name = "Jorge", Last_name = "Lopez", Edad=20, Telefono= 65465185, Email = "jorge@hotmail.com", Cantidad_personas_contratadas=1 },
                new CursoSeparacion { Id = 3, IdCursos = 2, First_name = "Dana", Last_name = "Lopez", Edad=20, Telefono= 68411975, Email = "dana@hotmail.com", Cantidad_personas_contratadas=1, },
            };

            _dbContext.CursoSeparacions.AddRange(separaciones);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _cursoSeparacionService.GetSeparacionesByCursoIdAsync(cursoId);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.Should().OnlyContain(s => s.IdCursos == cursoId);
        }

    }


    
}
