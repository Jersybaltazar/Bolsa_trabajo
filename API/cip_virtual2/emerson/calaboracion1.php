<?php

// Establecer la conexión con la base de datos
include 'conexion.php';


// Obtener el valor del parámetro "razon_social" de la URL
$categoria = isset($_GET['Categoria']) ? $_GET['Categoria'] : '';

// Consulta SQL para obtener los datos filtrados por razon_social
$sql = "SELECT
usuario.nombre AS nom_usuario,
usuario.apellidos AS ap_usuario, 
usuario.Presentacion AS presentacion,
categoria_documento.categoria_documento AS Categoria
FROM
usuario
INNER JOIN categoria_documento ON categoria_documento.id_usuario = usuario.id_usuario ";
if (!empty($usuario)) {
    $sql .= " WHERE Categoria LIKE '%$categoria%'";
}

$result = $conn->query($sql);

// Crear una lista JSON con los datos obtenidos de la base de datos
$lista_json = array();
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $item = array(
            'nom_usuario' => $row['nom_usuario'],
            'ap_usuario' => $row['ap_usuario'],
            'presentacion' => $row['presentacion'],
            'Categoria' => $row['Categoria'],
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