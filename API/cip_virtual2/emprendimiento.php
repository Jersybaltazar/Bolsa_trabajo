<?php

// Establecer la conexión con la base de datos
include 'conexion.php';


// Obtener el valor del parámetro "razon_social" de la URL
$id_usuario  = isset($_GET['id_usuario']) ? $_GET['id_usuario'] : '';

// Consulta SQL para obtener los datos filtrados por razon_social
$sql = "SELECT id_empresa, razon_social, ruta_imagen, id_usuario FROM empresa WHERE id_usuario = '$id_usuario'";
// if (!empty($id_usuariol)) {
//     $sql .= " WHERE id_usuario = '$id_usuario'";
//}

$result = $conn->query($sql);

// Crear una lista JSON con los datos obtenidos de la base de datos
$lista_json = array();
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $item = array(
            'id_empresa' => $row['id_empresa'],
            'razon_social' => $row['razon_social'],
            'ruta_imagen' => $row['ruta_imagen'],
            'id_usuario' => $row['id_usuario'],
            
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