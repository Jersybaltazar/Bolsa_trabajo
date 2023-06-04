<?php

// Establecer la conexión con la base de datos
include 'conexion.php';


// Obtener el valor del parámetro "razon_social" de la URL
$nombre_evento = isset($_GET['nombre_evento']) ? $_GET['nombre_evento'] : '';

// Consulta SQL para obtener los datos filtrados por razon_social
$sql = "SELECT nombre_evento, ruta_img, modalidad, fecha, hora, descripcion_modalidad FROM eventos_programados";
if (!empty($nombre_evento)) {
    $sql .= " WHERE nombre_evento LIKE '%$nombre_evento%'";
}

$result = $conn->query($sql);

// Crear una lista JSON con los datos obtenidos de la base de datos
$lista_json = array();
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $item = array(
            'nombre_evento' => $row['nombre_evento'],
            'ruta_img' => $row['ruta_img'],
            'modalidad' => $row['modalidad'],
            'fecha' => $row['fecha'],
            'hora' => $row['hora'],
            'descripcion_modalidad' => $row['descripcion_modalidad'],
            
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