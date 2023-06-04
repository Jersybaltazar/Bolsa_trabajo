<?php

// Establecer la conexión con la base de datos
include 'conexion.php';

// Obtener el valor del parámetro "razon_social" de la URL
$razon_social = isset($_GET['razon_social']) ? $_GET['razon_social'] : '';
$id_empresa = isset($_GET['id_empresa']) ? $_GET['id_empresa'] : '';

// Consulta SQL para obtener los datos filtrados por razon_social o id
$sql = "SELECT id_empresa, ruc, ruta_imagen, razon_social, direcion, ubicacion, catalogo, celular, telefono, pagina_web, face, watsap, instagram, otros FROM empresa";

// Verificar si se proporcionó el parámetro de búsqueda por razon_social o id
if (!empty($razon_social) || !empty($id)) {
    $sql .= " WHERE ";
    $conditions = array();

    if (!empty($razon_social)) {
        $conditions[] = "razon_social LIKE '%$razon_social%'";
    }

    if (!empty($id_empresa)) {
        $conditions[] = "id_empresa = $id";
    }

    $sql .= implode(" AND ", $conditions);
}

$result = $conn->query($sql);

// Crear una lista JSON con los datos obtenidos de la base de datos
$lista_json = array();
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $item = array(
            'id_empresa' => $row['id_empresa'],
            'ruc' => $row['ruc'],
            'ruta_imagen' => $row['ruta_imagen'],
            'razon_social' => $row['razon_social'],
            'direcion' => $row['direcion'],
            'ubicacion' => $row['ubicacion'],
            'catalogo' => $row['catalogo'],
            'celular' => $row['celular'],
            'telefono' => $row['telefono'],
            'pagina_web' => $row['pagina_web'],
            'face' => $row['face'],
            'watsap' => $row['watsap'],
            'instagram' => $row['instagram'],
            'otros' => $row['otros'],
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
