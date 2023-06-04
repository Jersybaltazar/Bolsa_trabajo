<?php
// Establecer la conexión con la base de datos
include 'conexion.php';

// Obtener la fecha actual
$fecha_actual = date('d/m/Y');

// Obtener el mes actual
$mes_actual = date('m');

// Consulta SQL para obtener los datos filtrados por mes de nacimiento
$sql = "SELECT
        usuario.id_usuario AS id_usuario,
        usuario.nombre_usuario,
        usuario.apellidos AS apellidos,
        usuario.f_nacimiento,
        usuario.foto
        FROM
        usuario
        WHERE MONTH(f_nacimiento) = '$mes_actual'";

$result = $conn->query($sql);

// Crear una lista JSON con los datos obtenidos de la base de datos
$lista_json = array();
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $id_usuario = $row['id_usuario'];
        $nombre_usuario = $row['nombre_usuario'];
        $apellidos = $row['apellidos'];

        $nombreImagen = $row['foto'];
        $carpetaDestino = 'C:\\IMG\\';
        $rutaImagen = $carpetaDestino . $nombreImagen;
        $imageData = file_get_contents($rutaImagen);
        $imagenCodificada = base64_encode($imageData);

        $f_nacimiento = date('d/m', strtotime($row['f_nacimiento'])) . '/' . date('Y'); // Reemplazar el año por el año actual

        $lista_json[] = array(
            'id_usuario' => $id_usuario,
            'nombre_usuario' => $nombre_usuario,
            'apellidos' => $apellidos,
            'foto' => $imagenCodificada,
            'f_nacimiento' => $f_nacimiento
        );
    }
}

// Devolver la lista JSON como respuesta
header('Content-Type: application/json');
echo json_encode($lista_json);

// Cerrar la conexión a la base de datos
$conn->close();
?>
