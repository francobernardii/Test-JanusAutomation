# Test - Janus Automation

# Consigna

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
