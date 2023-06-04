<?php

// Establecer la conexión con la base de datos
include 'conexion.php';


// Obtener el valor del parámetro "razon_social" de la URL
$nombre = isset($_GET['nombre']) ? $_GET['nombre'] : '';

// Consulta SQL para obtener los datos filtrados por razon_social
$sql = "SELECT id_producto, nombre, precio, estado, descuento_estado, descuento, delivery_estado, descripcionC, descripcionL, imagen FROM producto ";
if (!empty($nombre)) {
    $sql .= " WHERE nombre LIKE '%$nombre%'";
}

$result = $conn->query($sql);

// Crear una lista JSON con los datos obtenidos de la base de datos
$lista_json = array();
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $item = array(
            'id_producto' => $row['id_producto'],
            'imagen' => $row['imagen'],
            'nombre' => $row['nombre'],
            'descripcionC' => $row['descripcionC'],
            'precio' => $row['precio'],
            'estado' => $row['estado'],
            'descuento' => $row['descuento'],
            'descuento_estado' => $row['descuento_estado'],
            'delivery_estado' => $row['delivery_estado'],
            'descripcionL' => $row['descripcionL'],
            
        );
        $lista_json[] = $item;
    }
}

// Devolver la lista JSON como respuesta
header('Content-Type: application/json');
echo json_encode($lista_json);

// Cerrar la conexión a la base de datos
$conn->close();

?>