# PoliMarketFunctions - Sistema de Funciones en Azure

Este proyecto implementa una serie de microservicios utilizando **Azure Functions** y **C#** para simular las operaciones de la empresa **PoliMarket**. El sistema se basa en la descripción de un problema académico del módulo _"Temas avanzados en diseño de software"_.

La empresa PoliMarket cuenta con diferentes áreas de negocio, cada una con sistemas de información separados, como son: **bodega, ventas, recursos humanos, proveedores y entregas**. Este proyecto busca implementar 5 requisitos funcionales clave que reflejan la interacción entre estas áreas.

---

## ✅ Requisitos Previos

Para ejecutar este proyecto localmente, necesitarás tener instalado lo siguiente:

- .NET SDK (versión 7.0 o superior)  
- Azure Functions Core Tools (v4)  
- Node.js (necesario para instalar las Core Tools vía `npm`)  
- Un editor de código como **Visual Studio Code**

---

## ⚙️ Configuración y Ejecución

### 1. Clonar el Repositorio (si aplica)

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

Para iniciar el servicio localmente, ejecuta:

```bash
func start
```

El host se iniciará en [http://localhost:7071](http://localhost:7071).

---

## 🚀 Funcionalidades Implementadas

El sistema expone **5 endpoints HTTP** que corresponden a los requisitos funcionales extraídos del problema.

---

### 1. Autorizar Vendedor (Recursos Humanos)

Autoriza a un vendedor para que pueda interactuar con los demás sistemas de la organización.

- **Endpoint:** `POST /api/vendedores/{id}/autorizar`

#### Ejemplo:

```bash
curl -X POST http://localhost:7071/api/vendedores/1/autorizar
```

---

### 2. Consultar Productos Disponibles (Ventas)

Permite a un vendedor ver la lista de productos disponibles. Internamente, este componente se conecta con la bodega para obtener la disponibilidad.

- **Endpoint:** `GET /api/productos`

#### Ejemplo:

```bash
curl http://localhost:7071/api/productos
```

---

### 3. Registrar una Venta (Ventas)

Permite a un vendedor autorizado registrar una venta para un cliente con productos específicos.

- **Endpoint:** `POST /api/ventas`

#### Ejemplo:

```bash
curl -X POST http://localhost:7071/api/ventas \
-H "Content-Type: application/json" \
-d '{"vendedorId": 2, "cliente": "Cliente Final S.A.", "productosIds": [101]}'
```

---

### 4. Registrar Compra a Proveedor (Bodega)

Permite a la bodega registrar la entrada de nuevos productos adquiridos de un proveedor.

- **Endpoint:** `POST /api/bodega/entradas`

#### Ejemplo:

```bash
curl -X POST "http://localhost:7071/api/bodega/entradas?productoId=101&cantidad=20&proveedor=NewTech"
```

---

### 5. Registrar Salida para Entrega (Entregas)

Permite al área de entregas registrar la salida de productos del stock de la bodega para ser entregados a un cliente.

- **Endpoint:** `POST /api/entregas/salida`

#### Ejemplo:

```bash
curl -X POST "http://localhost:7071/api/entregas/salida?productoId=102&cantidad=5&ventaId=123"
```

---

## 📂 Estructura del Proyecto

```
PoliMarketFunctions/
├── Models/                      # Clases que representan las entidades del negocio
│   ├── Producto.cs
│   ├── Vendedor.cs
│   └── Venta.cs
├── Database/                    # Simulación de la base de datos en memoria
│   └── InMemoryData.cs
├── AutorizarVendedor.cs         # RF1: Función para autorizar vendedores
├── ConsultarProductos.cs        # RF2: Función para listar productos
├── RegistrarVenta.cs            # RF3: Función para registrar ventas
├── RegistrarCompraProveedor.cs  # RF4: Función para registrar entradas de bodega
├── RegistrarSalidaEntrega.cs    # RF5: Función para registrar salidas de bodega
├── PoliMarketFunctions.csproj   # Archivo de proyecto .NET
└── local.settings.json          # Configuración local de la función
```