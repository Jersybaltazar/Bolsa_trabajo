<?php

// Establecer la conexión con la base de datos
include '../conexion.php';

// Obtener el valor del parámetro "nombre" de la URL
$nombre = isset($_GET['nombre']) ? $_GET['nombre'] : '';

// Consulta SQL para obtener los datos filtrados por nombre
$sql = "SELECT nombre, id_tipoDocumento, id_categoria, otros, img_ruta, descripcion, id_politica, id_usuario FROM comparta_documento";
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
            'id_tipoDocumento' => $row['id_tipoDocumento'],
            'id_categoria' => $row['id_categoria'],
            'otros' => $row['otros'],
            'img_ruta' => $row['img_ruta'],
            'descripcion' => $row['descripcion'],
            'id_politica' => $row['id_politica'],
            'id_usuario' => $row['id_usuario']
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