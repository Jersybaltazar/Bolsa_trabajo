<?php

// Establecer la conexión con la base de datos
include 'conexion.php';


// Obtener el valor del parámetro "razon_social" de la URL
$id_empresa = isset($_GET['id_empresa']) ? $_GET['id_empresa'] : '';

// Consulta SQL para obtener los datos filtrados por razon_social
$sql = "SELECT nombre, imagen, descripcionL, id_empresa FROM producto";
 if (!empty($id_empresa)) {
     $sql .= " WHERE id_empresa = '$id_empresa'";
 }

$result = $conn->query($sql);

// Crear una lista JSON con los datos obtenidos de la base de datos
$lista_json = array();
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $item = array(
            'nombre' => $row['nombre'],
            'imagen' => $row['imagen'],
            'descripcionL' => $row['descripcionL'],
            'id_empresa' => $row['id_empresa'],
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