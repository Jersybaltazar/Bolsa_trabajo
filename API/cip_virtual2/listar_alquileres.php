<?php

// Establecer la conexión con la base de datos
include 'conexion.php';

// Obtener el valor del parámetro "tipo_alquiler" de la URL
$tipo_alquiler = isset($_GET['tipo_alquiler']) ? $_GET['tipo_alquiler'] : '';

// Consulta SQL para obtener los datos de la tabla alquileres
$sql = "SELECT tipo_alquiler, ubicacion, descripcion, link, ruta_img, contacto1, contacto2 FROM alquileres WHERE tipo_alquiler = '$tipo_alquiler'";

$result = $conn->query($sql);

// Crear una lista JSON con los datos obtenidos de la base de datos
$lista_json = array();
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $item = array(
            'tipo_alquiler' => $row['tipo_alquiler'],
            'ubicacion' => $row['ubicacion'],
            'descripcion' => $row['descripcion'],
            'link' => $row['link'],
            'ruta_img' => $row['ruta_img'],
            'contacto1' => $row['contacto1'],
            'contacto2' => $row['contacto2']
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