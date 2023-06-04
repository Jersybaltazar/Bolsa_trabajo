<?php

// Establecer la conexión con la base de datos
include '../conexion.php';

// Consulta SQL para obtener los datos de la tabla complejos
$sql = "SELECT ubicacion, contactos, link, ruta FROM complejos";

// Obtener el valor del parámetro "ubicacion" de la URL
$ubicacion = isset($_GET['ubicacion']) ? $_GET['ubicacion'] : '';

// Agregar filtro por ubicación si se especificó en la URL
if (!empty($ubicacion)) {
    $sql .= " WHERE ubicacion LIKE '%$ubicacion%'";
}

$result = $conn->query($sql);

// Crear una lista JSON con los datos obtenidos de la base de datos
$lista_json = array();
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $item = array(
            'ubicacion' => $row['ubicacion'],
            'contactos' => $row['contactos'],
            'link' => $row['link'],
            'ruta' => $row['ruta']
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