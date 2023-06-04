<?php

// Establecer la conexión con la base de datos
include 'conexion.php';


// Obtener el valor del parámetro "razon_social" de la URL
$nombre = isset($_GET['nombre']) ? $_GET['nombre'] : '';

// Consulta SQL para obtener los datos filtrados por razon_social
$sql = "SELECT nombre, link FROM videos_interes ";
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
            'link' => $row['link']
            
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