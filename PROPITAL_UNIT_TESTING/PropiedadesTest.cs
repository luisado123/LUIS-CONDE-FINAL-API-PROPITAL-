using API_LUIS_CONDE_PERSONALSOFT.Controllers;
using API_LUIS_CONDE_PERSONALSOFT.Models;
using API_LUIS_CONDE_PERSONALSOFT.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace PROPITAL_UNIT_TESTING
{
    public class PropiedadesTest
    {
        private readonly IPropiedadColeccion _propiedadService;
        private readonly PropiedadController _propiedadController;


        public PropiedadesTest()
        {
            _propiedadService = new PropiedadColeccion();
            _propiedadController = new PropiedadController(_propiedadService);
        }


        [Fact]
        public async Task GetAllPropiedadesOk()
        {
            var result = await _propiedadController.GetAllPropiedades();
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public async Task GetAllPropiedadesByCategoriaOk()
        {
            string ciudadPrueba = "Oficinas";
            var result = await _propiedadController.GetPropiedadesByCiudad(ciudadPrueba);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetExistenPropiedadesByCiudadOk()
        {
            string ciudadPrueba = "Santiago de Chile";
            var result = await _propiedadController.GetPropiedadesByCiudad(ciudadPrueba);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetAllPropiedadesByCategoriaNotElementsFound()
        {
            string categoriaPrueba = "Penthouse";
            var result = await _propiedadController.GetPropiedadesByCiudad(categoriaPrueba);
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var propiedades = Assert.IsType<List<PropiedadDto>>(okObjectResult.Value);
            Assert.Empty(propiedades);
        }

        [Fact]
        public async Task GetAllPropiedadesByCiudadNotElementsFound()
        {
            string ciudadPrueba = "Moscú";
            var result = await _propiedadController.GetPropiedadesByCiudad(ciudadPrueba);
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var propiedades = Assert.IsType<List<PropiedadDto>>(okObjectResult.Value);
            Assert.Empty(propiedades);
        }


    }
}