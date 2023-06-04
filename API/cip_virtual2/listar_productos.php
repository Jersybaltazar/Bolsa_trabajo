<?php

// Establecer la conexión con la base de datos
include '../conexion.php';

// Obtener el valor del parámetro "nombre" de la URL
$nombre = isset($_GET['nombre']) ? $_GET['nombre'] : '';

// Consulta SQL para obtener los datos filtrados por nombre
$sql = "SELECT nombre, precio, estado, descuento_estado, descuento, delivery_estado, descripcionC, descripcionL, imagen FROM producto";
if (!empty($nombre)) {
    $sql .= " WHERE nombre LIKE '%$nombre%'";
}

$result = $conn->query($sql);

// Crear una lista JSON con los datos obtenidos de la base de datos
$lista_json = array();
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $item = array(
            'nombre' => $row['nombre'],
            'precio' => $row['precio'],
            'estado' => $row['estado'],
            'descuento_estado' => $row['descuento_estado'],
            'descuento' => $row['descuento'],
            'delivery_estado' => $row['delivery_estado'],
            'descripcionC' => $row['descripcionC'],
            'descripcionL' => $row['descripcionL'],
            'imagen' => $row['imagen']
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