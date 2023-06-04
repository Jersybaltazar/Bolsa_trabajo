<?php

// Establecer la conexión con la base de datos
include 'conexion.php';


// Obtener el valor del parámetro "razon_social" de la URL
$uni = isset($_GET['nombre_uni']) ? $_GET['nombre_uni'] : '';

// Consulta SQL para obtener los datos filtrados por razon_social
$sql = "SELECT id_u_procedencia,nombre_uni FROM universidad_proc;";
if (!empty($uni)) {
    $sql .= " WHERE nombre_uni LIKE '%$uni%'";
}

$result = $conn->query($sql);

// Crear una lista JSON con los datos obtenidos de la base de datos
$lista_json = array();
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $item = array(
            'id_u_procedencia' => $row['id_u_procedencia'],
            'nombre_uni' => $row['nombre_uni']
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