<?php
// Establecer la conexión con la base de datos
include 'conexion.php';

// Obtener el valor del parámetro "estado" de la URL
$estado = isset($_GET['estado']) ? $_GET['estado'] : '';

// Consulta SQL para obtener los datos filtrados por estado
$sql = "SELECT bolsas_trabajo.id_usuario, bolsas_trabajo.descripcion, bolsas_trabajo.estado, bolsas_trabajo.contacto, usuario.nombre_usuario, usuario.apellidos, bolsas_trabajo.contacto2
        FROM bolsas_trabajo 
        INNER JOIN usuario ON bolsas_trabajo.id_usuario = usuario.id_usuario";
if (!empty($estado)) {
    $sql .= " WHERE estado LIKE '%$estado%'";
}

$result = $conn->query($sql);

// Crear una lista JSON con los datos obtenidos de la base de datos
$lista_json = array();
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $item = array(
            'id_usuario' => $row['id_usuario'],
            'nombre_usuario' => $row['nombre_usuario'],
            'apellidos' => $row['apellidos'],
            'descripcion' => $row['descripcion'],
            'estado' => $row['estado'],
            'contacto' => $row['contacto'],   
            'contacto2' => $row['contacto2']         
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