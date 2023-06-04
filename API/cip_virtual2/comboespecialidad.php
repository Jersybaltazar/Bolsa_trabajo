<?php

// Establecer la conexión con la base de datos
include 'conexion.php';


// Obtener el valor del parámetro "razon_social" de la URL
$especialidad = isset($_GET['nombre_especialidad']) ? $_GET['nombre_especialidad'] : '';

// Consulta SQL para obtener los datos filtrados por razon_social
$sql = "SELECT id_especialidad,nombre_especialidad FROM especialidad;";
if (!empty($especialidad)) {
    $sql .= " WHERE nombre_especialidad LIKE '%$especialidad%'";
}

$result = $conn->query($sql);

// Crear una lista JSON con los datos obtenidos de la base de datos
$lista_json = array();
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $item = array(
            'id_especialidad' => $row['id_especialidad'],
            'nombre_especialidad' => $row['nombre_especialidad'],
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