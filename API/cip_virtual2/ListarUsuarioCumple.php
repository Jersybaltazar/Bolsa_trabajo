<?php
// Incluir el archivo de conexión a la base de datos
include 'conexion.php';

date_default_timezone_set('America/Lima');
$fecha = date('Y-m-d H:i:s');

// Obtener el mes actual
$mes_actual = date('m');

// Consulta SQL para obtener los usuarios que cumplen años este mes
$sql = "SELECT id_usuario, nombre_usuario, apellidos, f_nacimiento,foto FROM usuario WHERE MONTH(f_nacimiento) = '$mes_actual'";
$resultado = $conn->query($sql);

// Verificar si se encontraron usuarios que cumplen años
if ($resultado->num_rows > 0) {
    // Crear una lista JSON con los datos obtenidos de la base de datos
    $usuarios = array();
    while ($row = $resultado->fetch_assoc()) {
        $nombreImagen = $row['foto'];
        $carpetaDestino = 'C:\\IMG\\';
        $rutaImagen = $carpetaDestino . $nombreImagen;
        $imageData = file_get_contents($rutaImagen);
        $imagenCodificada = base64_encode($imageData);

        $usuario = array(
            'id_usuario' => $row['id_usuario'],
            'nombre_usuario' => $row['nombre_usuario'],
            'apellidos' => $row['apellidos'],
            'f_nacimiento' => $row['f_nacimiento'],
            'foto' => $imagenCodificada
        );
        $usuarios[] = $usuario;
    }

    // Devolver la lista JSON como respuesta
    header('Content-Type: application/json');
    echo json_encode($usuarios);
} else {
    // Devolver un mensaje de error si no se encontraron usuarios
    $error_msg = array(
        'error' => 'No se encontraron usuarios que cumplan años este mes.'
    );
    header('Content-Type: application/json');
    echo json_encode($error_msg);
}

// Cerrar la conexión a la base de datos
$conn->close();
?>
