<?php

// Establecer la conexión con la base de datos
include 'conexion.php';


// Obtener el valor del parámetro "razon_social" de la URL
$Categoria = isset($_GET['categoria_documento']) ? $_GET['categoria_documento'] : '';

// Consulta SQL para obtener los datos filtrados por razon_social
$sql = "SELECT id, categoria_documento FROM categoria_documento;";
if (!empty($Categoria)) {
    $sql .= " WHERE categoria_documento LIKE '%$Categoria%'";
}

$result = $conn->query($sql);

// Crear una lista JSON con los datos obtenidos de la base de datos
$lista_json = array();
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $item = array(
            'id' => $row['id'],
            'categoria_documento' => $row['categoria_documento'],
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