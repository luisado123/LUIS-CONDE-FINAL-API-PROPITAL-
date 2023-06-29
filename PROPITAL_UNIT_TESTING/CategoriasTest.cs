using API_LUIS_CONDE_PERSONALSOFT.Controllers;
using API_LUIS_CONDE_PERSONALSOFT.Models;
using API_LUIS_CONDE_PERSONALSOFT.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROPITAL_UNIT_TESTING
{

    public class CategoriasTest
    {

        private readonly ICategoriaColeccion _categoriaService;
        private readonly CategoriaController _categoriaController;


        public CategoriasTest()
        {
            _categoriaService = new CategoriaColeccion();
            _categoriaController = new CategoriaController(_categoriaService);
        }


        [Fact]
        public async Task GetAllCategoriasOk()
        {
            var result = await _categoriaController.GetAllCategorias();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task  GetAllCategoriasByIdOK()
        {
            string idCategoria = "6499d42823ba1325e39bfe3e";
            var result = await _categoriaController.GetCategoriaByIdCategoria(idCategoria);
            Assert.IsType<OkObjectResult>(result);

        }


        [Fact]
        public async Task GetAllCategoriasByIdNotElementsFound()
        {
            string idCategoria = "6499d42829999925e39bfe3e";
            var result = await _categoriaController.GetCategoriaByIdCategoria(idCategoria);
            var notFoundObjectResult = Assert.IsType<OkObjectResult>(result);
            var categorias = notFoundObjectResult.Value as List<CategoriaDto>;
            Assert.Null(categorias);

        }



        [Fact]
        public async Task GetAllCategoriasByNombreOk()
        {
            string nombreCategoria = "Oficinas";
            var result = await _categoriaController.GetCategoriaByNombre(nombreCategoria);
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public async Task GetAllCategoriasByNombreNotElementsFound()
        {
            string nombreCategoria = "Duplex";
            var result = await _categoriaController.GetCategoriaByNombre(nombreCategoria);
            var notFoundObjectResult = Assert.IsType<OkObjectResult>(result);
            var categorias = notFoundObjectResult.Value as List<CategoriaDto>;
            Assert.Null(categorias);

        }
    }


}
