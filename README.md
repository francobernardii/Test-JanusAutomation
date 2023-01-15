# Test - Janus Automation
<details>
<summary><h3>Consigna</h3></summary>

## Diseño Base datos relacional.

Para este punto crear PK, FK, y relaciones entre las tablas. Esta base de datos se tiene que poder generar por script.

### Crear BD:
```
Test
```
### Crear tablas:
**TipoProduto**
```
id
descripcion
```

**Produto**
```
id
idTipoProducto
nombre
precio  
```

**Stock**
```
id
idProducto
cantidad
```

### Crear Vista:
``` 
vw_StockProducto 
```

### Crear Stored Procedures:
```
sp_InsertarProducto
sp_ModificarProdcuto
sp_EliminarProducto 
```

## Diseño BE

Crear solución webapi/aspx/winform/wpf/consola (una de las 4) en .net core/.net framework (uno de los 2) que se conecte con BD anterior y permita:

### Crear ABM de:
**Producto**

### Crear reporte de:
**Stock**

- *Como opcional, se puede utilizar EntityFramework(sin usar sp)*

## Diseño FE

En el caso de utilizar webapi en el apartado anterior, se valorará la elaboración de un FE que permita visualizar los datos retornados por las api. Esto se puede presentar con Angular/React/xamarin/otros.
En este punto solo se pide mostrar un reporte de stock, y como opcional ABM de producto

- *Todo agregado y corrección que se pueda realizar será bien visto.*
</details>

<details>
<summary><h3>Configuración</h3></summary>
 
Para poder utilizar la app se deben correr los ``` Scripts autogenerados.sql ``` o los ``` Scripts manuales.sql ``` para la creacion de la base de datos y sus objetos.

Una vez hecho esto se debe configurar la cadena de conexion dentro del objeto ```Module.cs``` en las funciones *Execute* y *Recover*.
  
![image](https://user-images.githubusercontent.com/75151884/212568797-68af02e0-224f-4be2-9e5c-4ac79d7a323f.png)

![image](https://user-images.githubusercontent.com/75151884/212568688-1baa089e-82e4-46d0-9fa5-858a6b015f88.png)

![image](https://user-images.githubusercontent.com/75151884/212568712-c2b0af10-d962-4aad-826d-e2edfd307571.png)
  
- *IMPORTANTE: cuando se usa la app por primera vez, se crea automaticamente en la tabla Usuarios el user Admin, el cual debe ser utilizado para crear los primeros usuarios.*

**Credenciales:**

> **User:** Admin

> **Password:** Admin
</details>

