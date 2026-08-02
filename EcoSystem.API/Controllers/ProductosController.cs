using EcoSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private static readonly List<Producto> Productos = new()
        {
            new Producto
            {
                Id = 1,
                CategoriaId = 1,
                Nombre = "Sensor de Temperatura Pro",
                Descripcion = "Sensor para monitoreo ambiental",
                Precio = 249.99m,
                Stock = 42,
                SKU = "SENSOR-TEMP-001"
            },
            new Producto
            {
                Id = 2,
                CategoriaId = 1,
                Nombre = "Módulo WiFi ESP32-CAM",
                Descripcion = "Módulo de conectividad inalámbrica",
                Precio = 89.50m,
                Stock = 118,
                SKU = "WIFI-ESP32-CAM"
            },
            new Producto
            {
                Id = 3,
                CategoriaId = 1,
                Nombre = "Gateway IoT Industrial",
                Descripcion = "Dispositivo de comunicación para entornos industriales",
                Precio = 1299.00m,
                Stock = 7,
                SKU = "GATEWAY-IOT-001"
            },
            new Producto
            {
                Id = 4,
                CategoriaId = 1,
                Nombre = "Cable USB-C Blindado 2m",
                Descripcion = "Cable reforzado para conexión de dispositivos",
                Precio = 19.99m,
                Stock = 350,
                SKU = "CABLE-USBC-002"
            },
            new Producto
            {
                Id = 5,
                CategoriaId = 1,
                Nombre = "Batería LiPo 3.7V 2000mAh",
                Descripcion = "Batería recargable para proyectos electrónicos",
                Precio = 34.75m,
                Stock = 95,
                SKU = "BAT-LIPO-2000"
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Producto>> Get()
        {
            return Ok(Productos);
        }

        [HttpPost]
        public ActionResult<Producto> Post(Producto producto)
        {
            producto.Id = Productos.Count + 1;
            Productos.Add(producto);
            return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Producto producto)
        {
            var existente = Productos.FirstOrDefault(p => p.Id == id);

            if (existente == null)
                return NotFound();

            existente.Nombre = producto.Nombre;
            existente.Descripcion = producto.Descripcion;
            existente.Precio = producto.Precio;
            existente.Stock = producto.Stock;
            existente.SKU = producto.SKU;
            existente.CategoriaId = producto.CategoriaId;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var producto = Productos.FirstOrDefault(p => p.Id == id);

            if (producto == null)
                return NotFound();

            Productos.Remove(producto);
            return NoContent();
        }
    }
}