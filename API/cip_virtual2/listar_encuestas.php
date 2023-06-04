<?php

// Establecer la conexión con la base de datos
include 'conexion.php';


// Obtener el valor del parámetro "estado" de la URL
$estado = isset($_GET['estado']) ? $_GET['estado'] : '';

// Consulta SQL para obtener los datos filtrados por id_usuario y estado
$sql = "SELECT  encuestas.id_usuario, usuario.nombre_usuario, encuestas.link, encuestas.estado  FROM encuestas 
        INNER JOIN usuario ON encuestas.id_usuario = usuario.id_usuario";

if (!empty($estado)) {
    $estado = intval($estado);
    $sql .= " WHERE encuestas.estado = $estado";
}



$result = $conn->query($sql);

// Comprobar si se han obtenido resultados de la base de datos
if (!$result) {
    die('Error en la consulta: ' . mysqli_error($conn));
} elseif ($result->num_rows == 0) {
    die('No se encontraron resultados.');
}

// Crear una lista JSON con los datos obtenidos de la base de datos
$lista_json = array();
while ($row = $result->fetch_assoc()) {
    $item = array(
        'id_usuario' => $row['id_usuario'],
        'nombre_usuario' => $row['nombre_usuario'],
        'link' => $row['link'],
        'estado' => $row['estado'],
    );
    $lista_json[] = $item;
}

// Devolver la lista JSON como respuesta
header('Content-Type: application/json');
echo json_encode($lista_json);

// Cerrar la conexión a la base de datos
$conn->close();

?>