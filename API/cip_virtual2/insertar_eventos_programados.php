<?php
// Establecer la conexión con la base de datos
include ('conexion.php');

// Validar los datos recibidos
// Obtener el JSON recibido y decodificarlo
$json = file_get_contents('php://input');
$data = json_decode($json, true);

// Validar los datos recibidos
if (isset($data['nombre_evento']) && isset($data['ruta_img']) && isset($data['modalidad']) && isset($data['fecha']) && isset($data['hora']) && isset($data['descripcion_modalidad'])) {
    $nombre_evento = $data['nombre_evento'];
    $ruta_img = $data['ruta_img'];
    $modalidad = $data['modalidad'];
    $fecha = $data['fecha'];
    $hora = $data['hora'];
    $descripcion_modalidad = $data['descripcion_modalidad'];

    // dar formato a la fecha
    $fecha_formateada = date('Y-m-d', strtotime($fecha));

    // Dar formato a la hora
    $hora_formateada = date('H:i:s', strtotime($hora));

    // Insertar los datos en la tabla "empresas"
    $sql = "INSERT INTO `eventos_programados` (`nombre_evento`, `ruta_img`, `modalidad`, `fecha`, `hora`, `descripcion_modalidad`) VALUES ('$nombre_evento', '$ruta_img','$modalidad','$fecha_formateada','$hora_formateada', '$descripcion_modalidad')";

    if ($conn->query($sql) === TRUE) {
        echo "La empresa se ha guardado correctamente.";
    } else {
        echo "Error al guardar la empresa: " . $conn->error;
    }
} else {
    echo "Debe proporcionar los datos de la empresa.";
}

// Cerrar la conexión con la base de datos
$conn->close();
?>

