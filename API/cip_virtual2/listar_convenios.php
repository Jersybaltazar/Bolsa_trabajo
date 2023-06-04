<?php

// Establecer la conexión con la base de datos
include 'conexion.php';

// Obtener el valor del parámetro "entidad" de la URL
$entidad = isset($_GET['entidad']) ? $_GET['entidad'] : '';

// Consulta SQL para obtener los datos filtrados por entidad
$sql = "SELECT entidad, direccion, pagina, firma, contacto FROM convenios";
if (!empty($entidad)) {
    $sql .= " WHERE entidad LIKE '%$entidad%'";
}

$result = $conn->query($sql);

// Crear una lista JSON con los datos obtenidos de la base de datos
$lista_json = array();
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $item = array(
            'entidad' => $row['entidad'],
            'direccion' => $row['direccion'],
            'pagina' => $row['pagina'],
            'firma' => $row['firma'],
            'contacto' => $row['contacto']
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