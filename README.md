# PoliMarketFunctions - Sistema de Funciones en Azure

Este proyecto implementa una serie de microservicios utilizando **Azure Functions** y **C#** para simular las operaciones de la empresa **PoliMarket**. El sistema se basa en un caso académico del módulo _"Temas avanzados en diseño de software"_.

PoliMarket cuenta con diferentes áreas de negocio, cada una con sistemas de información separados: **bodega**, **ventas**, **recursos humanos**, **proveedores** y **entregas**. Este proyecto implementa requisitos funcionales clave que reflejan la interacción entre estas áreas.

---

## ✅ Requisitos Previos

Para ejecutar este proyecto localmente, necesitarás tener instalado lo siguiente:

- [.NET SDK 8.0 o superior](https://dotnet.microsoft.com/)
- [Azure Functions Core Tools v4](https://learn.microsoft.com/en-us/azure/azure-functions/functions-run-local)
- [Node.js](https://nodejs.org/) (necesario para instalar las Core Tools vía `npm`)
- Un editor de código como [Visual Studio Code](https://code.visualstudio.com/)

---

## ⚙️ Configuración y Ejecución

### 1. Clonar el Repositorio

```bash
git clone <url-del-repositorio>
cd PoliMarketFunctions
```

### 2. Construir el Proyecto

Este comando restaurará las dependencias de .NET y compilará el código:

```bash
dotnet build
```

### 3. Iniciar el Host de Funciones

Para iniciar el servicio localmente:

```bash
func start
```

El host estará disponible en `http://localhost:7071`.

---

## 🚀 Funcionalidades Implementadas

El sistema expone **7 endpoints HTTP** que simulan los procesos clave de PoliMarket:

### 1. Autorizar Vendedor (Recursos Humanos)

Autoriza a un vendedor para que pueda interactuar con otros sistemas.

- **Endpoint:** `POST /api/vendedores/{id}/autorizar`

```bash
curl -X POST http://localhost:7071/api/vendedores/1/autorizar
```

---

### 2. Consultar Productos Disponibles (Ventas)

Permite ver productos disponibles con precios y descripción. Consulta a la bodega internamente.

- **Endpoint:** `GET /api/productos`

```bash
curl http://localhost:7071/api/productos
```

---

### 3. Registrar una Venta (Ventas)

Registra una venta con productos específicos para un cliente.

- **Endpoint:** `POST /api/ventas`

```bash
curl -X POST http://localhost:7071/api/ventas \
-H "Content-Type: application/json" \
-d '{"vendedorId": 2, "cliente": "Cliente Final S.A.", "productosIds": [101]}'
```

---

### 4. Registrar Compra a Proveedor (Bodega)

Registra la entrada de productos adquiridos de un proveedor.

- **Endpoint:** `POST /api/bodega/entradas`

```bash
curl -X POST "http://localhost:7071/api/bodega/entradas?productoId=101&cantidad=20&proveedor=NewTech"
```

---

### 5. Registrar Salida para Entrega (Entregas)

Registra la salida de productos del inventario para entregas.

- **Endpoint:** `POST /api/entregas/salida`

```bash
curl -X POST "http://localhost:7071/api/entregas/salida?productoId=102&cantidad=5&ventaId=123"
```

---

### 6. Consultar Clientes

Lista todos los clientes potenciales.

- **Endpoint:** `GET /api/clientes`

```bash
curl http://localhost:7071/api/clientes
```

---

### 7. Consultar Proveedores

Lista los proveedores registrados.

- **Endpoint:** `GET /api/proveedores`

```bash
curl http://localhost:7071/api/proveedores
```

---

## 📂 Estructura del Proyecto

```
PoliMarketFunctions/
├── Models/                 
│   ├── Cliente.cs
│   ├── Producto.cs
│   ├── Proveedor.cs
│   ├── Vendedor.cs
│   └── Venta.cs
├── Database/               
│   └── InMemoryData.cs
├── AutorizarVendedor.cs
├── ConsultarProductos.cs
├── GetClientes.cs
├── GetProveedores.cs
├── RegistrarCompraProveedor.cs
├── RegistrarSalidaEntrega.cs
├── RegistrarVenta.cs
├── PoliMarketFunctions.csproj
└── local.settings.json
```